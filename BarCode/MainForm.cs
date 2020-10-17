using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace BarCode
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //pnlItem.Visible = false;
            this.pnlItem.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            //this.pnlItem.Anchor = AnchorStyles.None;
            int distance = (pn_Right.Size.Height - 105 * 6) / 7;
            int start = distance;
            btn_Generate.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, start);
            btn_Input.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, start = start +105+ distance);
            btn_Search.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, start = start + 105 + distance);
            btn_Info.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, start = start + 105 + distance);
            btn_CheckPrice.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, start = start + 105 + distance);
            btn_Exit.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, start = start + 105 + distance);
        }

        

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            var generatebarcode = new GenerateBarcode();
            generatebarcode.TopLevel = false;
            pnlItem.Controls.Add(generatebarcode);
            generatebarcode.Show();
        }       

        private void btnInput_Click(object sender, EventArgs e)
        {
            var manageProduct = new ManageProducts();
            manageProduct.TopLevel = false;
            pnlItem.Controls.Add(manageProduct);
            manageProduct.Show();
            //pnlItem.Visible = false;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var getProductById = new GetProductById();
            getProductById.TopLevel = false;
            pnlItem.Controls.Add(getProductById);
            getProductById.Show();
        }

        private void btn_Info_Click(object sender, EventArgs e)
        {
            var productinfo = new Product_Info();
            productinfo.TopLevel = false;
            pnlItem.Controls.Add(productinfo);
            productinfo.Show();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_CheckPrice_Click(object sender, EventArgs e)
        {
            var checkprice = new CheckPrice();
            checkprice.TopLevel = false;
            pnlItem.Controls.Add(checkprice);
            checkprice.Show();
        }
    }
}
