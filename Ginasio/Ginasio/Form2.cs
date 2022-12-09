using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using System.Security.Cryptography;

namespace Ginasio
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        static string Hash(string input)

        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));

                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)

                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.Funcionarios.insertFuncionario(textBox4.Text, Hash(textBox3.Text), dateTimePicker1.Text, textBox5.Text, comboBox1.Text);
            }
            catch
            {
                MessageBox.Show("Erro");
            }
            
        }
    }
}
