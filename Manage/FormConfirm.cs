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
    public partial class FormConfirm : Form
    {
        public FormConfirm()
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
                SqlCommand selectbalance = new SqlCommand(("select balance from Card where no =" + label2.Text.Remove(0, 3)), conn);
                result = selectbalance.ExecuteReader();
                if (result.Read() && (double)result.GetDecimal(result.GetOrdinal("balance")) > (double)0)
                {
                    MessageBox.Show("此账号余额:" + ((double)result.GetDecimal(result.GetOrdinal("balance"))).ToString("G") + ",请取出!", "提示");
                    conn.Close();
                    this.Close();
                }
                else
                {
                    conn.Close();
                    conn.Open();
                    SqlCommand del_card = new SqlCommand();
                    del_card.Connection = conn;
                    del_card.CommandText = "delect from Card where no =" + label2.Text.Remove(0, 3);
                    if (del_card.ExecuteNonQuery() == 1)
                    {
                        conn.Close();
                        MessageBox.Show("销户成功!", "提示");
                        FormMenu fm = new FormMenu();
                        fm.label2.Text = label2.Text;
                        fm.Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("密码错误!", "提示");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Multiline = false;
            textBox1.PasswordChar = '*';
        }
    }
}
