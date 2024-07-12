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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add(textBox1.Text,textBox2.Text,Convert.ToInt64( textBox3.Text),rdbMale.Checked);

            MessageBox.Show("Succ.....");
           
        }

        private void Add(string firtName,string lastname,long nationalCode,bool gender)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=.; Initial Catalog=CsharpSampleDB; Integrated Security=True";

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "Insert Students(FirstName,LastName,NatinalCode,Gender)values(@FirstName,@LastName,@NatinalCode,@Gender)";
            sqlCommand.Parameters.AddWithValue("FirstName", firtName);
            sqlCommand.Parameters.AddWithValue("LastName", lastname);
            sqlCommand.Parameters.AddWithValue("NatinalCode", nationalCode);
            sqlCommand.Parameters.AddWithValue("Gender", gender);

            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
         frmStudent fs=new frmStudent();
            fs.ShowDialog();
        }
    }
}
