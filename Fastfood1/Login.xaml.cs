using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;

namespace Fastfood1
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        SqlConnection con;
        public Login()
        {
            InitializeComponent();
            Connect connect =   new Connect();
            connect.getConnection();            
        }

        private void clear_Click_1(object sender, RoutedEventArgs e)
        {
            employeeID.Clear();
            password.Clear();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            String empID = employeeID.Text;
            String pass = password.Password;

            if(string.IsNullOrEmpty(empID))
            {
                error.Content = "Please enter your ID";
                error.Visibility = Visibility.Visible;
            }
            else if (string.IsNullOrEmpty(pass))
            {
                error.Visibility = Visibility.Visible;
                error.Content = "Please enter Password";
            }
            else
            {
                error.Visibility = Visibility.Hidden;
                Connect.con.Open();
                String query = "SELECT * FROM Employee where EmployeeID=" + empID + " and Password='" + pass + "'";
                SqlCommand cmd = new SqlCommand(query, Connect.con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr[4].ToString() == "Admin")
                    {
                        Admin admin = new Admin();
                        admin.Show();
                        this.Close();

                    }
                    else if(dr[4].ToString()=="Staff")
                    //MessageBox.Show("Login Success");
                    {
                        Food food = new Food();
                        food.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Username or Password incorrect");
                }
                Connect.con.Close();
            }
        }

        
    }
}
