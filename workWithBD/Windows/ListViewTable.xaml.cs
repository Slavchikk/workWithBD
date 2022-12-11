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
    /// Interaction logic for ListViewTable.xaml
    /// </summary>
    public partial class ListViewTable : Page
    {
        users user;
        List<Tickets> tickets;
        Pagination pagination = new Pagination();
        public ListViewTable(users user)
        {
            this.user = user;
            InitializeComponent();
            tickets = Base.EM.Tickets.ToList();
            listTable.ItemsSource = Base.EM.Tickets.ToList();
            TBTypeTicket.ItemsSource = Base.EM.type_tickets.ToList();
            TBTypeTicket.SelectedValuePath = "id_type_ticket";
            TBTypeTicket.DisplayMemberPath = "type_ticket";
            //  listTable.ItemsSource = Base.EM.Tickets.ToList();
            pagination.CountPage = tickets.Count;
            DataContext = pagination;
        }

        private void tbCharacter_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;  // получаем доступ к TextBlock из шаблона
            int index = Convert.ToInt32(tb.Uid);  // получаем числовой Uid элемента списка (в разметке предварительно нужно связать номер ячейки с номером кота в базе данных)

            List<sales> TC = Base.EM.sales.Where(x => x.id_tickets == index).ToList();

           
            int str = 0;
            foreach (sales tc in TC)
            {
                str = tc.id_halls;
            }

            List<Halls> hc = Base.EM.Halls.Where(x => x.id_halls == str).ToList();

            string halls = "";

            foreach(Halls hcc in hc)
            {
                halls = hcc.halls1;
            }

            tb.Text = "Зал: " + halls;  // вывод черт характера на экран
        }

        private void tbCharacter_LoadedCount(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;  // получаем доступ к TextBlock из шаблона
            int index = Convert.ToInt32(tb.Uid);  // получаем числовой Uid элемента списка (в разметке предварительно нужно связать номер ячейки с номером кота в базе данных)

            List<sales> TC = Base.EM.sales.Where(x => x.id_tickets == index).ToList();

            int str = 0;
            foreach (sales tc in TC)
            {
                str = Convert.ToInt32( tc.count);
            }


            tb.Text = "Продано билетов: " + str;  // вывод черт характера на экран
        }

       

        private void tbCharacter_LoadedType(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;  // получаем доступ к TextBlock из шаблона
            int index = Convert.ToInt32(tb.Uid);  // получаем числовой Uid элемента списка (в разметке предварительно нужно связать номер ячейки с номером кота в базе данных)
           List<sales> TC = Base.EM.sales.Where(x => x.id_tickets == index).ToList();
            int str = 0;
            foreach (sales tc in TC)
            {
                str = tc.id_halls;
            }
            List<Halls> hc = Base.EM.Halls.Where(x => x.id_halls == str).ToList();
            int halls = 0;
            foreach (Halls hcc in hc)
            {
                halls = hcc.id_type_halls;
            }
            List<type_halls> TH = Base.EM.type_halls.Where(x => x.id_type_halls == halls).ToList();
            string typehal = "";
            foreach (type_halls th in TH)
            {
                typehal = th.type_halls1;
            }
            tb.Text = "Тип зала: " + typehal;  // вывод черт характера на экран
        }

        private void tbCharacter_LoadedPrice(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;  // получаем доступ к TextBlock из шаблона
            int index = Convert.ToInt32(tb.Uid);  // получаем числовой Uid элемента списка (в разметке предварительно нужно связать номер ячейки с номером кота в базе данных)
            
            
            List<Tickets> TC = Base.EM.Tickets.Where(x => x.id_ticket == index).ToList();
            int str = 0;


            //type tickets
            foreach (Tickets tc in TC)
            {
                str = tc.id_type_tickets;
            }


            List<type_tickets> TT = Base.EM.type_tickets.Where(x => x.id_type_ticket == str).ToList();
            int countTypeTickets = 0;

            foreach (type_tickets tc in TT)
            {
                countTypeTickets = tc.cost_premium;
            }

            //session day
            foreach (Tickets tc in TC)
            {
                str = tc.id_session_day;
            }
            List<sessions_days> SD = Base.EM.sessions_days.Where(x => x.id_session_day == str).ToList();

            int countSessionDay = 0;

            foreach(sessions_days sd in SD)
            {
                countSessionDay = sd.cost_premium;
            }

            // session time
            foreach (Tickets tc in TC)
            {
                str = tc.id_session_time;
            }
            List<sessions_time> ST = Base.EM.sessions_time.Where(x => x.id_session_time == str).ToList();

            int countSessionTime = 0;

            foreach (sessions_time sd in ST)
            {
                countSessionTime = sd.cost_premium;
            }
            // hallss

            List<sales> sal = Base.EM.sales.Where(x => x.id_tickets == index).ToList();
            int idHal = 0;
            foreach (sales tc in sal)
            {
                idHal = tc.id_halls;
            }
            List<Halls> hc = Base.EM.Halls.Where(x => x.id_halls == idHal).ToList();
            int halls = 0;
            foreach (Halls hcc in hc)
            {
                halls = hcc.id_type_halls;
            }
            List<type_halls> TH = Base.EM.type_halls.Where(x => x.id_type_halls == halls).ToList();
            int countTypeHal =0;
            foreach (type_halls th in TH)
            {
                countTypeHal = th.cost_premium;
            }


            int price = (int)countTypeTickets * countSessionDay * countSessionTime * countTypeHal * 30;

            tb.Text = "Цена: " + price;
        }

        private void Btn_back_menu(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new AdminMenuPage(user));
        }

        private void btnCreateTickets_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateOrUpdateTickets());
        }

        private void btn_Delete(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender; // задаем кнопке имя
            int ind = Convert.ToInt32(B.Uid); // считываем индекс кнопки, который соответсвует id кота
            sales salest = Base.EM.sales.FirstOrDefault(y => y.id_tickets == ind);
            Base.EM.sales.Remove(salest);
            Tickets TicketsDelete = Base.EM.Tickets.FirstOrDefault(y => y.id_ticket == ind); // находим кота с соответствующим индексом
            Base.EM.Tickets.Remove(TicketsDelete);  // удаляем кота
            Base.EM.SaveChanges();
            NavigationService.Navigate(new ListViewTable(user));  // перезагружаем страницу, переходя на нее же саму
            MessageBox.Show("Запись удалена");
        }

        private void btn_update(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;  // задаем кнопке имя
            int ind = Convert.ToInt32(B.Uid);  // считываем индекс кнопки, который соответсвует id кота
            Tickets TicketsUpd = Base.EM.Tickets.FirstOrDefault(y => y.id_ticket == ind);
            // находим кота с соответствующим индексом

            sales salesupd = Base.EM.sales.FirstOrDefault(x => x.id_tickets == TicketsUpd.id_ticket);
            NavigationService.Navigate(new CreateOrUpdateTickets(TicketsUpd,salesupd,user));  // переходим на страницу с формой добавления, которую будем использовать и для редактирования
            // Обратите внимание, что конструктор в этом случае не пустой. Он содержит того кота, который соотвествует нужному индексу
        }

        private void SortOrFilt()
        {

            listTable.ItemsSource = Base.EM.Tickets.ToList();
            tickets = Base.EM.Tickets.ToList();
         
            
            if (!string.IsNullOrWhiteSpace(TbFind.Text))
            {
                listTable.ItemsSource = tickets.Where(x => x.session.ToLower().Contains(TbFind.Text.ToLower())).ToList();
            }
            if (TBTypeTicket.SelectedIndex != -1)
            {
                switch(TBTypeTicket.SelectedIndex)
                {
                    case 0:
                      listTable.ItemsSource = tickets.Where(x => x.id_type_tickets == TBTypeTicket.SelectedIndex + 1).ToList();
                        break;
                    case 1:
                        listTable.ItemsSource = tickets.Where(x => x.id_type_tickets == TBTypeTicket.SelectedIndex + 1).ToList();
                        break;
                    case 2:
                        listTable.ItemsSource = tickets.Where(x => x.id_type_tickets == TBTypeTicket.SelectedIndex + 1).ToList();
                        break;
                    case 3:
                        listTable.ItemsSource = tickets.Where(x => x.id_type_tickets == TBTypeTicket.SelectedIndex + 1).ToList();
                        break;
                    case 4:
                        listTable.ItemsSource = tickets.Where(x => x.id_type_tickets == TBTypeTicket.SelectedIndex + 1).ToList();
                        break;

                }
              


            }

            
            if ((CBSort.SelectedIndex != -1) && (CBCrit.SelectedIndex != -1))
            {
                switch (CBCrit.SelectedIndex)
                {
                    case 0:
                        if (CBSort.SelectedIndex == 0)
                        {
                            listTable.ItemsSource = tickets.OrderBy(x => x.session).ToList();
                        }
                        else
                        {
                            listTable.ItemsSource = tickets.OrderByDescending(x => x.session).ToList();
                        }
                        break;
                    case 1:
                        if (CBSort.SelectedIndex == 0)
                        {
                            listTable.ItemsSource = tickets.OrderBy(x => x.price).ToList();
                        }
                        else
                        {
                            listTable.ItemsSource = tickets.OrderByDescending(x => x.price).ToList();
                        }
                        break;
                    case 2:
                        if (CBSort.SelectedIndex == 0)
                        {
                            listTable.ItemsSource = tickets.OrderBy(x => x.DateTime).ToList();
                        }
                        else
                        {
                            listTable.ItemsSource = tickets.OrderByDescending(x => x.DateTime).ToList();
                        }
                        break;
                }
            }
            if(tickets.Count>0)
            {
                pagination.CurrentPage = 1;

                try
                {
                    pagination.CountPage = Convert.ToInt32(txtPageCount.Text); // если в текстовом поле есnь значение, присваиваем его свойству объекта, которое хранит количество записей на странице
                }
                catch
                {
                    pagination.CountPage = tickets.Count; // если в текстовом поле значения нет, присваиваем свойству объекта, которое хранит количество записей на странице количество элементов в списке
                }
                pagination.Countlist = tickets.Count;  // присваиваем новое значение свойству, которое в объекте отвечает за общее количество записей
                listTable.ItemsSource = tickets.Skip(0).Take(pagination.CountPage).ToList();  // отображаем первые записи в том количестве, которое равно
            }
        }

        private void cbCrit_Chang(object sender, SelectionChangedEventArgs e)
        {
            SortOrFilt();
        }

        private void cbSort_Chang(object sender, SelectionChangedEventArgs e)
        {
            SortOrFilt();

        }

        private void tx_chang(object sender, TextChangedEventArgs e)
        {
            SortOrFilt();
        }

        private void cbFiltr_Chang(object sender, SelectionChangedEventArgs e)
        {
            SortOrFilt();
        }

        private void GoPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;

            switch (tb.Uid)  // определяем, куда конкретно было сделано нажатие
            {
                case "prev":
                    pagination.CurrentPage--;
                    break;
                case "next":
                    pagination.CurrentPage++;
                    break;
                default:
                    pagination.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }
            listTable.ItemsSource = tickets.Skip(pagination.CurrentPage * pagination.CountPage - pagination.CountPage).Take(pagination.CountPage).ToList();  // оображение 
        }

        private void txtPageCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            SortOrFilt();
        }
    }
}
