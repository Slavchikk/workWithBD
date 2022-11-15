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
    /// Логика взаимодействия для AddTicket.xaml
    /// </summary>
    public partial class AddTicket : Page
    {

        Tickets Tick;  // объект, в котором будет хранится данные о новом или отредактированном коте
        bool flagUpdate = false; // для определения, создаем мы новый объект или редактируем старый
        string path;  // путь к картинке

        public void uploadFields()  // метод для заполнения списков
        {
            //cmbBreed.ItemsSource = BaseClass.tBE.BreedTable.ToList();
            //cmbBreed.SelectedValuePath = "idBreed";
            //cmbBreed.DisplayMemberPath = "Breed";

            //cmbGender.ItemsSource = BaseClass.tBE.GenderTable.ToList();
            //cmbGender.SelectedValuePath = "idGender";
            //cmbGender.DisplayMemberPath = "Gender";

            //lbTraits.ItemsSource = BaseClass.tBE.TraitTable.ToList();
            //lbTraits.SelectedValuePath = "idTrait";
            //lbTraits.DisplayMemberPath = "Trait";

            //lbFeed.ItemsSource = BaseClass.tBE.FeedTable.ToList();
        }

        // конструктор для редактирования данных о коте ( с аргументом, который хранит информацию о коте, которого хотим отредактировать)
        //public AddTicket(Tickets cat)
        //{
        //    InitializeComponent();
        //    uploadFields(); // заполняем списки
        //    flagUpdate = true;  // отметка о том, что кота редактируем
        //    CAT = cat;  // ассоциируем выше созданный глобавльный объект с объектом в кострукторе для дальнейшего редактирования этих данных
        //    tbName.Text = cat.CatName;  // вывод имени кота
        //    cmbBreed.SelectedIndex = cat.idBreed - 1;  // вывод породы кота
        //    dpBirthday.SelectedDate = cat.Birthday;  // вывод даты рождения 
        //    cmbGender.SelectedIndex = cat.idGender - 1;  // вывод пола
        //    tbPassport.Text = cat.PassportTable.UniqueNumber;  // вывод паспорта
        //    tbColor.Text = cat.PassportTable.ColorCat;  // вывод окраса

        //    // находим черты характера того кота, которого мы редактируем:
        //    List<TraitCat> tC = BaseClass.tBE.TraitCat.Where(x => x.idCat == cat.idCat).ToList();

        //    // цикл для выделения черт характера кота в общем списке:
        //    foreach (TraitTable t in lbTraits.Items)
        //    {
        //        if (tC.FirstOrDefault(x => x.idTrait == t.idTrait) != null)
        //        {
        //            lbTraits.SelectedItems.Add(t);
        //        }
        //    }

        //    // находим корма для того кота, которого мы редактируем
        //    List<FeedCatTable> fct = BaseClass.tBE.FeedCatTable.Where(x => x.idCat == cat.idCat).ToList();

        //    // цикл для отображения кормов и их количества для кота:
        //    foreach (FeedTable t in lbFeed.Items)
        //    {
        //        if (fct.FirstOrDefault(x => x.idFeed == t.idFeed) != null)
        //        {
        //            t.QM = fct.Count;
        //        }
        //    }

        //    // вывод картинки
        //    if (cat.Photo != null)
        //    {
        //        BitmapImage img = new BitmapImage(new Uri(cat.Photo, UriKind.RelativeOrAbsolute));
        //        photoCat.Source = img;
        //    }
        //}

        // конструктор для создания нового кота (без аргументов)
        public AddTicket()
        {
            InitializeComponent();
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
            //  uploadFields();  // заполняем списки
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                // если флаг равен false, то создаем объект для добавления кота
                if (flagUpdate == false)
                {
                    Tick = new Tickets();
                }
                // заполняем поля таблицы CatTable
                Tick.session = TBnameFilm.Text;
                Tick.id_session_time = TBSessionTime.SelectedIndex + 1;
                Tick.id_session_day = TBSessionDay.SelectedIndex + 1;
                Tick.id_halls = TBHalls.SelectedIndex + 1;
                Tick.id_type_tickets = TBTypeTicket.SelectedIndex+1;

                //List<sessions_time> TC = Base.EM.sessions_time.Where(x => x.sessions_time == TBSessionTime.SelectedIndex).ToList();
                int str = 0;


                //type tickets
                //foreach (Tickets tc in TC)
                //{
                //    str = tc.id_type_tickets;
                //}

                // если флаг равен false, то добавляем объект в базу
                if (flagUpdate == false)
                {
                    Base.EM.Tickets.Add(Tick);
                }
                // BaseClass.tBE.SaveChanges();


                //// Заполнение таблицы PassportTable
                //PassportTable pas = new PassportTable()
                //{
                //    idCat = Tick.idCat,
                //    UniqueNumber = tbPassport.Text,
                //    ColorCat = tbColor.Text
                //};

                //// если флаг равен false, то добавляем объект в базу
                //if (flagUpdate == false)
                //{
                //    BaseClass.tBE.PassportTable.Add(pas);
                //}
                ////    BaseClass.tBE.SaveChanges();

                //// Для заполнения таблицы TraitsCats нужно организовать цикл, так как черт характера у кота может быть несколько
                //// Цикл будет организовывать по чертам характера, которые выделены в списке

                //// находим список черт характера кота:
                //List<TraitCat> traits = BaseClass.tBE.TraitCat.Where(x => Tick.idCat == x.idCat).ToList();

                //// если список не пустой, удаляем из него все черты характера  этого кота
                //if (traits.Count > 0)
                //{
                //    foreach (TraitCat t in traits)
                //    {
                //        BaseClass.tBE.TraitCat.Remove(t);
                //    }
                //}

                //// перезаписываем черты кота (или добавляем черты для нового кота)
                //foreach (TraitTable t in lbTraits.SelectedItems)
                //{
                //    TraitCat TC = new TraitCat()  // объект для записи в таблицу TraitsCat
                //    {
                //        idCat = Tick.idCat,
                //        idTrait = t.idTrait
                //    };
                //    BaseClass.tBE.TraitCat.Add(TC);
                //}
                ////  BaseClass.tBE.SaveChanges();

                //// Для заполнения таблицы Diets нужно организовать цикл, так как кормов у кота может быть несколько
                //// Цикл будет организовывать по всем кормам, которые есть в списке

                //// находим список с кормами для кота
                //List<FeedCatTable> feed = BaseClass.tBE.FeedCatTable.Where(x => Tick.idCat == x.idCat).ToList();

                //// если список не пустой, удаляем из него все корма для  этого кота
                //if (feed.Count > 0)
                //{
                //    foreach (FeedCatTable t in feed)
                //    {
                //        BaseClass.tBE.FeedCatTable.Remove(t);
                //    }
                //}

                //// перезаписываем корма для кота (или добавляем корма для нового кота)
                //foreach (FeedTable f in lbFeed.Items)
                //{
                //    if (f.QM > 0)
                //    {
                //        FeedCatTable FCT = new FeedCatTable()  // объект для записи в таблицу FeedCatTable
                //        {
                //            idCat = Tick.idCat,
                //            idFeed = f.idFeed,
                //            Count = f.QM
                //        };
                //        BaseClass.tBE.FeedCatTable.Add(FCT);
                //    }
                //}
                Base.EM.SaveChanges();
                MessageBox.Show("Информация добавлена");
            }
            catch
            {
                MessageBox.Show("Что-то пошло не по плану");
            }
        }

    }
}
