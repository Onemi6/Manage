using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manage
{
    public partial class FormLoss : Form
    {
        public FormLoss()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormConfirm2 fc2 = new FormConfirm2();
            fc2.label2.Text = label1.Text;
            fc2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormMenu fm = new FormMenu();
            fm.label2.Text = label1.Text;
            fm.Show();
            this.Hide();
        }
    }
}
