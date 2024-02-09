using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGrid_Demo_4_8.Model
{
    public class OrderInfo : INotifyPropertyChanged
    {
        #region Private members

        private int _orderId;
        private string _customerId;
        private int _unitPrice;
        private int _quantiy;
        private double _discount;
        private bool isClosed;
        private string _contactNumber;
        private DateTime deliveryDate;
        private string hyperlink;
        private int shipCityId;
        private string _products;


        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the order ID.
        /// </summary>
        /// <value>The order ID.</value>

        public int OrderID
        {
            get
            {
                return _orderId;
            }
            set
            {
                _orderId = value;
                RaisePropertyChanged("OrderID");
            }
        }

        public bool IsClosed
        {
            get
            {
                return isClosed;
            }
            set
            {
                isClosed = value;
                RaisePropertyChanged("IsClosed");
            }
        }

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        /// <value>The customer ID.</value>

        public string CustomerID
        {
            get
            {
                return _customerId;
            }
            set
            {
                _customerId = value;
                RaisePropertyChanged("CustomerID");
            }
        }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        /// <value>The unit price.</value>

        public int UnitPrice
        {
            get
            {
                return _unitPrice;
            }
            set
            {
                _unitPrice = value;
                RaisePropertyChanged("UnitPrice");
            }
        }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity
        {
            get
            {
                return _quantiy;
            }
            set
            {
                _quantiy = value;
                RaisePropertyChanged("Quantity");
            }
        }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        /// <value>The discount.</value>
        public double Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                _discount = value;
                RaisePropertyChanged("Discount");
            }
        }

        public string Hyperlink
        {
            get
            {
                return hyperlink;
            }
            set
            {
                hyperlink = value;
                RaisePropertyChanged("Hyperlink");
            }

        }

        public DateTime OrderDate
        {
            get
            {
                return deliveryDate;
            }
            set
            {
                deliveryDate = value;
                RaisePropertyChanged("OrderDate");
            }
        }

        /// <summary>
        /// Gets or sets the contact number.
        /// </summary>
        /// <value>
        /// The contact number.
        /// </value>
        public string ContactNumber
        {
            get
            {
                return _contactNumber;
            }
            set
            {
                _contactNumber = value;
                RaisePropertyChanged("ContactNumber");
            }
        }

        public int ShipCityID
        {
            get
            {
                return shipCityId;
            }
            set
            {
                shipCityId = value;
                RaisePropertyChanged("ShipCityID");
            }
        }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        public string Products
        {
            get
            {
                return _products;
            }
            set
            {
                _products = value;
                RaisePropertyChanged("Products");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
