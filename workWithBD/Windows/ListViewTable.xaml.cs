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
    /// Interaction logic for ListViewTable.xaml
    /// </summary>
    public partial class ListViewTable : Page
    {
        string Login;
        public ListViewTable(string Login = "noKnown")
        {
            this.Login = Login;
            InitializeComponent();
            listTable.ItemsSource = Base.EM.Tickets.ToList();
          //  listTable.ItemsSource = Base.EM.Tickets.ToList();
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
            
            NavigationService.Navigate(new AdminMenuPage(Login));
        }
    }
}
