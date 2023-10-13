using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderApplication
{
    public class ItemDetails
    {
        private static int s_itemID = 100;
        public string ItemID { get;  }
        public string OrderID { get; set; }
        public string FoodID { get; set; }
        public int PurchaseCount { get; set; }
        public double PriceOfOrder { get; set; }
        public ItemDetails(string orderID,string foodID, int purchaseCount,double priceOfOrder)
        {
            ItemID = "ITID"+(++s_itemID);
            OrderID =orderID;
            FoodID = foodID;
            PurchaseCount = purchaseCount;
            PriceOfOrder = priceOfOrder;
        }
    }
}
//ItemID – (ITID100), OrderID, FoodID, PurchaseCount, PriceOfOrder