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

namespace workWithBD
{
    public partial class Tickets
    {

        public string NameBreed
        {
            get
            {
                return  "Билет на фильм: " +  session;
            }
        }
        public string DateTime
        {
            get
            {

                List<sales> TC = Base.EM.sales.Where(x => x.id_tickets == id_ticket).ToList();

                DateTime str ;
                str = new DateTime(1991, 12, 31);
                foreach (sales tc in TC)
                {
                    str = Convert.ToDateTime(tc.dateTime);
                }

                return "Дата и время сеанса: " + str.ToString("dd.mm.yyyy hh:mm");
            }
        }
        public SolidColorBrush TypeColor
        {
            get
            {
                switch (id_type_tickets)
                {
                    case 1:
                        return Brushes.Chartreuse;
                    case 2:
                        return Brushes.CornflowerBlue;
                    case 3:
                        return Brushes.Cyan;
                    case 4:
                        return Brushes.GreenYellow;
                    case 5:
                        return Brushes.Ivory;
                    default:
                        return Brushes.White;
                }
            }
        }


    }
}
