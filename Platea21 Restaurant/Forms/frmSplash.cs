using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cindy_Restaurant.Forms;

namespace Cindy_Restaurant.Forms
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            label2.Text = "Platea21- http://platea21.blogspot.com";
            label1.Text = "v 1.0.0.1";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           frmLogin  formLogin = new frmLogin();
            progressBar1.Increment(1);

            if (this.progressBar1.Value == 10)
            {
                label3.Visible = true;
                label3.Text = "Iniciando...";
            }

            else if (this.progressBar1.Value == 60)
            {
                label3.Visible = true;
                label3.Text = "Cargando modulos...";
            }
            else if (this.progressBar1.Value == 80)
            {
                label3.Visible = true;
                label3.Text = "Procesando...";
            }
            else if (this.progressBar1.Value == 90)
            {
                label3.Visible = true;
                label3.Text = "Finalizando...";
            }
            else if (this.progressBar1.Value == 100)
            {

                timer1.Stop();
                this.Hide();
                formLogin.Show();
            }

        }
    }
}
