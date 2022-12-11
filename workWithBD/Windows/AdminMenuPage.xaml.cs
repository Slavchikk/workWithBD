using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
//using System.Drawing;
using System.IO;
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
    /// Interaction logic for AdminMenuPage.xaml
    /// </summary>
    public partial class AdminMenuPage : Page
    {
        users user;

        void showImage(byte[] Barray, System.Windows.Controls.Image img)
        {
            BitmapImage BI = new BitmapImage();  // создаем объект для загрузки изображения
            using (MemoryStream m = new MemoryStream(Barray))  // для считывания байтового потока
            {
                BI.BeginInit();  // начинаем считывание
                BI.StreamSource = m;  // задаем источник потока
                BI.CacheOption = BitmapCacheOption.OnLoad;  // переводим изображение
                BI.EndInit();  // заканчиваем считывание
            }
            img.Source = BI;  // показываем картинку на экране (imUser – имя картиник в разметке)
            img.Stretch = Stretch.Uniform;
        }
        public AdminMenuPage(users user)
        {
            InitializeComponent();
            this.user = user;  // заполняем выше созданный объект информацией об авторизованном пользователе
            tbName.Text = user.name;  // заполняем поле с именем
            tbSurname.Text = user.surname;
            tbLastname.Text = user.lastname;
            tbBirthday.Text = user.birthday.ToString("dd.MM.yyyy");

            List<Genders> TC = Base.EM.Genders.Where(x => x.id_gender == user.id_gender).ToList();


            string str = "";
            foreach (Genders tc in TC)
            {
                str = tc.gender;
            }
            tbGender.Text = str;
            List<userphoto> u = Base.EM.userphoto.Where(x => x.id_user == user.id_user).ToList(); // для загрузки картинки находим все фото пользователя в таблице, где хранятся фото
            if (u != null)
                try// если список с фото не пустой, начинает переводить байтовый массив в изображение
                {

                    byte[] Bar = u[u.Count - 1].photo_binary;   // считываем изображение из базы (считываем байтовый массив двоичных данных) - выбираем последнее добавленное изображение
                    showImage(Bar, imUser);  // отображаем картинку
                }
                catch
                {

                }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InsertUserPage(user));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                userphoto u = new userphoto();  // создание объекта для добавления записи в таблицу, где хранится фото
                u.id_user = user.id_user;  // присваиваем значение полю idUser (id авторизованного пользователя)

                OpenFileDialog OFD = new OpenFileDialog();  // создаем диалоговое окно
                //OFD.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);  // выбор папки для открытия
                OFD.ShowDialog();  // открываем диалоговое окно             
                string path = OFD.FileName;  // считываем путь выбранного изображения
                System.Drawing.Image SDI = System.Drawing.Image.FromFile(path);  // создаем объект для загрузки изображения в базу
                ImageConverter IC = new ImageConverter();  // создаем конвертер для перевода картинки в двоичный формат
                byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));  // создаем байтовый массив для хранения картинки
                u.photo_binary = Barray;  // заполяем поле photoBinary полученным байтовым массивом
                Base.EM.userphoto.Add(u);  // добавляем объект в таблицу БД
                Base.EM.SaveChanges();  // созраняем изменения в БД
                MessageBox.Show("Фото добавлено");
                NavigationService.Navigate(new UserMenuPage(user)); // перезагружаем страницу

            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();  // создаем диалоговое окно
                OFD.Multiselect = true;  // открытие диалогового окна с возможностью выбора нескольких элементов
                if (OFD.ShowDialog() == true)  // пока диалоговое окно открыто, будет в цикле записывать каждое выбранное изображение в БД
                {
                    foreach (string file in OFD.FileNames)  // цикл организован по именам выбранных файлов
                    {
                        userphoto u = new userphoto();  // создание объекта для добавления записи в таблицу, где хранится фото
                        u.id_user = user.id_user;  // присваиваем значение полю idUser (id авторизованного пользователя)
                        string path = file;  // считываем путь выбранного изображения
                        System.Drawing.Image SDI = System.Drawing.Image.FromFile(file);  // создаем объект для загрузки изображения в базу
                        ImageConverter IC = new ImageConverter();  // создаем конвертер для перевода картинки в двоичный формат
                        byte[] Barray = (byte[])IC.ConvertTo(SDI, typeof(byte[]));  // создаем байтовый массив для хранения картинки
                        u.photo_binary = Barray;  // заполяем поле photoBinary полученным байтовым массивом
                        Base.EM.userphoto.Add(u);  // добавляем объект в таблицу БД
                    }
                    Base.EM.SaveChanges();
                    MessageBox.Show("Фото добавлены");
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }
        int n = 0;
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            spGallery.Visibility = Visibility.Visible;
            List<userphoto> u = Base.EM.userphoto.Where(x => x.id_user == user.id_user).ToList();
            if (u != null)  // если объект не пустой, начинает переводить байтовый массив в изображение
            {

                byte[] Bar = u[n].photo_binary;   // считываем изображение из базы (считываем байтовый массив двоичных данных)
                showImage(Bar, imgGallery);  // отображаем картинку
            }
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            List<userphoto> u = Base.EM.userphoto.Where(x => x.id_user == user.id_user).ToList();
            n++;
            if (Back.IsEnabled == false)
            {
                Back.IsEnabled = true;
            }
            if (u != null)  // если объект не пустой, начинает переводить байтовый массив в изображение
            {

                byte[] Bar = u[n].photo_binary;   // считываем изображение из базы (считываем байтовый массив двоичных данных)
                showImage(Bar, imgGallery);
            }
            if (n == u.Count - 1)
            {
                Next.IsEnabled = false;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            List<userphoto> u = Base.EM.userphoto.Where(x => x.id_user == user.id_user).ToList();
            n--;
            if (Next.IsEnabled == false)
            {
                Next.IsEnabled = true;
            }
            if (u != null)  // если объект не пустой, начинает переводить байтовый массив в изображение
            {

                byte[] Bar = u[n].photo_binary;   // считываем изображение из базы (считываем байтовый массив двоичных данных)
                BitmapImage BI = new BitmapImage();  // создаем объект для загрузки изображения
                showImage(Bar, imgGallery);
            }
            if (n == 0)
            {
                Back.IsEnabled = false;
            }
        }

        private void btnOld_Click(object sender, RoutedEventArgs e)
        {
            List<userphoto> u = Base.EM.userphoto.Where(x => x.id_user == user.id_user).ToList();
            byte[] Bar = u[n].photo_binary;   // считываем изображение из базы (считываем байтовый массив двоичных данных)
            showImage(Bar, imUser);
            // отображаем картинку
            //Base.EM.SaveChanges();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            spGallery.Visibility = Visibility.Hidden;
        }

        private void Button_Click_Log(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InsertUserLoginPage(user));
        }

        private void Btn_go_admin(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage(user));
        }

        private void Btn_go_list(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListViewTable(user));
        }
    }
}
