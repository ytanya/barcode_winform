using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BarCode
{
    public partial class GetProductById : Form
    {
        Thread delayedCalculationThread;
        int delay = 0;
        string conn = DBAccess.ConnectionString;
        DataTable dtMain = new DataTable();
        public GetProductById()
        {
            InitializeComponent();
        }

        private void Product_Information_Load(object sender, EventArgs e)
        {
            this.panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            this.panel1.Anchor = AnchorStyles.None;
            this.ActiveControl = tb_data;
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CalculateAfterStopTyping();
            
        }

        private void CalculateAfterStopTyping()
        {
            delay += 30;
            if (delayedCalculationThread != null && delayedCalculationThread.IsAlive)
                return;

            delayedCalculationThread = new Thread(() =>
            {
                while (delay >= 20)
                {
                    delay = delay - 20;
                    try
                    {
                        Thread.Sleep(20);
                    }
                    catch (Exception) { }
                }
                Invoke(new Action(() =>
                {
                    string id = tb_data.Text;
                    string query = "Select `products`.`id`,`name`,`description`,`expiration_date`, `pricemanagement`.`price` from `products` join `pricemanagement` on `products`.`id` = `pricemanagement`.`productid` where `products`.`id` = '" + id + "'; ";

                    using (MySqlConnection connection = new MySqlConnection(conn))
                    {
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            MySqlDataAdapter sda = new MySqlDataAdapter(command);
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dtMain.Merge(dt);

                            for (int ccc = 0; ccc < dtMain.Columns.Count; ccc++)
                            {
                                string name = dtMain.Columns["name"].ToString();
                                string description = dtMain.Columns["description"].ToString();
                                string icoFileName = dtMain.Columns["expiration_date"].ToString();
                                string installScript = dtMain.Columns["price"].ToString();
                            }
                            dataGridView1.DataSource = dtMain;
                            
                        }
                    }

                    tb_data.Text = string.Empty;
                    this.ActiveControl = tb_data;
                    
                }));
            });

            delayedCalculationThread.Start();
        }

    }
}
