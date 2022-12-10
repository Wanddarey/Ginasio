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

                load();
            }
            catch
            {
                MessageBox.Show("Erro");
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            load();
        }

    public void load()
        {
            DataTable dt = BLL.Funcionarios.Load();

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataTable dtgr = BLL.Funcionarios.Load();

            DataTable dt = BLL.Funcionarios.queryfuncionario2(Convert.ToInt32(dtgr.Rows[e.RowIndex]["IdFuncionario"]));

            if (dt.Rows.Count > 0)
            {

                textBox4.Text = dt.Rows[0]["nome"].ToString();

                textBox3.Text = Hash(dt.Rows[0]["password"].ToString());

                textBox5.Text = dt.Rows[0]["telefone"].ToString();

                comboBox1.Text = dt.Rows[0]["posicao"].ToString();

                dateTimePicker1.Value = Convert.ToDateTime(dt.Rows[0]["dtn"]);

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {

            textBox4.Clear();

            textBox3.Clear();

            textBox5.Clear();

            comboBox1.Text = null;

            dateTimePicker1.Value = DateTime.Today;

        }
    }
}
