using System;
using Microsoft.Data.SqlClient;

namespace test
{
    public partial class ����������� : Form
    {
        static string connectionString = "Server=(localdb)\\test;Database=demo;Trusted_Connection=True;";
        public �����������()
        {
            InitializeComponent();

            textBox3.Visible = true;
            label4.Visible = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            if (IsUserValid(login, password))
            {
                MessageBox.Show("����������� �������!");
                // ����� ����� �������� ��� ��� ���������� ������������ �������� ����� �������� �����������
            }
            else
            {
                MessageBox.Show("������ �����������!");
            }

        }
        public static bool IsUserValid(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // SQL ������ ��� �������� ������ ������������
                    string query = "SELECT COUNT(*) FROM ���������� WHERE ����� = @login AND ������ = @password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);

                    // ���������� ������� � ��������� ����������
                    int count = (int)command.ExecuteScalar();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("������ ��� ����������� � ���� ������: " + ex.Message);
                    return false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*string login = textBox1.Text;
            string password = textBox2.Text;
            string password2 = textBox3.Text;
            textBox3.Visible = true;
            label4.Visible = true;*/
        }

        private void �����������_Load(object sender, EventArgs e)
        {

        }
        /*private bool RegisterUser(string login, string password)
{
   using (SqlConnection connection = new SqlConnection(connectionString))
   {
       try
       {
           connection.Open();
           // SQL ������ ��� ���������� ������ ������������
           string query = "INSERT INTO Users (�����, ������) VALUES (@login, @password)";
           SqlCommand command = new SqlCommand(query, connection);


           command.Parameters.AddWithValue("@login", login);
           command.Parameters.AddWithValue("@password", password);

           // ���������� �������
           int rowsAffected = command.ExecuteNonQuery();
           return rowsAffected > 0;
       }
       catch (Exception ex)
       {
           MessageBox.Show("������ ��� ����������� ������������: " + ex.Message);
           return false;
       }
   }
}*/
    }
}
