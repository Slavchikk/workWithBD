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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace workWithBD.Windows
{
    /// <summary>
    /// Interaction logic for AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public AutorizationPage()
        {
            InitializeComponent();
            
        }

        private void Btn_auto(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            int paswordCode = TbPasAvto.Password.GetHashCode();
            users User = Base.EM.users.FirstOrDefault(z => z.login == TbLoginAvto.Text);
            if (User == null)
            {
                MessageBox.Show("Вы не зарегистрированы");
            }
            User = Base.EM.users.FirstOrDefault(z => z.login == TbLoginAvto.Text && z.password == paswordCode);
            if(User == null)
                MessageBox.Show("Пароль введен неверно");
            else
            {
                switch (User.id_role)
                {
                    case 1:
                        MessageBox.Show("Здравствуйте, администратор " + User.name);
                        // переход в меню администратора
                      NavigationService.Navigate(new AdminMenuPage(User));
                        break;
                    case 2:
                        MessageBox.Show("Здравствуйте, пользователь " + User.name);
                        NavigationService.Navigate(new UserMenuPage(User));  // переход в личный кабинет
                        break;
                }
            }
        }
    }
}
