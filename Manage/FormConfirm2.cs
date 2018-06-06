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
    public partial class FormConfirm2 : Form
    {
        public FormConfirm2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstr = "server=NUBIA\\SQLEXPRESS;database=BankSavingSystem;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            SqlCommand selectpw = new SqlCommand(("select password from Yonghu where no =" + label2.Text.Remove(0,3)), conn);
            SqlDataReader result = selectpw.ExecuteReader();
            if (result.Read() && result.GetString(result.GetOrdinal("password")).Equals(textBox1.Text))
            {
                conn.Close();
                conn.Open();
                SqlCommand loss = new SqlCommand();
                loss.Connection = conn;
                loss.CommandText = "update Card set state =1 where no = "+ label2.Text.Remove(0,3);
                if (loss.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("此账户已冻结!请尽快前往银行解冻!", "提示");
                    FormMenu fm = new FormMenu();
                    fm.label2.Text = label2.Text;
                    fm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("密码错误!", "提示");
            }
            conn.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Multiline = false;
            textBox1.PasswordChar = '*';
        }
    }
}
