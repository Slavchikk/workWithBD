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

namespace workWithBD.Windows
{
    /// <summary>
    /// Interaction logic for AdminMenuPage.xaml
    /// </summary>
    public partial class AdminMenuPage : Page
    {
        string Login;
        public AdminMenuPage(string Login = "noKnown")
        {
            this.Login = Login;
            InitializeComponent();
            AdminName.Text = "Ваш логин:  " + Login;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_go_admin(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage(Login));
        }

        private void Btn_go_list(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListViewTable(Login));
        }
    }
}
