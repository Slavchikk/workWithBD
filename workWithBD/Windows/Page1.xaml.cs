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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            CbGenderReg.ItemsSource = Base.EM.Genders.ToList();
            CbGenderReg.SelectedValuePath = "id_gender";
            CbGenderReg.DisplayMemberPath = "genger";
        }

        private void Btn_registration(object sender, RoutedEventArgs e)
        {
            int pasGegCode = TbPasReg.Password.GetHashCode();
            users UserRez = new users() { Name = TbNameReg.Text, Surname = TbSurnameReg.Text, Login = TbLoginReg.Text, Password = pasGegCode, IDGender = CbGenderReg.SelectedIndex + 1, IDRole = 2 };
            Base.EM.Users.Add(UserRez);
            BaseClass.Base.SaveChanges();
            MessageBox.Show("Вы зарегистрированы");
        }
    }
}
