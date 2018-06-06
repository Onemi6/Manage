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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label5.Text.Remove(0, 3).Equals("正常"))
            {
                string connstr = "server=NUBIA\\SQLEXPRESS;database=BankSavingSystem;Integrated Security=SSPI";
                SqlConnection conn = new SqlConnection(connstr);
                conn.Open();
                SqlCommand selectuser = new SqlCommand(("select password from Yonghu where no = " + label1.Text.Remove(0, 3)), conn);
                SqlDataReader result = selectuser.ExecuteReader();
                if (result.Read() && result.GetString(result.GetOrdinal("password")).Equals(textBox1.Text.ToString()))
                {
                    if (textBox2.Text.Length < 6)
                    {
                        MessageBox.Show("新密码位数不够6位!", "提示");
                    }
                    else if (textBox2.Text.Equals(textBox3.Text))
                    {
                        conn.Close();
                        conn.Open();
                        SqlCommand deposit = new SqlCommand();
                        deposit.Connection = conn;
                        deposit.CommandText = "update Yonghu set password = " + textBox2.Text + "where no =" + label1.Text.Remove(0, 3);
                        if (deposit.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("修改密码成功!", "提示");
                            FormMenu fm = new FormMenu();
                            fm.label2.Text = label1.Text;
                            fm.Show();
                            this.Hide();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("密码不一致!", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("旧密码错误!", "提示");
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("账户已冻结!无法操作!", "提示");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Multiline = false;
            textBox2.PasswordChar = '*';
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.Multiline = false;
            textBox3.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMenu fm = new FormMenu();
            fm.label2.Text = label1.Text;
            fm.Show();
            this.Hide();
        }
    }
}
