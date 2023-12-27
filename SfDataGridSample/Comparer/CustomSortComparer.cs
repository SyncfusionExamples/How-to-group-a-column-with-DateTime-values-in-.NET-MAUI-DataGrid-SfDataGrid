using Syncfusion.Maui.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample.Comparer
{
    public class CustomSortComparer : IComparer<object>, ISortDirection

    {
        #region Property

        public ListSortDirection SortDirection { get; set; }

        #endregion

        #region Constructor

        public CustomSortComparer()
        {

        }

        #endregion

        #region Compare

        public int Compare(object? x, object? y)
        {

            DateTime dateX = DateTime.MaxValue;

            DateTime dateY = DateTime.MaxValue;

            if (x.GetType() == typeof(OrderInfo))
            {
                dateX = (DateTime)((OrderInfo)x).ShippingDate;

                dateY = (DateTime)((OrderInfo)y).ShippingDate;
            }

            else if (x.GetType() == typeof(Group))
            {
                dateX = (DateTime)((Group)x).Key;

                dateY = (DateTime)((Group)y).Key;
            }

            else
            {
                dateX = (DateTime)x;

                dateY = (DateTime)y;
            }

            if (DateTime.Compare(dateX, dateY) >= 0)

                return SortDirection == ListSortDirection.Ascending ? 1 : -1;

            else

                return SortDirection == ListSortDirection.Ascending ? -1 : 1;
        }

        #endregion
    }
}
