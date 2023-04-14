using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program__20_Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public int id;
        public string username;
        public string password;
        public string firstname;
        public string lastname;
        public string birthday;
        public string email;
        public string phone;
        public string department;
        public string level;
        public string data;
        private void Login_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MSII\source\repos\Program №20 Forms\Program №20 Forms\Database1.mdf;Integrated Security=True");
            cn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.ShowDialog();
        }

        private string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != string.Empty || textBox1.Text != string.Empty)
            {

                //cmd = new SqlCommand("select * from LoginTable1 where username='" + textBox1.Text + "' and password='" + GetHashString(textBox2.Text) + "'", cn);
                cmd = new SqlCommand("select * from LoginTable1 where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show(String.Format("id: {0} \nName: {1}", dr[0], dr[1]));
                    this.Hide();
                    id = Convert.ToInt32(dr[0]);
                    username = Convert.ToString(dr[1]);
                    password = Convert.ToString(dr[2]);
                    firstname = Convert.ToString(dr[3]);
                    lastname = Convert.ToString(dr[4]);
                    birthday = Convert.ToString(dr[5]);
                    email = Convert.ToString(dr[6]);
                    phone = Convert.ToString(dr[7]);
                    department = Convert.ToString(dr[8]);
                    level = Convert.ToString(dr[9]);
                    data = Convert.ToString(dr[10]);
                    Home home = new Home(id,firstname,lastname,birthday,email,phone,department,level,data);
                    home.ShowDialog();
                    dr.Close();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Не существует аккаунта с таким логином или паролем ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("select * from LoginTable1 where username='" + textBox1.Text + "'", cn);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                id = Convert.ToInt32(dr[0]);
                username = Convert.ToString(dr[1]);
                password = Convert.ToString(dr[2]);
                firstname = Convert.ToString(dr[3]);
                lastname = Convert.ToString(dr[4]);
                birthday = Convert.ToString(dr[5]);
                email = Convert.ToString(dr[6]);
                phone = Convert.ToString(dr[7]);
                department = Convert.ToString(dr[8]);
                level = Convert.ToString(dr[9]);
                data = Convert.ToString(dr[10]);

/*                MailAddress from = new MailAddress("nikitabrawler228@mail.ru", "Nikita");
                //MailAddress to = new MailAddress(Convert.ToString(dr[6]));
                MailAddress to = new MailAddress("nikitabrawler228@mail.ru");
                MailMessage m = new MailMessage(from, to);
                m.Subject = "Тест";
                m.Body = "<h1>Пароль: " + password + "</h1>";
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
                smtp.Credentials = new NetworkCredential("nikitabrawler228@mail.ru", "officiant228");
                smtp.EnableSsl = true;
                smtp.Send(m);*/
                dr.Close();
            }
        }
    }
}
