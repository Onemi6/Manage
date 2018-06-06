using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Manage
{
    public partial class CloseAccount : Form
    {
        public CloseAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormConfirm fc = new FormConfirm();
            fc.label2.Text = label1.Text;
            fc.Show();
            this.Hide();
        }

        private void CloseAccount_Load(object sender, EventArgs e)
        {
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
