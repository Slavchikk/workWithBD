using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class RegistrPage : Page
    {
        public RegistrPage()
        {
            InitializeComponent();
            CbGenderReg.ItemsSource = Base.EM.Genders.ToList();
            CbGenderReg.SelectedValuePath = "id_gender";
            CbGenderReg.DisplayMemberPath = "gender";
        }

        private void Btn_registration(object sender, RoutedEventArgs e)
        {
            string text = TbPasReg.Password.ToString();
            Regex regDigital = new Regex(@"(?=.{8,}$)(?=.*[a-z].*[a-z].*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()+=])(?=.*[0-9].*[0-9])");
            bool strEn = regDigital.Match(text).Success;
            int paswordCode = TbPasReg.Password.GetHashCode();
            users User = Base.EM.users.FirstOrDefault(z => z.login == TbLoginReg.Text);
            try
            {
                if (User != null)
                {
                    MessageBox.Show("Пользователь, с таким логином существует!");
                }


                else if (String.IsNullOrEmpty(TbNameReg.Text) || String.IsNullOrEmpty(TbLoginReg.Text) || String.IsNullOrEmpty(TbLastnameReg.Text) || String.IsNullOrEmpty(TbSurnameReg.Text) || String.IsNullOrEmpty(DPBirthday.Text) || String.IsNullOrEmpty(CbGenderReg.Text))
                { MessageBox.Show("Не введено поле"); }





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
                    if (!regSimvols ) errors += " Должен быть специальный символ. \n";
                    if (!regLowSimvs ) errors += "Должно быть не менее 3 латинских символов. \n";
                    if (!regUpSimvs) errors += " Должен быть хотя бы один заглавный латинский символ. \n";
                    if (counterNum < 2) errors += " Должно быть не менее 2 цифр \n";
                    
                    MessageBox.Show(errors);
                }
            else 
                {
                    int pasGegCode = TbPasReg.Password.GetHashCode();
                    users UserRez = new users() { name = TbNameReg.Text, surname = TbSurnameReg.Text, lastname = TbLastnameReg.Text, login = TbLoginReg.Text, password = pasGegCode, birthday = DPBirthday.SelectedDate.Value.Date, id_gender = CbGenderReg.SelectedIndex + 1, id_role = 2 };
                    Base.EM.users.Add(UserRez);
                    Base.EM.SaveChanges();

                    MessageBox.Show("Пользователь зарегестрирован");
                }
            }
            catch
            {
                MessageBox.Show("Данные введены не полностью");
            }
        }
    }
}
