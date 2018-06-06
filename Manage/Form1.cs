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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Multiline = false;
            textBox2.PasswordChar = '*';
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar !=(char)8)
            {
                e.Handled = true;
                label4.Text = "提示:只能输入数字!";
            }
            else    
                label4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int login=0;
            string connstr = "server=NUBIA\\SQLEXPRESS;database=BankSavingSystem;Integrated Security=SSPI";
            SqlConnection conn =  new SqlConnection(connstr);
            conn.Open( );

            if (textBox2.Text.Length < 6)
            {
                label4.Text = "提示:密码只能为6位!";
            }
            else
            {
                //string sql = "select password from Yonghu where no = " + textBox1.Text;
                SqlCommand selectuser = new SqlCommand(("select password from Yonghu where no = "+ textBox1.Text),conn);
                SqlDataReader result = selectuser.ExecuteReader();
                while (result.Read())
                {
                    if (result.GetString(result.GetOrdinal("password")).Equals(textBox2.Text.ToString()))
                    {
                        login = 1;
                    }
                }
                if (login == 1)
                {
                    MessageBox.Show("登录成功!", "提示");
                    FormMenu fm = new FormMenu();
                    fm.label2.Text =fm.label2.Text + textBox1.Text;
                    fm.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("账号或密码错误!", "提示");
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);  
        }
    }
}
