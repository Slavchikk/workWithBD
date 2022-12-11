using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace workWithBD.Windows
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        string texts;

        users user;
        public AdminPage(users user)
        {
            this.user = user;
            InitializeComponent();
            var query =
                from users in Base.EM.users.ToList()
                join Genders in Base.EM.Genders.ToList()
                on users.id_gender equals
                Genders.id_gender
                where users.id_role == 2
                orderby users.id_user
                select new { users.name, users.surname, users.lastname, Genders.gender, users.login, users.birthday };

            DgUsers.ItemsSource = query.ToList();
        }
       

       private void Btn_sort_asc(object sender, RoutedEventArgs e)
        {

           
                var query =
                    from users in Base.EM.users.ToList()
                    join Genders in Base.EM.Genders.ToList()
                    on users.id_gender equals
                    Genders.id_gender
                    where users.id_role == 2
                    orderby users.surname
                    select new { users.name, users.surname, users.lastname, Genders.gender, users.login, users.birthday };

                DgUsers.ItemsSource = query.ToList();
            
        }

        private void Btn_sotr_default(object sender, RoutedEventArgs e)
        {
            
            var query =
               from users in Base.EM.users.ToList()
               join Genders in Base.EM.Genders.ToList()
               on users.id_gender equals
               Genders.id_gender
               where users.id_role == 2
               orderby users.id_user
               select new { users.name, users.surname, users.lastname, Genders.gender, users.login, users.birthday };
            
            DgUsers.ItemsSource = query.ToList();
        }

        private void Btn_find(object sender, RoutedEventArgs e)
        {
            
            texts = TbFind.Text;
            switch (CBchoise.SelectedIndex)
            {
                case 0:
                    
                        var  query =
                         from users in Base.EM.users.ToList()
                         join Genders in Base.EM.Genders.ToList()
                         on users.id_gender equals
                         Genders.id_gender
                         where users.id_role == 2
                         where users.name.StartsWith($"{texts}")
                         orderby users.id_user
                         select new { users.name, users.surname, users.lastname, Genders.gender, users.login, users.birthday };
                         DgUsers.ItemsSource = query.ToList();
                    break;
                case 1:

                         query =
                         from users in Base.EM.users.ToList()
                         join Genders in Base.EM.Genders.ToList()
                         on users.id_gender equals
                         Genders.id_gender
                         where users.id_role == 2
                         where users.surname.StartsWith($"{texts}")
                         orderby users.id_user
                         select new { users.name, users.surname, users.lastname, Genders.gender, users.login, users.birthday };
                        DgUsers.ItemsSource = query.ToList();
                    break;
            }
        }


        private void Btn_sort_desc(object sender, RoutedEventArgs e)
        {
           
                var query =
                    from users in Base.EM.users.ToList()
                    join Genders in Base.EM.Genders.ToList()
                    on users.id_gender equals
                    Genders.id_gender
                    where users.id_role == 2
                    orderby users.surname descending
                    select new { users.name, users.surname, users.lastname, Genders.gender, users.login, users.birthday };

                DgUsers.ItemsSource = query.ToList();
            
        }

        private void CBMan_Checked(object sender, RoutedEventArgs e)
        {
            CBWomen.IsChecked = false;
            var query =
                   from users in Base.EM.users.ToList()
                   join Genders in Base.EM.Genders.ToList()
                   on users.id_gender equals
                   Genders.id_gender
                   where users.id_role == 2
                   where users.id_gender ==1
                   orderby users.id_user
                   select new { users.name, users.surname, users.lastname, Genders.gender, users.login, users.birthday };

            DgUsers.ItemsSource = query.ToList();
        }

        private void CBWoman_Checked(object sender, RoutedEventArgs e)
        {
            CBMen.IsChecked = false;
            var query =
                   from users in Base.EM.users.ToList()
                   join Genders in Base.EM.Genders.ToList()
                   on users.id_gender equals
                   Genders.id_gender
                   where users.id_role == 2
                   where users.id_gender == 2
                   orderby users.id_user
                   select new { users.name, users.surname, users.lastname, Genders.gender, users.login, users.birthday };

            DgUsers.ItemsSource = query.ToList();
        }

        private void Btn_back_menu(object sender, RoutedEventArgs e)
        {
       
           
            NavigationService.Navigate(new AdminMenuPage(user));
        }
    }
}
