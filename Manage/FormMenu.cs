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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string connstr = "server=NUBIA\\SQLEXPRESS;database=BankSavingSystem;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();

            SqlCommand deposit = new SqlCommand(("select * from Card where no = " + label2.Text.Remove(0, 3)), conn);
            SqlDataReader result = deposit.ExecuteReader();
            if (result.Read() && result.GetInt32(result.GetOrdinal("state")) == 0)
            {
                FormDraw fd = new FormDraw();
                fd.label1.Text = fd.label1.Text + result.GetString(result.GetOrdinal("no"));
                fd.label2.Text = fd.label2.Text + result.GetString(result.GetOrdinal("id"));
                fd.label4.Text = fd.label4.Text + ((double)result.GetDecimal(result.GetOrdinal("balance"))).ToString("G");

                if (result.GetInt32(result.GetOrdinal("state")) == 0)
                {
                    fd.label5.Text = fd.label5.Text + "正常";
                }
                else
                {
                    fd.label5.Text = fd.label5.Text + "冻结";
                }
                conn.Close();
                conn.Open();
                SqlCommand check_username = new SqlCommand(("select * from Yonghu where no = " + label2.Text.Remove(0, 3)), conn);
                result = check_username.ExecuteReader();
                if (result.Read())
                {
                    fd.label3.Text = fd.label3.Text + result.GetString(result.GetOrdinal("username"));
                }
                fd.Show();
                this.Hide();
                conn.Close();
            }
            else if (result.GetInt32(result.GetOrdinal("state")) == 1)
            {
                MessageBox.Show("账户已冻结!无法操作!", "提示");
            }
            else
            {
                MessageBox.Show("请先开户!", "提示");
                conn.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstr = "server=NUBIA\\SQLEXPRESS;database=BankSavingSystem;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();

            SqlCommand check_ca = new SqlCommand(("select * from Card where no = " + label2.Text.Remove(0, 3)), conn);
            SqlDataReader result = check_ca.ExecuteReader();
            if (result.Read() && result.GetInt32(result.GetOrdinal("state")) == 0)
            {
                MessageBox.Show("此账号已开户!请选择其他操作", "提示");
            }
            else if (result.GetInt32(result.GetOrdinal("state")) == 1)
            {
                MessageBox.Show("账户已冻结!无法操作!", "提示");
            }
            else
            {
                conn.Close();
                conn.Open();
                SqlCommand selectuser = new SqlCommand(("select * from Yonghu where no = " + label2.Text.Remove(0, 3)), conn);
                result = selectuser.ExecuteReader();
                CreateAccount ca_from = new CreateAccount();


                ca_from.textBox1.Text = label2.Text.Remove(0, 3);
                while (result.Read())
                {
                    ca_from.textBox2.Text = result.GetString(result.GetOrdinal("username"));
                }
                ca_from.Show();
                this.Hide();
                conn.Close();
            }
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connstr = "server=NUBIA\\SQLEXPRESS;database=BankSavingSystem;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();

            SqlCommand check_ca = new SqlCommand(("select * from Card where no = " + label2.Text.Remove(0, 3)), conn);
            SqlDataReader result = check_ca.ExecuteReader();
            if (result.Read() && result.GetInt32(result.GetOrdinal("state")) == 0)
            {
                CloseAccount ca = new CloseAccount();
                ca.label1.Text = ca.label1.Text + result.GetString(result.GetOrdinal("no"));
                ca.label2.Text = ca.label2.Text + result.GetString(result.GetOrdinal("id"));
                ca.label4.Text = ca.label4.Text + ((double)result.GetDecimal(result.GetOrdinal("balance"))).ToString("G");

                if (result.GetInt32(result.GetOrdinal("state")) == 0)
                {
                    ca.label5.Text = ca.label5.Text + "正常";
                }
                else
                {
                    ca.label5.Text = ca.label5.Text + "冻结";
                }
                conn.Close();
                conn.Open();
                SqlCommand check_username = new SqlCommand(("select * from Yonghu where no = " + label2.Text.Remove(0, 3)), conn);
                result = check_username.ExecuteReader();
                if (result.Read())
                {
                    ca.label3.Text = ca.label3.Text + result.GetString(result.GetOrdinal("username"));
                }
                ca.Show();
                this.Hide();
                conn.Close();
            }
            else if (result.GetInt32(result.GetOrdinal("state")) == 1)
            {
                MessageBox.Show("账户已冻结!无法操作!", "提示");
            }
            else
            {
                MessageBox.Show("请先开户!", "提示");
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connstr = "server=NUBIA\\SQLEXPRESS;database=BankSavingSystem;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();

            SqlCommand deposit = new SqlCommand(("select * from Card where no = " + label2.Text.Remove(0, 3)), conn);
            SqlDataReader result = deposit.ExecuteReader();
            if (result.Read() && result.GetInt32(result.GetOrdinal("state")) == 0)
            {
                FormDeposit fd = new FormDeposit();
                fd.label1.Text = fd.label1.Text + result.GetString(result.GetOrdinal("no"));
                fd.label2.Text = fd.label2.Text + result.GetString(result.GetOrdinal("id"));
                fd.label4.Text = fd.label4.Text + ((double)result.GetDecimal(result.GetOrdinal("balance"))).ToString("G");

                if (result.GetInt32(result.GetOrdinal("state")) == 0)
                {
                    fd.label5.Text = fd.label5.Text + "正常";
                }
                else
                {
                    fd.label5.Text = fd.label5.Text + "冻结";
                }
                conn.Close();
                conn.Open();
                SqlCommand check_username = new SqlCommand(("select * from Yonghu where no = " + label2.Text.Remove(0, 3)), conn);
                result = check_username.ExecuteReader();
                if (result.Read())
                {
                    fd.label3.Text = fd.label3.Text + result.GetString(result.GetOrdinal("username"));
                }
                fd.Show();
                this.Hide();
                conn.Close();
            }
            else if (result.GetInt32(result.GetOrdinal("state")) == 1)
            {
                MessageBox.Show("账户已冻结!无法操作!", "提示");
            }
            else
            {
                MessageBox.Show("请先开户!", "提示");
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connstr = "server=NUBIA\\SQLEXPRESS;database=BankSavingSystem;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();

            SqlCommand deposit = new SqlCommand(("select * from Card where no = " + label2.Text.Remove(0, 3)), conn);
            SqlDataReader result = deposit.ExecuteReader();
            if (result.Read())
            {
                FormBalance fb = new FormBalance();
                fb.label1.Text = fb.label1.Text + result.GetString(result.GetOrdinal("no"));
                fb.label2.Text = fb.label2.Text + result.GetString(result.GetOrdinal("id"));
                fb.label4.Text = fb.label4.Text + ((double)result.GetDecimal(result.GetOrdinal("balance"))).ToString("G");

                if (result.GetInt32(result.GetOrdinal("state")) == 0)
                {
                    fb.label5.Text = fb.label5.Text + "正常";
                }
                else
                {
                    fb.label5.Text = fb.label5.Text + "冻结";
                }
                conn.Close();
                conn.Open();
                SqlCommand check_username = new SqlCommand(("select * from Yonghu where no = " + label2.Text.Remove(0, 3)), conn);
                result = check_username.ExecuteReader();
                if (result.Read())
                {
                    fb.label3.Text = fb.label3.Text + result.GetString(result.GetOrdinal("username"));
                }
                fb.Show();
                conn.Close();
            }
            else
            {
                MessageBox.Show("请先开户!", "提示");
                conn.Close();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connstr = "server=NUBIA\\SQLEXPRESS;database=BankSavingSystem;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();

            SqlCommand deposit = new SqlCommand(("select * from Card where no = " + label2.Text.Remove(0, 3)), conn);
            SqlDataReader result = deposit.ExecuteReader();
            if (result.Read() && result.GetInt32(result.GetOrdinal("state")) == 0)
            {
                ChangePassword cp = new ChangePassword();
                cp.label1.Text = cp.label1.Text + result.GetString(result.GetOrdinal("no"));
                cp.label2.Text = cp.label2.Text + result.GetString(result.GetOrdinal("id"));
                
                if (result.GetInt32(result.GetOrdinal("state")) == 0)
                {
                    cp.label5.Text = cp.label5.Text + "正常";
                }
                else
                {
                    cp.label5.Text = cp.label5.Text + "冻结";
                }
                conn.Close();
                conn.Open();
                SqlCommand check_username = new SqlCommand(("select * from Yonghu where no = " + label2.Text.Remove(0, 3)), conn);
                result = check_username.ExecuteReader();
                if (result.Read())
                {
                    cp.label3.Text = cp.label3.Text + result.GetString(result.GetOrdinal("username"));
                }
                cp.Show();
                this.Hide();
                conn.Close();
            }
            else if (result.GetInt32(result.GetOrdinal("state")) == 1)
            {
                MessageBox.Show("账户已冻结!无法操作!", "提示");
            }
            else
            {
                MessageBox.Show("请先开户!", "提示");
                conn.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string connstr = "server=NUBIA\\SQLEXPRESS;database=BankSavingSystem;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();

            SqlCommand check_ca = new SqlCommand(("select * from Card where no = " + label2.Text.Remove(0, 3)), conn);
            SqlDataReader result = check_ca.ExecuteReader();
            if (result.Read() && result.GetInt32(result.GetOrdinal("state")) == 0)
            {
                FormLoss fl = new FormLoss();
                fl.label1.Text = fl.label1.Text + result.GetString(result.GetOrdinal("no"));
                fl.label2.Text = fl.label2.Text + result.GetString(result.GetOrdinal("id"));
                fl.label4.Text = fl.label4.Text + ((double)result.GetDecimal(result.GetOrdinal("balance"))).ToString("G");

                if (result.GetInt32(result.GetOrdinal("state")) == 0)
                {
                    fl.label5.Text = fl.label5.Text + "正常";
                }
                else
                {
                    fl.label5.Text = fl.label5.Text + "冻结";
                }
                conn.Close();
                conn.Open();
                SqlCommand check_username = new SqlCommand(("select * from Yonghu where no = " + label2.Text.Remove(0, 3)), conn);
                result = check_username.ExecuteReader();
                if (result.Read())
                {
                    fl.label3.Text = fl.label3.Text + result.GetString(result.GetOrdinal("username"));
                }
                fl.Show();
                this.Hide();
                conn.Close();
            }
            else if (result.GetInt32(result.GetOrdinal("state")) == 1)
            {
                MessageBox.Show("账户已冻结!", "提示");
            }
            else
            {
                MessageBox.Show("请先开户!", "提示");
                conn.Close();
            }
        }
    }
}
