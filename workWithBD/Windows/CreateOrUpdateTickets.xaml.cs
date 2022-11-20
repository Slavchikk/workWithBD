using System;
using Xceed.Wpf.Toolkit;
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
    /// Логика взаимодействия для AddTicket.xaml
    /// </summary>
    public partial class CreateOrUpdateTickets : Page
    {

        
        Tickets tick;
        sales sls;// объект, в котором будет хранится данные о новом или отредактированном коте
        bool flagUpdate = false;  // для определения, создаем мы новый объект или редактируем старый



        public void uploadFields()  // метод для заполнения списков
        {
            TBSessionTime.ItemsSource = Base.EM.sessions_time.ToList();
            TBSessionTime.SelectedValuePath = "id_session_time";
            TBSessionTime.DisplayMemberPath = "session_time";
            TBSessionDay.ItemsSource = Base.EM.sessions_days.ToList();
            TBSessionDay.SelectedValuePath = "id_session_day";
            TBSessionDay.DisplayMemberPath = "session_day";
            TBHalls.ItemsSource = Base.EM.Halls.ToList();
            TBHalls.SelectedValuePath = "id_halls";
            TBHalls.DisplayMemberPath = "halls1";
            TBTypeTicket.ItemsSource = Base.EM.type_tickets.ToList();
            TBTypeTicket.SelectedValuePath = "id_type_ticket";
            TBTypeTicket.DisplayMemberPath = "type_ticket";
        }


        // конструктор для создания нового кота (без аргументов)
        public CreateOrUpdateTickets()
        {
            InitializeComponent();

            uploadFields();  // заполняем списки

        }
        public CreateOrUpdateTickets(Tickets tickets,sales sales)
        {
            InitializeComponent();
            uploadFields(); // заполняем списки
            flagUpdate = true;
              tick = tickets;
            sls = sales;



            List<sales> TC = Base.EM.sales.Where(x => x.id_tickets == tickets.id_ticket).ToList();
            int str = 0;
      
            foreach (sales tc in TC)
            {
                str = Convert.ToInt32(tc.count);
                
            }
            List<Halls> hc = Base.EM.Halls.Where(x => x.id_halls == sls.id_halls).ToList();
            string halls = "";
            foreach (Halls hcc in hc)
            {
                halls = hcc.halls1;
            }
            DateTime dtr;
            dtr = new DateTime();
            foreach (sales tc in TC)
            {
                dtr = Convert.ToDateTime(tc.dateTime);
            }


            // ассоциируем выше созданный глобавльный объект с объектом в кострукторе для дальнейшего редактирования этих данных
            TBnameFilm.Text = tickets.session; // вывод имени кота
            TBHalls.Text = halls; // вывод породы кота
            TBSessionDay.SelectedIndex = tickets.id_session_day - 1;
            TBSessionTime.SelectedIndex = tickets.id_session_time - 1;
            TBTypeTicket.SelectedIndex = tickets.id_type_tickets - 1;
            TBDateTime.Text = dtr.ToString("dd.mm.yyyy hh:mm");
            TBSales.Text = "" + str;
            
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                
                // если флаг равен false, то создаем объект для добавления кота
                if (flagUpdate == false)
                {
                    tick = new Tickets();
                    sls = new sales();
                }
                // заполняем поля таблицы CatTable

                tick.session = TBnameFilm.Text;
                tick.id_session_time = TBSessionTime.SelectedIndex + 1;
                tick.id_session_day = TBSessionDay.SelectedIndex + 1;
                tick.id_type_tickets = TBTypeTicket.SelectedIndex + 1;

                if (flagUpdate == false)
                {
                    Base.EM.sales.Add(sls);
                }
                List<sales> TC = Base.EM.sales.Where(x => x.id_tickets == tick.id_ticket).ToList();
                int str = 0;
                foreach (sales tc in TC)
                {
                    str = tc.id_sales;
                }

                tick.id_halls = str;
                
                // если флаг равен false, то добавляем объект в базу
                if (flagUpdate == false)
                {
                    Base.EM.Tickets.Add(tick);
                }
                // BaseClass.tBE.SaveChanges();


                // если список не пустой, удаляем из него все корма для  этого кота

                // Заполнение таблицы PassportTable

                
                List<Halls> hc = Base.EM.Halls.Where(x => x.halls1 == TBHalls.Text).ToList();
                int halls = 0;
                foreach (Halls hcc in hc)
                {
                    halls = hcc.id_halls;
                }
                sls.id_tickets = tick.id_ticket;
                sls.id_halls = halls;
                sls.count = Convert.ToInt32(TBSales.Text);
                sls.dateTime = Convert.ToDateTime(TBDateTime.Text);
                List<sales> TCC = Base.EM.sales.Where(x => x.id_tickets == tick.id_ticket).ToList();
                int strr = 0;
                foreach (sales tc in TCC)
                {
                    strr = tc.id_sales;
                }

                tick.id_halls = strr;
                // если флаг равен false, то добавляем объект в базу

                //    BaseClass.tBE.SaveChanges();

                // Для заполнения таблицы TraitsCats нужно организовать цикл, так как черт характера у кота может быть несколько
                // Цикл будет организовывать по чертам характера, которые выделены в списке

                // находим список черт характера кота:

                //  BaseClass.tBE.SaveChanges();

                // Для заполнения таблицы Diets нужно организовать цикл, так как кормов у кота может быть несколько
                // Цикл будет организовывать по всем кормам, которые есть в списке

                // находим список с кормами для кота
                Base.EM.SaveChanges();
                
                System.Windows.MessageBox.Show("Информация добавлена");
            }

            catch
            {
                System.Windows.MessageBox.Show("Что-то пошло не по плану");
            }

        }
        private void Btn_back_list(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListViewTable());
        }
    }
}
