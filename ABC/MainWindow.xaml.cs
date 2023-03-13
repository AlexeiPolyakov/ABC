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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibrary1;

namespace ABC
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            using(var db = new DBContext())
            {
                db.Database.Delete();
                db.Database.Create();
            }
            InitializeComponent();
            User.CreateAdmin();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = User.LogIn(login_123.Text, password_123.Password);
            if (user == null) MessageBox.Show("Неверный логин или пароль");
            else
            {
                Hide();
                Log log = new Log();
                log.ShowDialog();
                Show();
            }
        }
    }
}
