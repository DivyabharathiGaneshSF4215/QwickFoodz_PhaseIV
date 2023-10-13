using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderApplication
{
    public enum OrderStatus{Default,Initiated,Ordered,Cancelled}
    public class OrderDetails
    {
        private static int s_orderID = 3000;
        public string OrderID { get;}
        public string CustomerID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateOfOrder {get; set;}
        public OrderStatus Status { get; set; }
        public OrderDetails(string customerID,double totalPrice,DateTime dateOfOrder,OrderStatus status)
        {
            OrderID = "OID"+(++s_orderID);
            CustomerID = customerID;
            TotalPrice = totalPrice;
            DateOfOrder = dateOfOrder;
            Status = status;
            
        }

    }
}

//Properties: OrderID, CustomerID, TotalPrice, DateOfOrder, OrderStatus – {Default, Initiated, Ordered, Cancelled}.