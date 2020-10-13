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
        public ManageProducts()
        {
            InitializeComponent();
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
                        dtNew = GetDataTabletFromCSVFile(dialog.FileName);
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

        public static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                if (csv_file_path.EndsWith(".csv"))
                {
                    using (Microsoft.VisualBasic.FileIO.TextFieldParser csvReader = new Microsoft.VisualBasic.FileIO.TextFieldParser(csv_file_path))
                    {
                        csvReader.SetDelimiters(new string[] { "," });
                        csvReader.HasFieldsEnclosedInQuotes = true;
                        //read column
                        string[] colFields = csvReader.ReadFields();
                        foreach (string column in colFields)
                        {
                            DataColumn datecolumn = new DataColumn(column);
                            datecolumn.AllowDBNull = true;
                            csvData.Columns.Add(datecolumn);
                        }
                        while (!csvReader.EndOfData)
                        {
                            string[] fieldData = csvReader.ReadFields();
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }
                            csvData.Rows.Add(fieldData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exce " + ex);
            }
            return csvData;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtItem = (DataTable)(dgItems.DataSource);
                string id, name, desc, expirydate, price;
                string InsertItemQry = "";
                int count = 0;
                var csv = new StringBuilder();
                foreach (DataRow dr in dtItem.Rows)
                {
                    id = Convert.ToString(dr["barcode"]);
                    name = Convert.ToString(dr["ten san pham"]);
                    desc = dr["mo ta"]==null? string.Empty : Convert.ToString(dr["mo ta"]);
                    expirydate = Convert.ToString(dr["han su dung"]);
                    price = Convert.ToString(dr["don gia"]);
                    if (id != "" && name != "")
                    {
                        InsertItemQry += "Insert into products(`id`,`name`,`description`,`expiration_date`) Values ('" + id + "','" + name + "','" + desc + "','" + expirydate + "'); Insert into pricemanagement(`productid`,`price`) Values ('" + id + "','" + price  + "');";
                        var newLine = $"{id},{name},{desc},{expirydate},{price}";
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
                            dgItems.DataSource = null;
                        }
                    }
                }
                else
                {
                    File.AppendAllText("C:\\Users\\Tanya\\Desktop\\barcode.csv", csv.ToString());
                    MessageBox.Show("Thành công, Số sản phẩm đã nhập : " + count + "", "XH POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var csv = new StringBuilder();
                string id = string.Empty;
                if(txt_barcode.Text == string.Empty)
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
                string expirydate = txtExpiryDate.Text;
                string price = txtPrice.Text;

                string query = "Insert into products(`id`,`name`,`description`,`expiration_date`) Values('" + id + "', '" + name + "', '" + desc + "', '" + expirydate + "'); Insert into pricemanagement(`productid`,`price`) Values('" + id + "', '" + price + "'); ";
                var newLine = $"{id},{name},{desc},{expirydate},{price}";
                csv.AppendLine(newLine);
                if (DBAccess.IsServerConnected())
                {
                    bool success = DBAccess.ExecuteQuery(query);

                    if (success)
                    {
                        MessageBox.Show("Thành công, Số sản phẩm đã nhập : 1", "XH POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thành công.", "XH POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    File.AppendAllText("C:\\Users\\Tanya\\Desktop\\barcode.csv", csv.ToString());
                    MessageBox.Show("Thành công, Số sản phẩm đã nhập : 1", "XH POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }
           
        }
    }
}
