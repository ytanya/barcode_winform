using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarCode
{
    public partial class Product_Info : Form
    {
        string pathCSV = System.AppDomain.CurrentDomain.BaseDirectory + "taphoaviet.csv";
        public Product_Info()
        {
            InitializeComponent();
        }

        private void Product_Info_Load(object sender, EventArgs e)
        {
            this.panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            this.panel1.Anchor = AnchorStyles.None;
            ShowDataToGridView();
        }
        
        private void ShowDataToGridView()
        {
            string query = "Select `products`.`id`,`name`,`description`,`expiration_date`, `manufacturer`, `pricemanagement`.`price` from `products` join `pricemanagement` on `products`.`id` = `pricemanagement`.`productid`";
            DataTable dt = new DataTable();
            DataTable dtnew = new DataTable();
            dtnew.Columns.Add("Barcode");
            dtnew.Columns.Add("Ten San Pham");
            dtnew.Columns.Add("Mo ta");
            dtnew.Columns.Add("Don gia");
            dtnew.Columns.Add("Han su dung");
            dtnew.Columns.Add("Nha san xuat");
            if (DBAccess.IsServerConnected())
            {
                dtnew = DBAccess.FillDataTable(query, dt);
                
            }
            else
            {
                dtnew = CSVHelper.GetDataTabletFromCSVFile(pathCSV);
            }
            dataGridView1.DataSource = dtnew;
        }
    }
}
