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
using workWithBD.Windows;

namespace workWithBD
{

    //для админа admin admin
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Base.EM = new Entities1();
           
            // FrameClass.FrameMain = MainFrame;
            // FrameClass.FrameMain.Navigate(new AutorizationPage());
        }
        private void Btn_Go_reg(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RegistrPage());
            


        }

        private void Btn_Go_Admin(object sender, RoutedEventArgs e)
        {
            // FrameClass.FrameMain.Navigate(new AdminPage());
            MainFrame.Navigate(new AutorizationPage());
        }
    }
}
