using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace GYM
{
    /// <summary>
    /// Interaction logic for Trenier.xaml
    /// </summary>
    public partial class Trenier : Window
    {
        public Trenier()
        {
            InitializeComponent();
        }
        string g = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public DataTable Select(string selectSQL)// функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("");// создаём таблицу в приложении                                                                  // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection(g);
            sqlConnection.Open();// открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();// создаём команду
            sqlCommand.CommandText = selectSQL;// присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);// создаём обработчик
            sqlDataAdapter.Fill(dataTable);// возращаем таблицу с результатом
            return dataTable;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FIO_trainer.Text != "" && Age_trainer.Text != "" && Gender_trainer.Text != "")
            {
                DataTable dtbase = Select("SELECT * FROM [dbo].[Boss_of_the_GYM]");
                SqlConnection con = new SqlConnection(g);
                con.Open();
                string das = "insert into [dbo].[Boss_of_the_GYM](Age_of_Boss_of_the_GYM,FIO_of_Boss_of_the_GYM,Gender)values('" + Age_trainer.Text + "', '" + FIO_trainer.Text + "','" + Gender_trainer.Text + "')";
                SqlCommand cmd = new SqlCommand(das, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Успешная запись", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBox.Show("Неверный ввод", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
