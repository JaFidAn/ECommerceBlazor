using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceClient.ViewModels;

namespace ECommerceClient.Service.IService
{
    public interface ICartService
    {
        public event Action OnChange;
        Task DecrementCart(ShoppingCart shoppingCart);
        Task IncrementCart(ShoppingCart shoppingCart);
    }
}