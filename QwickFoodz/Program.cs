using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using FoodOrderApplication;
namespace Qwickfoodz;
class Program
{
    public static List<FoodDetails> foodDetails = new List<FoodDetails>();
    public static List<OrderDetails> orderDetails = new List<OrderDetails>();
    public static List<ItemDetails> itemDetails = new List<ItemDetails>();
    public static List<CustomerDetails> customerDetails = new List<CustomerDetails>();
    public static CustomerDetails currentLoggedInCustomer;
    
    public static void Main(string[] args)
    {

        DefaultData();
        //ask choice of the user for the application
        int menuChoice;
        bool menucheck;
        do
        {
            do
            {
                Console.WriteLine("Menu:1.Customer Registration 2.Customer login 3.Exit");
                menucheck = int.TryParse(Console.ReadLine(), out menuChoice);
            } while (!menucheck);
            //switch options according to the user's choice
            switch (menuChoice)
            {
                case 1:
                    {
                        Console.WriteLine("Registration");
                        Registration();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Login");
                        Login();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Exit");
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Invalid");
                        break;
                    }
            }
        } while (menuChoice != 3);

    }
    //method for registration
    public static void Registration()
    {
        Console.WriteLine("Registration");
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter your father name:");
        string fatherName = Console.ReadLine();

        //input for gender
        Console.WriteLine("Select your gender 1.Male 2.Female 3.Transgender");
        bool temp = false;
        Gender gender;
        do
        {

            temp = Gender.TryParse<Gender>(Console.ReadLine(), true, out gender);
            if (!temp)
            {
                Console.WriteLine("Invalid input");
            }

        } while (!temp);
        //user input for mobile number
        Console.WriteLine("Enter your mobile number");
        long mobile;
        bool mobileCheck;
        do
        {
            mobileCheck = long.TryParse(Console.ReadLine(), out mobile);
            if (mobile.ToString().Length != 10)
            {
                mobileCheck = false;
                Console.WriteLine("Invalid mobile number");
            }
        } while (!mobileCheck);

        Console.WriteLine("Enter your date of birth:");
        DateTime dob;
        bool dobCheck;
        do
        {
            dobCheck = DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dob);
        } while (!dobCheck);

        Console.WriteLine("Enter your mail id: ");
        string mailID = Console.ReadLine();

        Console.WriteLine("Enter your location:");
        string location = Console.ReadLine();
        double walletBalance = 0;

        CustomerDetails customer = new CustomerDetails(name, fatherName, gender, mobile, dob, mailID, location, walletBalance);
        customerDetails.Add(customer);

        //display the registered id for the user
        Console.WriteLine("Your user id is:" + customer.CustomerID);


    }
    //create a method for login option
    public static void Login()
    {
        Console.WriteLine("Login");

        Console.WriteLine("Enter your customer id:");
        string currentID = Console.ReadLine().ToUpper();
        bool loginCheck = false;

        foreach (CustomerDetails customer in customerDetails)
        {
            if (customer.CustomerID == currentID)
            {
                Console.WriteLine("Valid");
                currentLoggedInCustomer = customer;
                SubMenu();
                loginCheck = true;
            }
        }
        if (!loginCheck)
        {
            Console.WriteLine("Invalid user id");
        }
    }
    public static void SubMenu()
    {
        //submenu choice are displayed
        int subMenuChoice;
        bool subMenucheck;
        do
        {
            do
            {
                Console.WriteLine("Menu:1.Show profile 2.Order food 3.cancel order 4.modify order 5.order history 6.Recharge wallet 7.show wallet balance 8.Exit");
                subMenucheck = int.TryParse(Console.ReadLine(), out subMenuChoice);
            } while (!subMenucheck);
            //switch options according to the user's choice
            switch (subMenuChoice)
            {
                case 1:
                    {
                        Console.WriteLine("Show Profile");
                        ShowProfile();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("order food");
                        OrderFood();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("cancel order");
                        CancelOrder();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Modify order");
                        ModifyOrder();
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Order history");
                        OrderHistory();
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Recharge wallet");
                        RechargeWallet();
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("Show Wallet balance");
                        ShowWalletBalance();
                        break;
                    }
                case 8:
                    {
                        Console.WriteLine("Exiting from the submenu.. re-directing to the main menu");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid submenu choice");
                        break;
                    }
            }
        } while (subMenuChoice != 8);

    }

    public static void ShowProfile()
    {
        Console.WriteLine("Show profile");
        //showing customer profile
        Console.WriteLine("Customer name Father name Gender MailID Mobile Dob location");
        foreach (CustomerDetails customer in customerDetails)
        {
            if (currentLoggedInCustomer.CustomerID == customer.CustomerID)
            {
                Console.WriteLine($"{customer.Name},{customer.FatherName},{customer.Gender},{customer.MailID},{customer.Mobile},{customer.DOB},{customer.Location}");
            }
        }
    }
    public static void OrderFood()
    {
        Console.WriteLine("Order food");
        // a.	Create OrderDetails object with CustomerID, TotalPrice = 0, DateOfOrder as today and OrderStatus = Initiated.
        double totalPrice = 0;
        OrderDetails order = new OrderDetails(currentLoggedInCustomer.CustomerID, totalPrice, DateTime.Today, OrderStatus.Initiated);

        //b.	Create localItemList for adding your wishlist.
        FoodDetails localItemList = new FoodDetails();
        string Choice = "yes";
        do
        {
            //c.	Show all the list of food items available in store for processing the order.
            foreach (FoodDetails food in foodDetails)
            {
                Console.WriteLine($"{food.FoodID},{food.FoodName},{food.PricePerQuantity},{food.QuantityAvailable}");
            }

            //d.	Ask the FoodID, order quantity from user and check whether it is available. If not show FoodID Invalid or FoodQuantity 
            Console.WriteLine("Enter the food id from the above list:");
            string choosedFood = Console.ReadLine().ToUpper();
            Console.WriteLine("Enter the quantity you want to order ");
            int orderQuantity = int.Parse(Console.ReadLine());
            bool check = true;
            //show the ordered food details from the list
            foreach (FoodDetails food1 in foodDetails)
            {
                if (food1.FoodID == choosedFood && food1.QuantityAvailable >= orderQuantity)
                {
                    check = false;
                    localItemList = food1;
                    Console.WriteLine("Your order id is:" + order.OrderID);
                    totalPrice += orderQuantity * localItemList.PricePerQuantity;

                    //e.If it is available then, create ItemDetails object with created OrderID, FoodID, Quantity and Price of this order, deduct the available quantity and store the ItemDetails object in localItemList.
                    // Calculate total price of this order by summing it with current item’s price
                    ItemDetails orderedItem = new ItemDetails(order.OrderID, choosedFood, orderQuantity, totalPrice);


                    //f.	Ask the user whether he want to order more. If “Yes” means again show food details and repeat from step “c” to create new ItemDetails object. Repeat this process until he says “No”.
                    Console.WriteLine("Do you want to purchase more?(yes/no):");
                    Choice = Console.ReadLine().ToLower();

                    if (Choice == "no")
                    {

                        Console.WriteLine("Do you want to confirm order:");
                        string confirmCheck = Console.ReadLine().ToLower();

                        if (confirmCheck == "no")
                        {
                            //return the localItemList of items count back to FoodDetails list
                            foreach(FoodDetails food in foodDetails)
                            {
                                if(food.FoodID == localItemList.FoodID)
                                {
                                    foodDetails.Add(new FoodDetails(localItemList.FoodID,totalPrice,orderQuantity));
                                }
                            }

                        }
                        else if (confirmCheck == "yes")
                        {
                            if (currentLoggedInCustomer.WalletBalance > totalPrice)
                            {
                                currentLoggedInCustomer.DeductBalance(totalPrice);
                                OrderDetails order1 = new OrderDetails(currentLoggedInCustomer.CustomerID, totalPrice, DateTime.Today, OrderStatus.Ordered);
                                orderDetails.Add(order1);
                                //adding food local items list  to the item detail list
                                ItemDetails item = new ItemDetails(order1.OrderID,localItemList.FoodID,orderQuantity,totalPrice);
                            }
                            else
                            {
                                Console.WriteLine("You don't have a sufficient balance..Do you want to recharge to proceed further");
                                string rechargeCheck = Console.ReadLine().ToLower();
                                if (rechargeCheck == "yes")
                                {
                                    Console.WriteLine("Enter the amount to recharge:");
                                    double amount = double.Parse(Console.ReadLine());
                                    currentLoggedInCustomer.WalletRecharge(amount);
                                }
                                else
                                {
                                    // return the localItemList item’s count to FoodList.
                                    localItemList.QuantityAvailable += orderQuantity;

                                }

                            }
                        }

                    }
                Console.WriteLine("Your order is placed successfully");
                }
            }

            if (check)
            {
                Console.WriteLine("Invalid food id or quantity not available");
            }
        } while (Choice == "yes");
    }

    //method for cancel order option
    public static void CancelOrder()
    {
        Console.WriteLine("Cancel order");
        //show the already placed order
        foreach (OrderDetails order in orderDetails)
        {
            if (order.CustomerID == currentLoggedInCustomer.CustomerID && order.Status == OrderStatus.Ordered)
            {
                Console.WriteLine($"{order.CustomerID},{order.OrderID},{order.DateOfOrder},{order.TotalPrice},{order.Status}");
            }
            //Ask the user to pick an order to be cancelled by OrderID.
            Console.WriteLine("Enter the order id to cancel:");
            string cancelOrderID = Console.ReadLine();
            //If OrderID is present, then change the order status to “Cancelled”. 

            if (order.OrderID == cancelOrderID && order.Status == OrderStatus.Ordered)
            {
                order.Status = OrderStatus.Cancelled;
                double refund = order.TotalPrice;
                //Refund the total price amount of current order to user’s WalletBalance
                currentLoggedInCustomer.WalletRecharge(refund);

                foreach (ItemDetails item in itemDetails)
                {
                    if (item.OrderID == cancelOrderID)
                    {
                        foreach (FoodDetails food in foodDetails)
                        {
                            if (food.FoodID == item.FoodID)
                            {
                                food.QuantityAvailable += item.PurchaseCount;
                            }

                        }
                    }
                }
            }
        }
        Console.WriteLine("Your order is cancelled successfully!");

    }
    //method for modify order option
    public static void ModifyOrder()
    {
        Console.WriteLine("modify order");
        foreach (OrderDetails order in orderDetails)
        {
            if (order.CustomerID == currentLoggedInCustomer.CustomerID && order.Status == OrderStatus.Ordered)
            {
                Console.WriteLine($"{order.CustomerID},{order.OrderID},{order.DateOfOrder},{order.TotalPrice},{order.Status}");
            }
            //b.	Ask the user to pick an order to be modify by OrderID.
            Console.WriteLine("Enter the order id to Modify:");
            string modifyOrderID = Console.ReadLine();
            if (order.OrderID == modifyOrderID && order.Status == OrderStatus.Ordered)
            {
                //show the item details for the currently logged in user to modify the order

                foreach (ItemDetails item in itemDetails)
                {
                    if (item.OrderID == order.OrderID)
                    {
                        //Ask ItemID and check ItemID is valid. Then ask user to provide new item quantity
                        Console.WriteLine("Enter the item ID in which you want to modify");
                        string modifyItemID = Console.ReadLine();
                        ItemDetails item1 = item;

                        if (item.ItemID == modifyItemID)
                        {
                            Console.WriteLine("Enter the quantity you want to modify");
                            double newItemQuantity = double.Parse(Console.ReadLine());
                            foreach (FoodDetails food in foodDetails)
                            {
                                if (item.FoodID == food.FoodID)
                                {
                                    double modifiedPrice = food.PricePerQuantity * newItemQuantity;

                                    if (modifiedPrice > order.TotalPrice)
                                    {
                                        double amount = modifiedPrice - order.TotalPrice;
                                        currentLoggedInCustomer.DeductBalance(amount);
                                    }
                                    else if (modifiedPrice < order.TotalPrice)
                                    {
                                        double amount = order.TotalPrice - modifiedPrice;
                                        currentLoggedInCustomer.WalletRecharge(amount);
                                    }
                                    order.TotalPrice = modifiedPrice;
                                    Console.WriteLine("Your order" + modifyOrderID + "is modified successfully");
                                }


                            }

                        }
                    }
                }

            }

        }
    }
    //method for order history option
    public static void OrderHistory()
    {
        Console.WriteLine("Order history");
        Console.WriteLine("OrderID Date of order TotalPrice Order status");
        foreach (OrderDetails order in orderDetails)
        {
            if (order.CustomerID == currentLoggedInCustomer.CustomerID)
            {
                Console.WriteLine($"{order.OrderID},{order.DateOfOrder},{order.TotalPrice},{order.Status}");
            }
        }
    }
    //method for recharge wallet options
    public static void RechargeWallet()
    {
        Console.WriteLine("Enter the amount to recharge:");
        double amount = double.Parse(Console.ReadLine());

        //wallet recharge from the customer details list is called
        currentLoggedInCustomer.WalletRecharge(amount);
        Console.WriteLine("Your recharge is processed successfully! your current balance is"+currentLoggedInCustomer.WalletBalance);

    }
    //method for show wallet balance option
    public static void ShowWalletBalance()
    {
        Console.WriteLine("Show wallet balance");

        //showing balance to the currently logged in customer
        Console.WriteLine("Your balance is " + currentLoggedInCustomer.WalletBalance);
    }

    public static void DefaultData()
    {
        //adding default data to the  customer details list
        customerDetails.Add(new CustomerDetails("Ravi", "Ettapparajan", Gender.Male, 974774646, new DateTime(11 / 11 / 1999), "ravi@gmail.com", "Chennai", 15000));
        customerDetails.Add(new CustomerDetails("Baskaran", "Sethurajan", Gender.Male, 847575775, new DateTime(11 / 11 / 1999), "baskaran@gmail.com", "Chennai", 10000));

        //adding default data to the food details list
        foodDetails.Add(new FoodDetails("Mutton Briyani 1kg", 150, 10));
        foodDetails.Add(new FoodDetails("Veg Full meals", 80, 30));
        foodDetails.Add(new FoodDetails("Dosa", 40, 40));
        foodDetails.Add(new FoodDetails("Idly (2 pieces)", 20, 50));
        foodDetails.Add(new FoodDetails("Pongal", 40, 20));
        foodDetails.Add(new FoodDetails("Vegetable Briyani", 80, 30));
        foodDetails.Add(new FoodDetails("Lemon Rice", 50, 30));
        foodDetails.Add(new FoodDetails("Veg Pulav", 120, 30));
        foodDetails.Add(new FoodDetails("Chicken 65 (200 Grams)", 75, 30));

        //adding default data to item details list
        itemDetails.Add(new ItemDetails("OID3001", "FID101", 2, 200));
        itemDetails.Add(new ItemDetails("OID3001", "FID102", 2, 300));
        itemDetails.Add(new ItemDetails("OID3001", "FID103", 1, 80));
        itemDetails.Add(new ItemDetails("OID3002", "FID101", 1, 100));
        itemDetails.Add(new ItemDetails("OID3002", "FID101", 4, 600));
        itemDetails.Add(new ItemDetails("OID3002", "FID101", 1, 120));
        itemDetails.Add(new ItemDetails("OID3002", "FID101", 1, 50));
        itemDetails.Add(new ItemDetails("OID3003", "FID101", 2, 300));
        itemDetails.Add(new ItemDetails("OID3003", "FID101", 4, 320));
        itemDetails.Add(new ItemDetails("OID3003", "FID101", 2, 200));

        //adding default data to the order details list
        orderDetails.Add(new OrderDetails("CID1001", 580, new DateTime(26 / 11 / 2022), OrderStatus.Ordered));
        orderDetails.Add(new OrderDetails("CID1002", 820, new DateTime(26 / 11 / 2022), OrderStatus.Ordered));
        orderDetails.Add(new OrderDetails("CID1001", 870, new DateTime(26 / 11 / 2022), OrderStatus.Cancelled));

        //check whether the list is added or not
        foreach (CustomerDetails customer in customerDetails)
        {
           Console.WriteLine($"{customer.Name},{customer.FatherName},{customer.Gender},{customer.MailID},{customer.Mobile},{customer.DOB},{customer.Location}");
        }

        foreach (OrderDetails order in orderDetails)
        {
            Console.WriteLine($"{order.CustomerID},{order.OrderID},{order.DateOfOrder},{order.TotalPrice},{order.Status}");
        }
        

    }
}
