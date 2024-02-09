﻿using SfDataGrid_Demo_4_8.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGrid_Demo_4_8.ViewModel
{
     public class OrderInfoCollection : IDisposable
    {
        public OrderInfoCollection(int count)
        {
            OrdersListDetails = new OrderInfoRepository().GetListOrdersDetails(count);
        }

        private BindingList<OrderInfo> _ordersListDetails;


        /// <summary>
        /// Gets or sets the orders details.
        /// </summary>
        /// <value>The orders details.</value>
        public BindingList<OrderInfo> OrdersListDetails
        {
            get { return _ordersListDetails; }
            set { _ordersListDetails = value; }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool isdisposable)
        {
            if (this.OrdersListDetails != null)
            {
                this.OrdersListDetails.Clear();
            }
        }
    }
    
    public class OrderInfoRepository
    {
        int customerIdCount = 0;

        /// <summary>
        /// Gets the orders details.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public BindingList<OrderInfo> GetListOrdersDetails(int count)
        {
            BindingList<OrderInfo> ordersDetails = new BindingList<OrderInfo>();
            if (ShipCity.Count == 0)
                SetShipCity();
            for (int i = 10000; i < count + 10000; i++)
            {
                ordersDetails.Add(GetOrder(i));
            }

            return ordersDetails;
        }

        Random r = new Random(1);

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        private OrderInfo GetOrder(int i)
        {
            var shipcountry = ShipCountry[r.Next(5)];
            var shipcitycoll = ShipCity[shipcountry];
            var order = new OrderInfo();
            var phone = string.Format("{0}- {1}-{2}-{3}", r.Next(1, 1).ToString().Substring(0, 1), r.Next(514, 541).ToString().Substring(0, 3), r.Next(724, 754).ToString().Substring(0, 3), r.Next(301, 305).ToString().Substring(0, 3));
            order.OrderID = i;
            order.CustomerID = GetCustomerID(i);
            order.IsClosed = i % 2 == 0 ? true : false;
            order.UnitPrice = (int)unitPrice[r.Next(35)];
            order.Quantity = r.Next(20, 60);
            order.ContactNumber = phone;
            order.Discount = r.Next(10, 90);
            order.OrderDate = DateTime.Today.AddDays((double)order.UnitPrice / 100);
            order.Hyperlink = GetHyperlink(i);
            order.Products = (string)productName[r.Next(18)];
            order.ShipCityID = shipCityID[r.Next(1, 7)];

            return order;
        }

        int[] shipCityID = new int[] { 138, 139, 140, 141, 142, 143, 145, 146 };

        string GetCustomerID(int i)
        {
            if (i % 4 != 0 || i == 0)
            {
                return CustomerID[customerIdCount];
            }
            else
            {
                if (i % 4 == 0)
                    customerIdCount++;

                if (customerIdCount > 9)
                    customerIdCount = 0;

                return CustomerID[customerIdCount];
            }
        }

        string GetHyperlink(int i)
        {
            if (i % 4 != 0 || i == 0)
            {
                return Hyperlinks[customerIdCount];
            }
            else
            {
                if (i % 4 == 0)
                    customerIdCount++;

                if (customerIdCount > 9)
                    customerIdCount = 0;

                return Hyperlinks[customerIdCount];
            }
        }

        double[] unitPrice = new double[] { 28.5, 336.2, 88.3, 86, 512, 41, 253.3, 33, 87, 45.1, 78.3, 19, 56.7, 23.3, 59, 91, 32.8, 264.5, 63.7, 434.2, 15.9, 21.9, 45, 70.3, 42.5, 67.2, 34.9, 379.9, 0, 59.2, 412.6, 19.8, 42.7, 78, 26.8 };

        string[] ShipCountry = new string[]
        {
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

        /// <summary>
        /// Collection of ProductNames
        /// </summary>
        string[] productName = new string[]
        {
            "Alice Mutton",
            "NuNuCa Nuß-Nougat-Creme",
            "Boston Crab Meat",
            "Raclette Courdavault",
            "Wimmers gute",
            "Gorgonzola Telino",
            "Fløtemysost",
            "Thüringer",
            "Vegie-spread",
            "Tarte au sucre",
            "Konbu",
            "Valkoinen suklaa",
            "Queso Manchego",
            "Perth Pasties",
            "Vegie-spread",
            "Tofu",
            "Sir Rodney's",
            "Manjimup Dried Apples"
        };

        Dictionary<string, string[]> ShipCity = new Dictionary<string, string[]>();

        /// <summary>
        /// Sets the ship city.
        /// </summary>
        private void SetShipCity()
        {
            string[] argentina = new string[] { "Buenos Aires" };

            string[] austria = new string[] { "Graz", "Salzburg" };

            string[] belgium = new string[] { "Bruxelles", "Charleroi" };

            string[] brazil = new string[] { "Campinas", "Resende", "Rio de Janeiro", "São Paulo" };

            string[] canada = new string[] { "Montréal", "Tsawassen", "Vancouver" };

            string[] denmark = new string[] { "Århus", "København" };

            string[] finland = new string[] { "Helsinki", "Oulu" };

            string[] france = new string[] { "Lille", "Lyon", "Marseille", "Nantes", "Paris", "Reims", "Strasbourg", "Toulouse", "Versailles" };

            string[] germany = new string[] { "Aachen", "Berlin", "Brandenburg", "Cunewalde", "Frankfurt a.M.", "Köln", "Leipzig", "Mannheim", "München", "Münster", "Stuttgart" };

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

            string[] usa = new string[] { "Albuquerque", "Anchorage", "Boise", "Butte", "Elgin", "Eugene", "Kirkland", "Lander", "Portland", "San Francisco", "Seattle", "Walla Walla" };

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

        string[] CustomerID = new string[]
        {
            "ALFKI",
            "FRANS",
            "MEREP",
            "FOLKO",
            "SIMOB",
            "WARTH",
            "VAFFE",
            "FURIB",
            "SEVES",
            "LINOD",
            "RISCU",
            "PICCO",
            "BLONP",
            "WELLI",
            "FOLIG",
            "SHIWL",
            "ASDFI",
            "YIWOL",
            "SIEPZ",
            "UIKOC",
            "BNUTQ",
            "FDKIO",
            "UJIKW",
            "QOLPX",
            "WJXKO",
            "SXEWD",
            "ZXSOL",
            "KKMJU",
            "QMICP",
            "SJWII",
            "WDOPO",
            "SAIOP",
            "SSOLE",
            "CUEMC",
            "HWIMQ"
        };

        string[] Hyperlinks = new string[]
        {
            "https://www.google.com/",
            "https://www.gmail.com/",
            "http://www.microsoft.com",
            "https://www.office.com/",
            "https://www.bing.com/",
            "https://www.bing.com/",
            "http://www.microsoft.com",
            "https://www.bing.com/",
            "https://www.bing.com/",
            "https://www.bing.com/",
            "http://www.microsoft.com",
            "https://www.gmail.com/",
            "https://www.office.com/",
            "http://www.microsoft.com",
            "https://www.gmail.com/",
            "http://www.microsoft.com",
            "http://www.microsoft.com",
            "https://www.bing.com/",
            "https://www.bing.com/",
            "https://www.bing.com/",
            "http://www.microsoft.com",
            "https://www.bing.com/",
            "https://www.office.com/",
            "http://www.microsoft.com",
            "https://www.gmail.com/",
            "http://www.microsoft.com",
            "http://www.microsoft.com",
            "https://www.bing.com/",
            "http://www.microsoft.com",
            "http://www.microsoft.com",
            "https://www.office.com/",
            "https://www.bing.com/",
            "http://www.microsoft.com",
            "https://www.bing.com/",
            "http://www.microsoft.com"
        };
    }
}
