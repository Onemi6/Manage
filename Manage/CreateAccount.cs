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
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstr = "server=NUBIA\\SQLEXPRESS;database=BankSavingSystem;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            SqlCommand selectuser = new SqlCommand(("select * from Card where id = " + textBox3.Text), conn);
            SqlDataReader result = selectuser.ExecuteReader();
            if (result.Read())
            {
                MessageBox.Show("与已有卡号重复,请重新输入卡号!");
                conn.Close();
            }
            else
            {
                conn.Close();
                conn.Open();
                SqlCommand check_pw = new SqlCommand(("select password from Yonghu where no = " + textBox1.Text), conn);
                result = check_pw.ExecuteReader();
                if (result.Read() && result.GetString(result.GetOrdinal("password")).Equals(textBox4.Text.ToString()))
                {
                        conn.Close();
                        conn.Open();
                        SqlCommand insert_card = new SqlCommand();
                        insert_card.Connection = conn;
                        string str = "INSERT INTO Card (id,balance,phone,no,rate,state)VALUES('";
                        str = str + textBox3.Text + "','";
                        str = str + textBox5.Text + "','";
                        str = str + textBox6.Text + "','";
                        str = str + textBox1.Text + "',";
                        str = str + "0.003,0)";
                        //MessageBox.Show(str);
                        insert_card.CommandText = str;
                        if (insert_card.ExecuteNonQuery() == 1)
                        {
                            if (MessageBox.Show("开户成功!", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                FormMenu fm = new FormMenu();
                                fm.label2.Text = fm.label2.Text + textBox1.Text;
                                fm.Show();
                                this.Hide();
                            }

                        }
                    }
                else
                {
                    MessageBox.Show("密码错误!请重新输入", "提示");
                }
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormMenu fm = new FormMenu();
            fm.label2.Text =fm.label2.Text+ textBox1.Text;
            fm.Show();
            this.Hide();
        }
    }
}
