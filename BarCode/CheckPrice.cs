using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BarCode
{
    public partial class CheckPrice : Form
    {
        Thread delayedCalculationThread;
        int delay = 0;
        string conn = DBAccess.ConnectionString;
        DataTable dtMain = new DataTable();
        string pathCSV = System.AppDomain.CurrentDomain.BaseDirectory + "taphoaviet.csv";
        public CheckPrice()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            this.panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            this.panel1.Anchor = AnchorStyles.None;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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
                    string id = textBox1.Text;
                    if (DBAccess.IsServerConnected())
                    {
                        string query = "Select `price` from `pricemanagement` where `productid` = '" + id + "'; ";

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
                                    textBox2.Text = dtMain.Columns["price"].ToString();
                                }

                            }
                        }
                    }
                    else
                    {
                        if (File.Exists(pathCSV))
                        {
                            var values = File.ReadLines(pathCSV).Skip(1).Select(line => line.Split(',')).ToList();

                            var price = values.Where(x => x[0] == id)
                                                .Select(x => x[3])
                                                .FirstOrDefault();
                            textBox2.Text = price;
                        }
                        
                    }

                    textBox1.Text = string.Empty;
                    this.ActiveControl = textBox1;

                }));
            });

            delayedCalculationThread.Start();
        }
    }
}
