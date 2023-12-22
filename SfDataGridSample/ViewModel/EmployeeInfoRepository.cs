using Syncfusion.Maui.Data;
using Syncfusion.Maui.DataGrid;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;

namespace SfDataGridSample
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {

        internal OrderInfoRepository order;

        private int[] FirstPickerItems = new int[] { 0, 1, 2, 3, 4, 5, 6 };
        private int[] SecondPickerItems = new int[] { 1500, 1501, 1502, 1503, 1504, 1505, 1506 };

        private ObservableCollection<int> firstPickerItem;

        public ObservableCollection<int> FirstPickerItem
        {
            get { return firstPickerItem; }
            set
            {
                this.firstPickerItem = value;
                OnPropertyChanged("FirstPickerItem");
            }
        }

        private ObservableCollection<int> secondPickerItem;

        public ObservableCollection<int> SecondPickerItem
        {
            get { return secondPickerItem; }
            set
            {
                this.secondPickerItem = value;
                OnPropertyChanged("SecondPickerItem");
            }
        }

        public EmployeeViewModel()
        {
            order = new OrderInfoRepository();
            SetRowstoGenerate(100);

            this.Selectedindex = 1;
            this.FirstPickerItem = FirstPickerItems.ToObservableCollection();
            this.SecondPickerItem = SecondPickerItems.ToObservableCollection();
        }

        #region ItemsSource

        public ObservableCollection<string> CustomerNames { get; set; }

        public ObservableCollection<string> CustomerNames1 { get; set; }

        private ObservableCollection<OrderInfo> ordersInfo;
        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return ordersInfo; }
            set
            {
                this.ordersInfo = value;
                OnPropertyChanged("OrdersInfo");
            }
        }

        private OrderInfo selectedItem;

        public OrderInfo SelectedItem
        {
            get { return selectedItem; }
            set
            {
                this.selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }



        private int selectedindex;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public int Selectedindex
        {
            get
            {
                return selectedindex;
            }
            set
            {
                selectedindex = value;
                OnPropertyChanged("Selectedindex");
            }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            OrdersInfo = order.GetOrderDetails(count);
        }

        #endregion
    }

    public class NotificationObject : INotifyPropertyChanged, INotifyCollectionChanged
    {
        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void RaiseCollectionChanged(string propName)
        {
            if (this.CollectionChanged != null)
                this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        public event NotifyCollectionChangedEventHandler? CollectionChanged;
    }
}

