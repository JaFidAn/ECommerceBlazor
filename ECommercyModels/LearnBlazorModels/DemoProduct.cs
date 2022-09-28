using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommercyModels.LearnBlazorModels
{
    public class DemoProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public List<DemoProductProp> ProductProperties { get; set; }
    }
}