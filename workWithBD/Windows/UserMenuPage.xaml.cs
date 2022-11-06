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
    /// Interaction logic for UserMenuPage.xaml
    /// </summary>
    public partial class UserMenuPage : Page
    {
        public UserMenuPage(string Login = "noKnown")
        {
            InitializeComponent();
            UserName.Text = "Ваш логин " + Login;
        }
    }
}
