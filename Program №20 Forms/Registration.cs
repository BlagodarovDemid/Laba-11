using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program__20_Forms
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        private void Form1_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MSII\source\repos\Program №20 Forms\Program №20 Forms\Database1.mdf;Integrated Security=True");
            cn.Open();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != string.Empty || textBox2.Text != string.Empty || textBox1.Text != string.Empty)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    cmd = new SqlCommand("select * from LoginTable1 where username='" + textBox1.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into LoginTable1 values(@username,@password,@firstname,@lastname,@birthday,@email,@phone,@department,@level,@data)", cn);
                        cmd.Parameters.AddWithValue("username", textBox1.Text);
                        cmd.Parameters.AddWithValue("password", textBox2.Text);
                        cmd.Parameters.AddWithValue("firstname", textBox4.Text);
                        cmd.Parameters.AddWithValue("lastname", textBox5.Text);
                        cmd.Parameters.AddWithValue("birthday", textBox6.Text);
                        cmd.Parameters.AddWithValue("email", textBox7.Text);
                        cmd.Parameters.AddWithValue("phone", textBox8.Text);
                        cmd.Parameters.AddWithValue("department", textBox9.Text);
                        cmd.Parameters.AddWithValue("level", textBox10.Text);
                        cmd.Parameters.AddWithValue("data", textBox11.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
