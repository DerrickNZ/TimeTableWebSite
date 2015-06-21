using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI;
using NPOI.SS.UserModel;
using TimeTableBOL;
using TimeTableBLL;

namespace TimeTableDataEntry
{
    public partial class frmDataEntry : Form
    {
        public frmDataEntry()
        {
            InitializeComponent();
        }

        private void btnFileSelect_Click(object sender, EventArgs e)
        {
            //Open Dialog for get excel file
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                //set filter to display xls or xlsx files
                ofd.Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx";
                ofd.Multiselect = false;
                ofd.ShowDialog();

                //check if file name is empty
                if (ofd.FileName != String.Empty)
                {
                    //if file name is not empty,set text = file name
                    tbFilePath.Text = ofd.FileName;
                    //enable data entry button
                    btnImport.Enabled = true;
                }
                else
                {
                    //if file name is empty, set text = empty
                    tbFilePath.Text = String.Empty;
                    //disable data entry button
                    btnImport.Enabled = false;
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //if text is empty
            if (tbFilePath.Text == String.Empty)
            {
                return;
            }

            //Begin Process File
            btnImport.Enabled = false;
            tbLog.Clear();

            //ReadFile
            using (FileStream fs = File.OpenRead(tbFilePath.Text))
            {
                //User NPOI to read excel files
                IWorkbook wb = WorkbookFactory.Create(fs);
                tbLog.AppendText("Creat File OK." + Environment.NewLine);

                //Get Rows
                var rows = wb.GetSheetAt(0).GetRowEnumerator();

                //Get First Row
                rows.MoveNext();
                IRow firstRow = rows.Current as IRow;
                tbLog.AppendText("Get First Row OK." + Environment.NewLine);

                //Deal Table Header
                List<ICell> cells = firstRow.Cells;
                IDictionary<string, int> header = new Dictionary<string, int>();
                foreach (var cell in cells)
                {
                    if (String.IsNullOrEmpty(cell.StringCellValue))
                        continue;
                    header.Add(cell.StringCellValue, cell.ColumnIndex);
                }

                //fill Rows to List<User>
                List<Applicant> list = new List<Applicant>();

                //ID Name DateOfBirth Score OccupationCode StepOne StepTwo StepThree StepFour
                //Add Excel File Content to list
                while (rows.MoveNext())
                {
                    IRow row = (IRow)rows.Current;

                    list.Add(new Applicant()
                    {
                        //ApplicantID = (int)row.GetCell(header["ID"]).NumericCellValue,
                        ApplicantName = row.GetCell(header["Name"]).StringCellValue,

                        DateOfBirth = row.GetCell(header["DateOfBirth"]).DateCellValue,
                        Score = (int)row.GetCell(header["Score"]).NumericCellValue,
                        OccupationCode = row.GetCell(header["OccupationCode"]).StringCellValue,

                        StepOne = row.GetCell(header["StepOne"]).CellType == CellType.Blank ? (DateTime?)null : row.GetCell(header["StepOne"]).DateCellValue,
                        StepTwo = row.GetCell(header["StepTwo"]).CellType == CellType.Blank ? (DateTime?)null : row.GetCell(header["StepTwo"]).DateCellValue,
                        StepThree = row.GetCell(header["StepThree"]).CellType == CellType.Blank ? (DateTime?)null : row.GetCell(header["StepThree"]).DateCellValue,
                        StepFour = row.GetCell(header["StepFour"]).CellType == CellType.Blank ? (DateTime?)null : row.GetCell(header["StepFour"]).DateCellValue,
                    });
                }

                //User Service to store data to database 
                ApplicantBLL service = new ApplicantBLL();
                service.AddRange(list);
                tbLog.AppendText("Finish Import." + Environment.NewLine);

                //End Process File
                btnImport.Enabled = true;
            }
        }
    }
}
