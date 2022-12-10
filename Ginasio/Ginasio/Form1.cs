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
    public partial class Form1 : Form
    {
        public Form1()
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

        private void button1_Click(object sender, EventArgs e)
        {

            

            DataTable dt = BLL.Funcionarios.queryfuncionario(textBox1.Text, Hash(textBox2.Text));

            try
            {
                if (dt.Rows.Count > 0)
                {

                    globais.accesslvl = dt.Rows[0]["posicao"].ToString();

                    MessageBox.Show(globais.accesslvl);

                    this.Close();

                }
                else
                {
                    MessageBox.Show("Palavra passe errada");
                }
            }
            catch
            {
                MessageBox.Show("Erro");
            }
            

        }
    }
}
