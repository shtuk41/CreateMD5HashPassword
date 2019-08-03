using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Globalization;

namespace CreateMD5HashPassword
{
    public partial class Form1 : Form
    {
        private readonly string _Salt = "{0C0F1151-CF4D-4b1a-94E3-306AA197AE22}";

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {

            byte[] data;
            using (MD5 hasher = MD5.Create())
            {
                data = hasher.ComputeHash(Encoding.Default.GetBytes(_Salt + textBoxPassword.Text));
            }

            // reformat data, we want to return a hexadecimal string
            var builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2", CultureInfo.InvariantCulture));
            }

           textBoxMD5Hash.Text = builder.ToString();
        }
    }
}
