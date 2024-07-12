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
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            show();
        }

        private void show()
        {
            var students = new List<Student>();
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=.; Initial Catalog=CsharpSampleDB; Integrated Security=True";

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "Select (FirstName,LastName,NatinalCode,Gender) from Students";

            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            Student model;
            while(reader.Read())
            {
              model = new Student();
                model.FirstName = reader["FirstName"].ToString();
                model.LastName= reader["LastName"].ToString();
                model.NationalCode = Convert.ToInt32( reader["NatinalCode"]);
                model.Gender = (Boolean)(reader["Gender"]);

               students.Add(model);  
                
            }
            reader.Close();
            sqlConnection.Close();

            dataGridView1.DataSource = students;
        }
        
    }
}
