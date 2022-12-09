using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ginasio
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            Form1 insideForm = new Form1();
            insideForm.TopLevel = false;
            this.Controls.Add(insideForm);
            insideForm.Show();
        }

        private void gerirFuncionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (globais.accesslvl == "admin     ")
            {

                Form2 insideForm = new Form2();
                insideForm.TopLevel = false;
                this.Controls.Add(insideForm);
                insideForm.Show();

            }
        }
    }
}
