using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderApplication
{
    public class FoodDetails
    {
    
        private static int s_foodID =100;
        public string FoodID { get;}
        public string FoodName { get; set; }
        public double PricePerQuantity { get; set; }
        public int  QuantityAvailable { get; set; }
        public FoodDetails( string foodName,double pricePerQuantity,int quantityAvailable)
        {
            FoodID = "FID"+(++s_foodID);
            FoodName = foodName;
            PricePerQuantity = pricePerQuantity;
            QuantityAvailable = quantityAvailable;
        }
        public FoodDetails()
        {
            //default constructor
        }
    }
}

//: FoodID, FoodName, PricePerQuantity, QuantityAvailable

