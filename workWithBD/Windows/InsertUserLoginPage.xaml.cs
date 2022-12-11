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
using System.Text.RegularExpressions;
namespace workWithBD.Windows
{
    /// <summary>
    /// Interaction logic for InsertUserLoginPage.xaml
    /// </summary>
    public partial class InsertUserLoginPage : Page
    {
        users user;
        public InsertUserLoginPage(users user)
        {
            InitializeComponent();

            this.user = user;

            tbLogin.Text = user.login;  
           
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            string text = tbPasswordNew.Password.ToString();
            Regex regDigital = new Regex(@"(?=.{8,}$)(?=.*[a-z].*[a-z].*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()+=])(?=.*[0-9].*[0-9])");
            bool strEn = regDigital.Match(text).Success;
            int paswordCodeNew = tbPasswordNew.Password.GetHashCode();
            

            int paswordCode = tbPassword.Password.GetHashCode();
            users User = Base.EM.users.FirstOrDefault(z => z.login == tbLogin.Text && z.password == paswordCode);
          
               
            try
            {
                   if (User == null)
                    MessageBox.Show("Старый пароль введен неверно");





                else if (strEn != true)
                {
                    Regex regSimvol = new Regex(@"(?=.*[!@#$%^&*()+=])");
                    Regex regLowSimv = new Regex(@"(?=.{8,}$)(?=.*[a-z].*[a-z].*[a-z])");
                    Regex regUpSimv = new Regex(@"(?=.{8,}$)(?=.*[A-Z])");
                    string errors = "";

                    int counterNum = 0;
                    bool result;
                    bool flag;
                    if (text.Length < 8) errors += "Общая длина пароля должна быть не менее 8 символов. \n";
                    for (int i = 0; i < text.Length; i++)
                    {


                        if (Char.IsDigit(text[i])) counterNum++;




                    }
                    bool regSimvols = regSimvol.Match(text).Success;
                    bool regLowSimvs = regLowSimv.Match(text).Success;
                    bool regUpSimvs = regUpSimv.Match(text).Success;
                    if (!regSimvols) errors += " Должен быть специальный символ. \n";
                    if (!regLowSimvs) errors += "Должно быть не менее 3 латинских символов. \n";
                    if (!regUpSimvs) errors += " Должен быть хотя бы один заглавный латинский символ. \n";
                    if (counterNum < 2) errors += " Должно быть не менее 2 цифр \n";

                    MessageBox.Show(errors);
                }
                else
                {
                    int pasGegCode = tbPasswordNew.Password.GetHashCode();
                    user.login = tbLogin.Text;
                    user.password = pasGegCode;
                    
                    Base.EM.SaveChanges();

                    MessageBox.Show("Пароль изменен");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Button_back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserMenuPage(user));
        }
    }
}
