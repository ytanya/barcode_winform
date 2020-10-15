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
using MySql.Data.MySqlClient;

namespace BarCode
{
    public partial class ManageProducts : Form
    {
        string pathCSV = System.AppDomain.CurrentDomain.BaseDirectory + "taphoaviet.csv";
        DataTable dtGridView = new DataTable();
        public ManageProducts()
        {
            InitializeComponent();
        }

        private void InitGridView()
        {            
            dtGridView.Columns.Add("Barcode");
            dtGridView.Columns.Add("Ten San Pham");
            dtGridView.Columns.Add("Mo ta");
            dtGridView.Columns.Add("Don gia");
            dtGridView.Columns.Add("Han su dung");
            dtGridView.Columns.Add("Nha san xuat");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();
                int ImportedRecord = 0, inValidItem = 0;
                string SourceURl = "";

                if (dialog.FileName != "")
                {
                    if (dialog.FileName.EndsWith(".csv"))
                    {
                        DataTable dtNew = new DataTable();
                        dtNew = CSVHelper.GetDataTabletFromCSVFile(dialog.FileName);
                        if (Convert.ToString(dtNew.Columns[0]).ToLower() != "barcode")
                        {
                            MessageBox.Show("Invalid Items File");
                            btnSave.Enabled = false;
                            return;
                        }
                        txtFile.Text = dialog.SafeFileName;
                        SourceURl = dialog.FileName;
                        if (dtNew.Rows != null && dtNew.Rows.ToString() != String.Empty)
                        {
                            dgItems.DataSource = dtNew;
                        }
                        foreach (DataGridViewRow row in dgItems.Rows)
                        {
                            if (Convert.ToString(row.Cells["barcode"].Value) == "" || row.Cells["ten san pham"].Value == null)
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                                inValidItem += 1;
                            }
                            else
                            {
                                ImportedRecord += 1;
                            }
                        }
                        if (dgItems.Rows.Count == 0)
                        {
                            btnSave.Enabled = false;
                            MessageBox.Show("Không đọc được dữ liệu trong file", "XH POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn file csv.", "XH POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }

        //public static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        //{
        //    DataTable csvData = new DataTable();
        //    try
        //    {
        //        if (csv_file_path.EndsWith(".csv"))
        //        {
        //            using (Microsoft.VisualBasic.FileIO.TextFieldParser csvReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(csv_file_path))
        //            {
        //                csvReader.SetDelimiters(new string[] { "," });
        //                csvReader.HasFieldsEnclosedInQuotes = true;
        //                //read column
        //                string[] colFields = csvReader.ReadFields();
        //                foreach (string column in colFields)
        //                {
        //                    DataColumn datecolumn = new DataColumn(column);
        //                    datecolumn.AllowDBNull = true;
        //                    csvData.Columns.Add(datecolumn);
        //                }
        //                while (!csvReader.EndOfData)
        //                {
        //                    string[] fieldData = csvReader.ReadFields();
        //                    for (int i = 0; i < fieldData.Length; i++)
        //                    {
        //                        if (fieldData[i] == "")
        //                        {
        //                            fieldData[i] = null;
        //                        }
        //                    }
        //                    csvData.Rows.Add(fieldData);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Exce " + ex);
        //    }
        //    return csvData;
        //}

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgItems.DataSource != null)
                {
                    DataTable dtItem = (DataTable)(dgItems.DataSource);
                    string id, name, desc, expirydate, price, manufacture;
                    string InsertItemQry = "";
                    int count = 0;
                    var csv = new StringBuilder();
                    foreach (DataRow dr in dtItem.Rows)
                    {
                        id = Convert.ToString(dr["barcode"]);
                        name = Convert.ToString(dr["ten san pham"]);
                        desc = dr["mo ta"] == null ? string.Empty : Convert.ToString(dr["mo ta"]);
                        expirydate = Convert.ToString(dr["han su dung"]);
                        price = Convert.ToString(dr["don gia"]);
                        manufacture = Convert.ToString(dr["nha san xuat"]);
                        if (id != "" && name != "")
                        {
                            InsertItemQry += "Insert into products(`id`,`name`,`description`,`expiration_date`, `manufacture`) Values ('" + id + "','" + name + "','" + desc + "','" + expirydate + "','" + manufacture + "'); Insert into pricemanagement(`productid`,`price`) Values ('" + id + "','" + price + "');";
                            var newLine = $"{id},{name},{desc},{price},{expirydate},{manufacture}";
                            csv.AppendLine(newLine);
                            count++;
                        }
                    }
                    if (DBAccess.IsServerConnected())
                    {
                        if (InsertItemQry.Length > 5)
                        {
                            bool isSuccess = DBAccess.ExecuteQuery(InsertItemQry);
                            if (isSuccess)
                            {
                                MessageBox.Show("Thành công, Số sản phẩm đã nhập : " + count + "", "XH POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        File.AppendAllText(pathCSV, csv.ToString());
                        MessageBox.Show("Thành công, Số sản phẩm đã nhập : " + count + "", "XH POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    dtGridView = new DataTable();
                    InitGridView();
                    dgItems.DataSource = null;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageProducts_Load(object sender, EventArgs e)
        {
            this.panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            this.panel1.Anchor = AnchorStyles.None;
            this.ActiveControl = txtFile;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            EnableInsertField(false);
            InitGridView();
        }

        private void EnableInsertField(bool isEnable)
        {
            txtName.Enabled = isEnable;
            txtDesc.Enabled = isEnable;
            txtPrice.Enabled = isEnable;
            txt_mn.Enabled = isEnable;
            btnAdd.Enabled = isEnable;
            button1.Enabled = !isEnable;
            dateTimePicker1.Enabled = isEnable;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var csv = new StringBuilder();
                string id = string.Empty;
                if (txt_barcode.Text == string.Empty)
                {
                    Random generator = new Random();
                    id = generator.Next(0, 999999).ToString("D13");
                }
                else
                {
                    id = txt_barcode.Text;
                }
                string name = txtName.Text;
                string desc = txtDesc.Text;
                string expirydate = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                string price = txtPrice.Text;
                string mn = txt_mn.Text;
                
                DataRow dr = dtGridView.NewRow();
                dr["Barcode"] = id;
                dr["Ten San Pham"] = name;
                dr["Mo ta"] = desc;
                dr["Don gia"] = price;
                dr["Han su dung"] = expirydate;
                dr["Nha san xuat"] = mn;
                dtGridView.Rows.Add(dr);

                dgItems.DataSource = dtGridView;
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Reset() {
            txtFile.Text = string.Empty;
            txt_barcode.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txt_mn.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            
        }

        private void txtFile_Enter(object sender, EventArgs e)
        {
            EnableInsertField(false);
        }

        private void txt_barcode_Enter(object sender, EventArgs e)
        {
            EnableInsertField(true);
        }
    }
}
