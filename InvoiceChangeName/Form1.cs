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

namespace InvoiceChangeName
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = @"C:\Users\admin\Documents\要重傳的發票\test";
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                var resultFolder = Path.Combine(textBox1.Text,"result");
                if (!Directory.Exists(resultFolder))
                    Directory.CreateDirectory(resultFolder);

                var directoryInfo = new System.IO.DirectoryInfo(textBox1.Text);
                foreach (var fileInfo in directoryInfo.GetFiles())
                {
                    if (fileInfo.Name.Contains("xml"))
                    {
                        var newName = fileInfo.Name.Substring(0, fileInfo.Name.IndexOf("l", StringComparison.Ordinal) + 1);
                        fileInfo.CopyTo(Path.Combine(resultFolder, newName));
                    }
                }

                MessageBox.Show("Ok");
            }

        }
    }
}
