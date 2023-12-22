using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample
{
    public class OrderInfoRepository
    {
        public OrderInfoRepository()
        {
            SetShipCity();
        }

        #region private variables

        private List<DateTime> OrderedDates;
        private Random random = new Random();

        #endregion

        #region GetOrderDetails

        public ObservableCollection<OrderInfo> GetOrderDetails(int count)
        {
            this.OrderedDates = GetDateBetween(2000, 2014, count);
            ObservableCollection<OrderInfo> orderDetails = new ObservableCollection<OrderInfo>();
            for (int i = 10001; i <= count + 10000; i++)
            {
                var shipcountry = ShipCountry[random.Next(5)];
                var shipcitycoll = ShipCity[shipcountry];
                var orderID = new List<int>();
                orderID.Add(i);
                var ord = new OrderInfo()
                {
                    OrderID = i,
                    CustomerID = CustomerID[random.Next(15)],
                    EmployeeID = i + 10000,
                    FirstName = FirstNames[random.Next(15)],
                    LastName = LastNames[random.Next(15)],
                  //  Enabled = ((i % 1 == 0) ? true : false),
                    Gender = Genders[random.Next(5)],
                    ShipCountry = ShipCountry[random.Next(5)],
                    ShippingDate = this.OrderedDates[i - 10001] ,
                    Freight = (Math.Round(random.Next(1000) + random.NextDouble(), 2)),
                   // IsOnline = ((i % 2 == 0) ? true : false),
                    ShipCity = shipcitycoll[random.Next(shipcitycoll.Length - 1)],
                };
                orderDetails.Add(ord);
            }
            return orderDetails;
        }

        #endregion

        #region MainGrid DataSource


        private List<DateTime> GetDateBetween(int startYear, int endYear, int count)
        {
            List<DateTime> date = new List<DateTime>();
            Random d = new Random(1);
            Random m = new Random(2);
            Random y = new Random(startYear);
            for (int i = 0; i < count; i++)
            {
                int year = y.Next(startYear, endYear);
                int month = m.Next(3, 11);
                int day = d.Next(1, 28);

                date.Add(new DateTime(year, month, day));
            }
            return date;
        }

        string[] Genders = new string[] {
            "Male",
            "Female",
            "Female",
            "Female",
            "Male",
            "Male",
            "Male",
            "Male",
            "Male",
            "Male",
            "Male",
            "Male",
            "Female",
            "Female",
            "Female",
            "Male",
            "Male",
            "Male",
            "Female",
            "Female",
            "Female",
            "Male",
            "Male",
            "Male",
            "Male"
        };

        string[] FirstNames = new string[] {
            "Kyle NoahWilliam James",
            "Gina IreneOscar",
            "Irene Gina",
            "Katie IreneOscar",
            "Michael IreneOscar",
            "Oscar",
            "Ralph Torrey",
            "Torrey Oscar",
            "William NoahWilliam",
            "Bill NoahWilliam James",
            "Daniel NoahWilliam James",
            "Frank",
            "Brenda FionaDanielle",
            "Danielle Brenda",
            "Fiona FionaDanielle",
            "Howard",
            "Jack NoahWilliam",
            "Larry Jack NoahWilliam",
            "Holly NoahWilliam",
            "Jennifer",
            "Liz Holly NoahWilliam",
            "Pete Steve",
            "Steve Pete Steve",
            "Vince VinceSteve",
            "Zeke VinceSteve"
        };

        string[] LastNames = new string[] {
            "Adams Torrey Oscar",
            "Crowley Torrey Oscar",
            "Ellis NoahWilliam",
            "Gable NoahWilliam",
            "Irvine VinceSteve",
            "Keefe VinceSteve",
            "Mendoza Jack NoahWilliam",
            "Owens Jack NoahWilliam",
            "Rooney IreneOscar",
            "Waddell IreneOscar",
            "Thomas IreneOscar",
            "Betts NoahWilliam",
            "Doran Betts NoahWilliam",
            "Fitzgerald Betts NoahWilliam",
            "Holmes Betts NoahWilliam",
            "Jefferson Holmes",
            "Landry Holmes",
            "Newberry",
            "Perez Newberry",
            "Spencer Perez Newberry",
            "Vargas Perez Newberry",
            "Grimes Perez Newberry",
            "Edwards Perez Newberry",
            "Stark StoneBlanc",
            "Cruise StoneBlanc",
            "Fitz",
            "Chief",
            "Blanc",
            "Perry StoneBlanc",
            "Stone StoneBlanc",
            "Williams StoneBlanc",
            "Lane StoneBlanc",
            "Jobs StoneBlanc"
        };

        string[] CustomerID = new string[] {
            "Alfkis WelliSimob",
            "Frans Noah WelliSimob",
            "Merep Oliver WelliSimob",
            "Merep Elijah WelliSimob",
            "FolkoT Benjamin Oliver",
            "Simob LucasElijah",
            "Warth Noah WelliSimob" ,
            "Vaffe LucasElijah",
            "Furib BenjaminFurib",
            "Seves WelliSimob",
            "Linodd LucasElijah",
            "Riscu Benjamin",
            "Piccos WelliSimob",
            "Blonds Noah WelliSimob",
            "Welli Elijah",
            "Folig Benjamin Oliver"
        };

        string[] ShipCountry = new string[] {

            "Argentina",
            "Austria",
            "Belgium",
            "Brazil",
            "Canada",
            "Denmark",
            "Finland",
            "France",
            "Germany",
            "Ireland",
            "Italy",
            "Mexico",
            "Norway",
            "Poland",
            "Portugal",
            "Spain",
            "Sweden",
            "Switzerland",
            "UK",
            "USA",
            "Venezuela"
        };

        Dictionary<string, string[]> ShipCity = new Dictionary<string, string[]>();

        private void SetShipCity()
        {
            string[] argentina = new string[] { "Buenos Aires" };

            string[] austria = new string[] { "Grazdfgdfgfd", "Salzburg" };

            string[] belgium = new string[] { "Bruxelles", "Charleroi" };

            string[] brazil = new string[] { "Campinasdfgdfgdf", "Resende", "Rio de Janeiro", "São Paulo" };

            string[] canada = new string[] { "Montréal", "Tsawassen", "Vancouver" };

            string[] denmark = new string[] { "Århus sf sfsdsd", "København" };

            string[] finland = new string[] { "Helsinki", "Oulu" };

            string[] france = new string[] {
                "Lille",
                "Lyon",
                "Marseille",
                "Nantes",
                "Paris",
                "Reims",
                "Strasbourg",
                "Toulouse",
                "Versailles"
            };

            string[] germany = new string[] {
                "Aachen",
                "Berlin",
                "Brandenburg",
                "Cunewalde",
                "Frankfurt a.M.",
                "Köln",
                "Leipzig",
                "Mannheim",
                "München",
                "Münster",
                "Stuttgart"
            };

            string[] ireland = new string[] { "Cork" };

            string[] italy = new string[] { "Bergamo", "Reggio Emilia", "Torino" };

            string[] mexico = new string[] { "México D.F." };

            string[] norway = new string[] { "Stavern" };

            string[] poland = new string[] { "Warszawa" };

            string[] portugal = new string[] { "Lisboa" };

            string[] spain = new string[] { "Barcelona", "Madrid", "Sevilla" };

            string[] sweden = new string[] { "Bräcke", "Luleå" };

            string[] switzerland = new string[] { "Bern", "Genève" };

            string[] uk = new string[] { "Colchester", "Hedge End", "London" };

            string[] usa = new string[] {
                "Albuquerque",
                "Anchorage",
                "Boise",
                "Butte",
                "Elgin",
                "Eugene",
                "Kirkland",
                "Lander",
                "Portland",
                "San Francisco",
                "Seattle",
                "Walla Walla"
            };

            string[] venezuela = new string[] { "Barquisimeto", "Caracas", "I. de Margarita", "San Cristóbal" };

            ShipCity.Add("Argentina", argentina);
            ShipCity.Add("Austria", austria);
            ShipCity.Add("Belgium", belgium);
            ShipCity.Add("Brazil", brazil);
            ShipCity.Add("Canada", canada);
            ShipCity.Add("Denmark", denmark);
            ShipCity.Add("Finland", finland);
            ShipCity.Add("France", france);
            ShipCity.Add("Germany", germany);
            ShipCity.Add("Ireland", ireland);
            ShipCity.Add("Italy", italy);
            ShipCity.Add("Mexico", mexico);
            ShipCity.Add("Norway", norway);
            ShipCity.Add("Poland", poland);
            ShipCity.Add("Portugal", portugal);
            ShipCity.Add("Spain", spain);
            ShipCity.Add("Sweden", sweden);
            ShipCity.Add("Switzerland", switzerland);
            ShipCity.Add("UK", uk);
            ShipCity.Add("USA", usa);
            ShipCity.Add("Venezuela", venezuela);
        }

        #endregion

    }

    public class SortModel
    {
        public int datas { get; set; }
    }
}
