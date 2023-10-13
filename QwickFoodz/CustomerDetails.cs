using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QwickFoodz;
/// <summary>
/// namespace FoodOrderApplication contains the classes 
/// </summary>
namespace FoodOrderApplication
{
    /// <summary>
    /// class CustomerDetails inherits from the PersonalDetails and IBalance
    /// </summary>
    public class CustomerDetails:PersonalDetails, IBalance
    {
        /// <summary>
        /// Private field for the property customerID
        /// </summary>
        private static int s_custID =1000;
        /// <summary>
        /// Property CustomerID contains the ID of the customer
        /// </summary>
        /// <value>It requires string value</value>
        public string CustomerID { get; }
        /// <summary>
        /// Property WalletBalance contains the balance of the customer
        /// </summary>
        /// <value></value>
        public double  WalletBalance { get; set;}

        /// <summary>
        /// Customer Details class for the CustomerDetails list
        /// </summary>
        /// <param name="name">Parameter for property Name inherit from the PersonalDetails</param>
        /// <param name="fatherName">Parameter for property FatherName inherit from the PersonalDetails</param>
        /// <param name="gender">Parameter for property Gender inherit from the PersonalDetails</param>
        /// <param name="mobile">Parameter for property Mobile inherit from the PersonalDetails</param>
        /// <param name="dob">Parameter for property DOB inherit from the PersonalDetails</param>
        /// <param name="mailID">Parameter for property MailID inherit from the PersonalDetails</param>
        /// <param name="location">Parameter for property Location inherit from the PersonalDetails</param>
        /// <param name="walletBalance">Parameter for property WalletBalance inherit from the PersonalDetails</param> <summary>
        /// 
        /// </summary>
        public CustomerDetails(string name,string fatherName,Gender gender,long mobile,DateTime dob,string mailID,string location,double walletBalance)
        :base( name, fatherName, gender, mobile, dob, mailID, location)
        {
            CustomerID = "CID"+(++s_custID);
            WalletBalance = walletBalance;
        }
        /// <summary>
        /// WalletRecharge method from IBalance interface
        /// </summary>
        /// <param name="amount">It requires a double value</param>
        /// <returns>It returns a double value</returns>
        public double WalletRecharge(double amount)
        {
            WalletBalance += amount;
            return WalletBalance;
        }
        /// <summary>
        /// DeductBalance method from IBalance interface
        /// </summary>
        /// <param name="amount">It requires a double value</param>
        /// <returns>It returns a double value</returns>
        public double DeductBalance(double amount)
        {
            WalletBalance -= amount;
            return WalletBalance;
        }
    }
}
//CustomerDetails class: Inherits Personal Details, IBalance
// Field: _balance
// Properties: CustomerID, WalletBalance
// Methods: WalletRecharge, DeductBalance
