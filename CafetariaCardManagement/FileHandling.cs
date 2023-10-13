using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public class FileHandling
    {
        //to create the csv files and folder in the console application
        public static void Create()
        {
            //first create a folder for csv file
            if (!Directory.Exists("CafeteriaCardManagement"))
            {
                Directory.CreateDirectory("CafeteriaCardManagement");
                Console.WriteLine("Folder created");
            }
            else
            {
                Console.WriteLine("Folder already found");
            }
            //create csv file for user details class
            if (!File.Exists("CafeteriaCardManagement/UserDetails.csv"))
            {
                File.Create("CafeteriaCardManagement/UserDetails.csv").Close();
                Console.WriteLine("File created");
            }
            else
            {
                Console.WriteLine("File already found");
            }
            //create csv for personal details class 
            if (!File.Exists("CafeteriaCardManagement/PersonalDetails.csv"))
            {
                File.Create("CafeteriaCardManagement/PersonalDetails.csv").Close();
                Console.WriteLine("File created");
            }
            else
            {
                Console.WriteLine("File already found");
            }
            //create csv for order details class
            if (!File.Exists("CafeteriaCardManagement/OrderDetails.csv"))
            {
                File.Create("CafeteriaCardManagement/OrderDetails.csv").Close();
                Console.WriteLine("File created");
            }
            else
            {
                Console.WriteLine("File already found");
            }
            //created csv for food details class
            if (!File.Exists("CafeteriaCardManagement/FoodDetails.csv"))
            {
                File.Create("CafeteriaCardManagement/FoodDetails.csv").Close();
                Console.WriteLine("File created");
            }
            else
            {
                Console.WriteLine("File already found");
            }
            //create csv file for card item class
            if (!File.Exists("CafeteriaCardManagement/CardItem.csv"))
            {
                File.Create("CafeteriaCardManagement/CardDetails.csv").Close();
                Console.WriteLine("File created");
            }
            else
            {
                Console.WriteLine("File already found");
            }
        }
        public static void WriteToCsv()
        {
            //food details
            string[] foodDetails = new string[Operations.userList.Count];
            for (int i = 0; i < Operations.foodList.Count; i++)
            {
                foodDetails[i]= Operations.foodList[i].FoodID + ","+Operations.foodList[i].FoodName+","+Operations.foodList[i].FoodPrice+","+Operations.foodList[i].AvailableQuantity;
            }
            File.WriteAllLines("CafeteriaCardManagement/UserDetails.csv",foodDetails);

            //card details
            string[] cardItem = new string[Operations.cartlist.Count];
            for (int i = 0; i < Operations.cartlist.Count; i++)
            {
                cardItem[i] = Operations.cartlist[i].OrderID + "," + Operations.cartlist[i].FoodID +","+Operations.cartlist[i].OrderPrice+","+Operations.cartlist[i].OrderQuantity;
            }
            File.WriteAllLines("CafeteriaCardManagement/UserDetails.csv", cardItem);

            //orderDetails
            string[] orderDetails = new string[Operations.orderList.Count];
            for (int i = 0; i < Operations.cartlist.Count; i++)
            {
                orderDetails[i]=Operations.orderList[i].OrderID+","+Operations.orderList[i].OrderDate+","+ Operations.orderList[i].TotalPrice+","+Operations.orderList[i].Status;
            }
            File.WriteAllLines("CafeteriaCardManagement/UserDetails.csv",orderDetails );

            //user details
            string[] userDetails = new string[Operations.userList.Count];
            for (int i = 0; i < Operations.cartlist.Count; i++)
            {
                userDetails[i] = Operations.userList[i].UserID+","+Operations.userList[i].Name+","+Operations.userList[i].FatherName+","+Operations.userList[i].Mobile+","+Operations.userList[i].MailID+","+Operations.userList[i].Gender;
            }
            File.WriteAllLines("CafeteriaCardManagement/UserDetails.csv", userDetails);


        }

        public static void ReadFromCSC()
        {
            //first read all lines from a class
            //traverse the class
            //cart details
            string[] cardItem = File.ReadAllLines("CafeteriaCardManagement/CardItem.csv");
            foreach (string card in cardItem)
            {
                CartItems cart = new CartItems(card);
                Operations.cartlist.Add(cart);
            }
            //food details
            string[] foodDetails = File.ReadAllLines("CafeteriaCardManagement/FoodDetails.csv");
            foreach (string food in foodDetails)
            {
                FoodDetails food1 = new FoodDetails(food);
                Operations.foodList.Add(food1);
            }
            string[] orderDetails = File.ReadAllLines("CafeteriaCardManagement/OrderDetails.csv");
            //order details
            foreach (string order in orderDetails)
            {
                OrderDetails order1 = new OrderDetails(order);
                Operations.orderList.Add(order1);
            }
            //userdetails
            string[] userDetails = File.ReadAllLines("CafeteriaCardManagement/UserDetails.csv");
            foreach(string user in userDetails)
            {
                UserDetails user1 = new UserDetails(user);
                Operations.userList.Add(user1);
            }
        }


    }
}