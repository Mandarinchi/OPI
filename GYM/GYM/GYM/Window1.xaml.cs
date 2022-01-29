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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string g = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public Window1()
        {
            InitializeComponent();
        }
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
            int integer = 0;
            if (delt.Text != "")
            {
                DataTable dtbase = Select("SELECT * FROM [dbo].[Boss_of_the_GYM]");
                SqlConnection con = new SqlConnection(g);
                con.Open();
                for (int i = 0; i < dtbase.Rows.Count; i++)
                {
                    if (dtbase.Rows[i][2].ToString() == delt.Text)
                    {
                        integer = Convert.ToInt32(dtbase.Rows[i][0]);
                    }
                   
                }
                string das = ($"UPDATE Klient SET IDD_OF_Boss_of_the_GYM = NULL WHERE IDD_OF_Boss_of_the_GYM = {integer}");
                SqlCommand cmd = new SqlCommand(das, con);
                cmd.ExecuteNonQuery();
               con.Close();
               // DataTable dtbase1 = Select("SELECT * FROM [dbo].[Boss_of_the_GYM]");
                SqlConnection conn = new SqlConnection(g);
                conn.Open();
                string dass = $"DELETE  FROM [dbo].[Boss_of_the_GYM] WHERE IDD_OF_Boss_of_the_GYM={integer}";
                SqlCommand cmdd = new SqlCommand(dass, conn);
                cmdd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Успешная удаление", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
        }
    }
}
