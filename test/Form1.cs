using System;
using Microsoft.Data.SqlClient;

namespace test
{
    public partial class Авторизация : Form
    {
        static string connectionString = "Server=(localdb)\\test;Database=demo;Trusted_Connection=True;";
        public Авторизация()
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
                MessageBox.Show("Авторизация успешна!");
                // Здесь можно добавить код для выполнения определенных действий после успешной авторизации
            }
            else
            {
                MessageBox.Show("Ошибка авторизации!");
            }

        }
        public static bool IsUserValid(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // SQL запрос для проверки данных пользователя
                    string query = "SELECT COUNT(*) FROM Сотрудники WHERE Логин = @login AND Пароль = @password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);

                    // Выполнение запроса и получение результата
                    int count = (int)command.ExecuteScalar();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при подключении к базе данных: " + ex.Message);
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

        private void Авторизация_Load(object sender, EventArgs e)
        {

        }
        /*private bool RegisterUser(string login, string password)
{
   using (SqlConnection connection = new SqlConnection(connectionString))
   {
       try
       {
           connection.Open();
           // SQL запрос для добавления нового пользователя
           string query = "INSERT INTO Users (Логин, Пароль) VALUES (@login, @password)";
           SqlCommand command = new SqlCommand(query, connection);


           command.Parameters.AddWithValue("@login", login);
           command.Parameters.AddWithValue("@password", password);

           // Выполнение запроса
           int rowsAffected = command.ExecuteNonQuery();
           return rowsAffected > 0;
       }
       catch (Exception ex)
       {
           MessageBox.Show("Ошибка при регистрации пользователя: " + ex.Message);
           return false;
       }
   }
}*/
    }
}
