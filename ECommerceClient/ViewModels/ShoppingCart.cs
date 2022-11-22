using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommercyModels.DTOs;

namespace ECommerceClient.ViewModels
{
    public class ShoppingCart
    {
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
        public int ProductPriceId { get; set; }
        public ProductPriceDTO ProductPrice { get; set; }
        public int Count { get; set; }
    }
}