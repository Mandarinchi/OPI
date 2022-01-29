using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace GYM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Boss_of_the_GYM
    {
        public string _fio;
        public int _id;
        public int _age;
        public string _gender;

        public string FIO
        { get; set; }
        public int Id
        { get; set; }
        public int Age
        { get; set; }
        public string Gender
        { get; set; }
    }
    public class Klient
    {
        public string _fio;
        public int _id;
        public int _age;
        public string _gender;


        public string FIO
        { get; set; }
        public int Id
        { get; set; }
        public int Age
        { get; set; }
        public string Gender
        { get; set; }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            DataTable dtbase = Select("SELECT * FROM [dbo].[Boss_of_the_GYM]");
            for (int i = 0; i < dtbase.Rows.Count; i++)
            {

                List<Boss_of_the_GYM> BOSSES = new List<Boss_of_the_GYM>
                {

                 new Boss_of_the_GYM {Id = Convert.ToInt32(dtbase.Rows[i][0]),  Age = Convert.ToInt32(dtbase.Rows[i][1]), FIO = Convert.ToString(dtbase.Rows[i][2]), Gender = Convert.ToString(dtbase.Rows[i][3])}};

                BOSS.Items.Add(BOSSES);


            }
            ////////////////////////////////
            DataTable dtbase1 = Select("SELECT * FROM [dbo].[Klient]");
            for (int i = 0; i < dtbase1.Rows.Count; i++)
            {

                List<Klient> klients = new List<Klient>
                {

                 new Klient {Id = Convert.ToInt32(dtbase1.Rows[i][0]),  Age = Convert.ToInt32(dtbase1.Rows[i][1]), FIO = Convert.ToString(dtbase1.Rows[i][2]), Gender = Convert.ToString(dtbase1.Rows[i][3])}};

                Klients.Items.Add(klients);
                

            }
        }
        static string connection_string = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //public string connectionString = @" Data Source = LENOVAIDEAPAD;Initial Catalog = BAZASHOP; Integrated Security = True";
        public DataTable Select(string selectSQL)// функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("");// создаём таблицу в приложении                                                                  // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection(connection_string);
            sqlConnection.Open();// открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();// создаём команду
            sqlCommand.CommandText = selectSQL;// присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);// создаём обработчик
            sqlDataAdapter.Fill(dataTable);// возращаем таблицу с результатом
            return dataTable;
        }
        private void BOSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {          
        }

        private void Klient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dtbase = Select("SELECT * FROM [dbo].[Boss_of_the_GYM]");
            DataTable dtbase1 = Select("SELECT * FROM [dbo].[Klient]");
            
            
            Klients.Items.Clear();
            int id = 0;
            for (int i = 0; i < dtbase.Rows.Count; i++)
            {
                if (Search.Text.Contains(dtbase.Rows[i][2].ToString()))
                {
                    id = Convert.ToInt32(dtbase.Rows[i][0]);
                }
            }
            for (int i = 0; i < dtbase1.Rows.Count; i++)
            {
                string per = "";
                //per = Convert.ToString(dtbase.Rows[i][2]);
                if (id == Convert.ToInt32(dtbase1.Rows[i][4]))
                {
                    

                    {
                        List<Klient> klients = new List<Klient>
                        {

                        new Klient {Id = Convert.ToInt32(dtbase1.Rows[i][0]),  Age = Convert.ToInt32(dtbase1.Rows[i][1]), FIO = Convert.ToString(dtbase1.Rows[i][2]), Gender = Convert.ToString(dtbase1.Rows[i][3])}
                        };

                        Klients.Items.Add(klients);
                    }
                        
                    
                }
            }
           
                
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Kli s = new Kli();
            s.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Trenier s = new Trenier();
            s.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Klients.Items.Clear();
            BOSS.Items.Clear();
            DataTable dtbase = Select("SELECT * FROM [dbo].[Boss_of_the_GYM]");
            for (int i = 0; i < dtbase.Rows.Count; i++)
            {

                List<Boss_of_the_GYM> BOSSES = new List<Boss_of_the_GYM>
                {

                 new Boss_of_the_GYM {Id = Convert.ToInt32(dtbase.Rows[i][0]),  Age = Convert.ToInt32(dtbase.Rows[i][1]), FIO = Convert.ToString(dtbase.Rows[i][2]), Gender = Convert.ToString(dtbase.Rows[i][3])}};

                BOSS.Items.Add(BOSSES);


            }
            ////////////////////////////////
            DataTable dtbase1 = Select("SELECT * FROM [dbo].[Klient]");
            for (int i = 0; i < dtbase1.Rows.Count; i++)
            {

                List<Klient> klients = new List<Klient>
                {

                 new Klient {Id = Convert.ToInt32(dtbase1.Rows[i][0]),  Age = Convert.ToInt32(dtbase1.Rows[i][1]), FIO = Convert.ToString(dtbase1.Rows[i][2]), Gender = Convert.ToString(dtbase1.Rows[i][3])}};

                Klients.Items.Add(klients);


            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window1 s = new Window1();
            this.Hide();
            s.ShowDialog();
            //DataTable dtbase = Select("SELECT * FROM [dbo].[Boss_of_the_GYM]");
            //SqlConnection con = new SqlConnection(connection_string);
            //con.Open();
            //string das = "DELETE  FROM [dbo].[Boss_of_the_GYM] WHERE IDD_OF_Boss_of_the_GYM=1";
            //SqlCommand cmd = new SqlCommand(das, con);
            //cmd.ExecuteNonQuery();
            //con.Close();
            //MessageBox.Show("Успешное удаление", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
    }
}
