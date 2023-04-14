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
    public partial class Home : Form
    {
        public Home(int id, string firstname, string lastname, string birthday, string email, string phone, string department, string level, string data)
        {
            InitializeComponent();
            richTextBox1.Text = String.Format("id: {0} \nName: {1} {2} \nBirthday: {3} \nEmail: {4} \nPhone: {5} \nDepartment: {6} \nLevel: {7} \nData: {8}", id, firstname, lastname, birthday, email, phone, department, level, data);
        }
        Login login;
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        public static int id;
        public string firstname;
        public string lastname;
        public string birthday;
        public string email;
        public string phone;
        public string department;
        public string level;
        public string data;
        private void Home_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MSII\source\repos\Program №20 Forms\Program №20 Forms\Database1.mdf;Integrated Security=True");
            cn.Open();
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = String.Format("id: {0} \nName: {1} {2} \nBirthday: {3} \nEmail: {4} \nPhone: {5} \nDepartment: {6} \nLevel: {7} \nData: {8}", id, firstname, lastname, birthday, email, phone, department, level, data);
        }
    }
}
