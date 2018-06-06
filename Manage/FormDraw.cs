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
    public partial class FormDraw : Form
    {
        public FormDraw()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.DateTime currentTime = new System.DateTime();
            currentTime = System.DateTime.Now;
            //取当前年     
            int 年 = currentTime.Year;
            //取当前月     
            int 月 = currentTime.Month;
            //取当前日     
            int 日 = currentTime.Day;
            // 取当前时     
            int 时 = currentTime.Hour;
            //取当前分     
            int 分 = currentTime.Minute;
            //取当前秒     
            int 秒 = currentTime.Second;
            string no = "" + 年 + 月 + 日 + 时 + 分 + 秒;
            if(((textBox1.Text.Equals(""))))
            {
                MessageBox.Show("请输入取款金额", "提示");
            }
            else if ((Convert.ToDouble(textBox1.Text) > Convert.ToDouble(label4.Text.Remove(0, 3))) && (Convert.ToDouble(textBox1.Text)>0))
            {
                MessageBox.Show("余额不足,请重新输入", "提示");
            }
            else
            {
                if (label5.Text.Remove(0, 3).Equals("正常"))
                {
                    string connstr = "server=NUBIA\\SQLEXPRESS;database=BankSavingSystem;Integrated Security=SSPI";
                    SqlConnection conn = new SqlConnection(connstr);
                    conn.Open();
                    SqlCommand note = new SqlCommand();
                    note.Connection = conn;
                    note.CommandText = "insert into Action (no,time,id,money,type)values('" + no + "','" + System.DateTime.Now.ToString() + "','" + label2.Text.Remove(0, 3) + "','" + textBox1.Text + "','0')";
                    if (note.ExecuteNonQuery() == 1)
                    {
                        conn.Close();
                        conn.Open();
                        SqlCommand deposit = new SqlCommand();
                        deposit.Connection = conn;
                        deposit.CommandText = "update Card set balance = balance -" + textBox1.Text + "where no =" + label1.Text.Remove(0, 3);
                        if (deposit.ExecuteNonQuery() == 1)
                        {
                            conn.Close();
                            conn.Open();
                            SqlCommand check_balance = new SqlCommand(("select * from Card where no = " + label1.Text.Remove(0, 3)), conn);
                            SqlDataReader result = check_balance.ExecuteReader();
                            if (result.Read())
                            {
                                MessageBox.Show("取款成功!\n当前余额:" + ((double)result.GetDecimal(result.GetOrdinal("balance"))).ToString("G"), "提示");
                                FormMenu fm = new FormMenu();
                                fm.label2.Text = label1.Text;
                                fm.Show();
                                this.Hide();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("记录无法保存,取款失败!", "提示");
                    }
                }
                else
                {
                    MessageBox.Show("账户状态冻结,取款失败!", "提示");
                }
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
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
