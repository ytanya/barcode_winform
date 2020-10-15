using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using ZXing;

namespace BarCode
{
    public partial class GenerateBarcode : Form
    {
        //key pair
        public GenerateBarcode()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    //get data into byte array
        //    //    byte[] bytesBuff = Encoding.Unicode.GetBytes(tb_data.Text);

        //    //    //using AES
        //    //    using (Aes aes = Aes.Create())
        //    //    {
        //    //        //C# Rfc2898DeriveBytes class uses iteration and salt with random set of bytes to encrypt a string.

        //    //        //the salt - new byte[] must be aleast 8 bytes or more.
        //    //        Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key,
        //    //            new byte[] { 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

        //    //        aes.Key = crypto.GetBytes(32);
        //    //        aes.IV = crypto.GetBytes(16);

        //    //        using (MemoryStream mStream = new MemoryStream())
        //    //        {
        //    //            using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
        //    //            {
        //    //                cStream.Write(bytesBuff, 0, bytesBuff.Length);
        //    //                cStream.Close();
        //    //            }
        //    //            string gobble = Convert.ToBase64String(mStream.ToArray());
        //    //            tb_data.Text = gobble;
        //    //        }
        //    //    }
        //    //}
        //    //catch (Exception ex) { MessageBox.Show("Text Box data cannot be empty. \n\n" + ex); }
        //    if (tb_data.Text != string.Empty)
        //    {
        //        BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
        //        pictureBox1.Image = writer.Write(tb_data.Text);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please input encode value.");
        //    }
        //}


        //private void button2_Click(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    byte[] bytesBuff = Convert.FromBase64String(tb_data.Text);
        //    //    using (Aes aes = Aes.Create())
        //    //    {

        //    //        //the salt - new byte[] must match the encrytion salt key.   
        //    //        Rfc2898DeriveBytes crypto = new Rfc2898DeriveBytes(key,
        //    //            new byte[] { 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

        //    //        aes.Key = crypto.GetBytes(32);
        //    //        aes.IV = crypto.GetBytes(16);
        //    //        using (MemoryStream mStream = new MemoryStream())
        //    //        {
        //    //            using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
        //    //            {
        //    //                cStream.Write(bytesBuff, 0, bytesBuff.Length);
        //    //                cStream.Close();
        //    //            }
        //    //            string decrypt = Encoding.Unicode.GetString(mStream.ToArray());
        //    //            tb_data.Text = decrypt;
        //    //        }
        //    //    }
        //    //}
        //    //catch (Exception ex) { MessageBox.Show("You need to execute Encrypt text first. \n\n" + ex); }
        //    if (tb_data.Text != string.Empty)
        //    {
        //        BarcodeReader reader = new BarcodeReader();
        //        var result = reader.Decode((Bitmap)pictureBox1.Image);
        //        if (result != null)
        //        {
        //            textBox1.Text = result.Text;
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please input encode value.");
        //    }
        //}

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image, 100, 100, 700, 600);
        }

        private void GenerateBarcode_Load(object sender, EventArgs e)
        {
            this.panel1.Location = new Point(this.ClientSize.Width / 2 - panel1.Size.Width / 2, this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            this.panel1.Anchor = AnchorStyles.None;
            this.ActiveControl = textBox1;
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
                pictureBox1.Image = writer.Write(textBox1.Text);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã barcode.");
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                printPreviewDialog1.Document = printDocument1;
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã barcode.");
            }
        }
    }
}
