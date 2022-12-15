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
using System.Windows.Media.Animation;
namespace workWithBD.Windows
{
    /// <summary>
    /// Interaction logic for Rechlama.xaml
    /// </summary>
    public partial class Rechlama : Page
    {
        public Rechlama()
        {
            InitializeComponent();

            //кнопка
            DoubleAnimation WA = new DoubleAnimation(); // создание объекта для настройки анимации
            WA.From = 100; // начальное значение свойства
            WA.To = 300; // конечное значение свойства
            WA.Duration = TimeSpan.FromSeconds(1); // продолжительность анимации (в секундах)
            WA.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            WA.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            area.BeginAnimation(WidthProperty, WA); // «навешивание» анимации на свойство ширины кнопки
            DoubleAnimation WAH = new DoubleAnimation(); // создание объекта для настройки анимации
            WAH.From = 50; // начальное значение свойства
            WAH.To = 150; // конечное значение свойства
            WAH.Duration = TimeSpan.FromSeconds(1); // продолжительность анимации (в секундах)
            WAH.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            WAH.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            area.BeginAnimation(HeightProperty, WAH); // «навешивание» анимации на свойство ширины кнопки


            ThicknessAnimation MA = new ThicknessAnimation(); // анимация границ
            MA.From = new Thickness(10,10, 70, 70);
            MA.To = new Thickness(0, 0, 0, 0);
            MA.Duration = TimeSpan.FromSeconds(2);
            MA.AutoReverse = true;
            area.BeginAnimation(MarginProperty, MA);

           
                        ColorAnimation BA = new ColorAnimation(); // создание объекта для настройки анимации
                        ColorConverter CC = new ColorConverter(); // создание объекта для конвертации кода в цвет
                        Color Cstart = (Color)CC.ConvertFrom("#FFADFF2F"); // присваивание начального цвета эл-ту
                        area.Background = new SolidColorBrush(Cstart); // закрашивание эл-та сплошным цветом
                        BA.From = Cstart; // начальное значение свойства
                        BA.To = (Color)CC.ConvertFrom("#FFFFD700"); // конечное значение свойства
                        BA.Duration = TimeSpan.FromSeconds(2);
                        BA.AutoReverse = true;
                        area.Background.BeginAnimation(SolidColorBrush.ColorProperty, BA);


            //text block
            DoubleAnimation FSA = new DoubleAnimation();
            FSA.From = 10;
            FSA.To = 30;
            FSA.Duration = TimeSpan.FromSeconds(2);
            FSA.RepeatBehavior = RepeatBehavior.Forever;
            FSA.AutoReverse = true;
            txBlock.BeginAnimation(FontSizeProperty, FSA);

            //image

            DoubleAnimation WAPH = new DoubleAnimation(); // создание объекта для настройки анимации
            WAPH.From = 100; // начальное значение свойства
            WAPH.To = 300; // конечное значение свойства
            WAPH.Duration = TimeSpan.FromSeconds(1); // продолжительность анимации (в секундах)
            WAPH.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            WAPH.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            images.BeginAnimation(WidthProperty, WAPH); // «навешивание» анимации на свойство ширины кнопки
            DoubleAnimation WAHPH = new DoubleAnimation(); // создание объекта для настройки анимации
            WAHPH.From = 50; // начальное значение свойства
            WAHPH.To = 150; // конечное значение свойства
            WAHPH.Duration = TimeSpan.FromSeconds(1); // продолжительность анимации (в секундах)
            WAHPH.RepeatBehavior = RepeatBehavior.Forever; // бесконечность анимации
            WAHPH.AutoReverse = true; // воспроизведение временной шкалы в обратном порядке
            images.BeginAnimation(HeightProperty, WAHPH); // «навешивание» анимации на свойство ширины кнопки
        }
    }
}
