using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    /// <summary>
    /// Interface for IBalance
    /// </summary>
    public interface IBalance
    {
        /// <summary>
        /// Wallet Balance parameter of IBalance
        /// </summary> 
        public double WalletBalance { get; }
        /// <summary>
        /// Wallet Recharge method of IBalance
        /// </summary>
        /// <param name="amount">Parameter of the method WalletRecharge </param>
        /// <returns></returns> 
        double WalletRecharge(double amount);

        /// <summary>
        /// DeductBalance method of IBalance
        /// </summary>
        /// <param name="amount">Parameter of the method DeductBalance</param>
        /// <returns></returns>
        double DeductBalance(double amount);
    
    
    }
}