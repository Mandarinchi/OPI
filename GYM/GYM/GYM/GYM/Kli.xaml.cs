using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GYM
{
    /// <summary>
    /// Interaction logic for Kli.xaml
    /// </summary>
    public partial class Kli : Window
    {
        public Kli()
        {
            InitializeComponent();
           
            DataTable dtbase = Select("SELECT * FROM [dbo].[Boss_of_the_GYM]");
            SqlConnection con = new SqlConnection(g);
            con.Open();
            for (int i = 0; i < dtbase.Rows.Count; i++)
            {
                CMBOX.Items.Add(dtbase.Rows[i][0].ToString() +" "+ dtbase.Rows[i][2].ToString());
            }
            
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
            if (FIO_Klient.Text != "" && Age_Klient.Text != "" && Gender_Klient.Text != "")
            {
                string s1 = CMBOX.SelectedItem.ToString();
                string ss = s1.Substring(0, 1);
                DataTable dtbase = Select("SELECT * FROM [dbo].[Klient]");
                SqlConnection con = new SqlConnection(g);
                con.Open();
                string das = "insert into [dbo].[Klient](Age_of_Klient,FIO_of_Klient,Gender,IDD_OF_Boss_of_the_GYM)values('" + Age_Klient.Text + "', '" + FIO_Klient.Text + "','" + Gender_Klient.Text + "','" + Convert.ToInt32(ss) + "')";
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
