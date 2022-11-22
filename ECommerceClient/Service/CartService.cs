using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using ECommerceClient.Service.IService;
using ECommerceClient.ViewModels;
using ECommerceCommon;

namespace ECommerceClient.Service
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        public event Action OnChange;

        public CartService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async Task DecrementCart(ShoppingCart cartToDecrement)
        {
            var cart = await _localStorage.GetItemAsync<List<ShoppingCart>>(SD.ShoppingCart);

            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].ProductId == cartToDecrement.ProductId && cart[i].ProductPriceId == cartToDecrement.ProductPriceId)
                {
                    if (cart[i].Count == 1 || cartToDecrement.Count == 0)
                    {
                        cart.Remove(cart[i]);
                    }
                    else
                    {
                        cart[i].Count = cart[i].Count - cartToDecrement.Count;
                    }
                }
            }

            await _localStorage.SetItemAsync(SD.ShoppingCart, cart);
            OnChange.Invoke();
        }

        public async Task IncrementCart(ShoppingCart cartToAdd)
        {
            var cart = await _localStorage.GetItemAsync<List<ShoppingCart>>(SD.ShoppingCart);
            bool itemInCart = false;

            if (cart == null)
            {
                cart = new List<ShoppingCart>();
            }
            foreach (var item in cart)
            {
                if (item.ProductId == cartToAdd.ProductId && item.ProductPriceId == cartToAdd.ProductPriceId)
                {
                    itemInCart = true;
                    item.Count = item.Count + cartToAdd.Count;
                }
            }
            if (!itemInCart)
            {
                cart.Add(new()
                {
                    ProductId = cartToAdd.ProductId,
                    ProductPriceId = cartToAdd.ProductPriceId,
                    Count = cartToAdd.Count
                });
            }

            await _localStorage.SetItemAsync(SD.ShoppingCart, cart);
            OnChange.Invoke();
        }
    }
}