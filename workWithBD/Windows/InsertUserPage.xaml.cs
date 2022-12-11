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
    /// Interaction logic for InsertUserPage.xaml
    /// </summary>
    public partial class InsertUserPage : Page
    {
        users user;

        public InsertUserPage(users user)
        {
            InitializeComponent();
            tbGender.ItemsSource = Base.EM.Genders.ToList();
            tbGender.SelectedValuePath = "id_gender";
            tbGender.DisplayMemberPath = "gender";

            this.user = user;  // заполняем выше созданный объект информацией об авторизованном пользователе
            tbName.Text = user.name;  // заполняем поле с именем
            tbSurname.Text = user.surname;
            tbLastname.Text = user.lastname;
            tbBirthday.Text = user.birthday.ToString("dd.MM.yyyy");
            tbGender.SelectedIndex = user.id_gender - 1;

        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            try { 
            user.name = tbName.Text;
            user.lastname = tbLastname.Text;
            user.surname = tbSurname.Text;
            user.birthday = Convert.ToDateTime(tbBirthday.Text);
            user.id_gender = tbGender.SelectedIndex + 1;
            Base.EM.SaveChanges();

            System.Windows.MessageBox.Show("Информация добавлена");
        }

            catch
            {
                System.Windows.MessageBox.Show("Что-то пошло не по плану");
            }
}

        private void Button_back(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserMenuPage(user));
        }
    }
}
