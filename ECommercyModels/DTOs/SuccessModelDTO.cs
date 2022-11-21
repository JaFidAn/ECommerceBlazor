using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommercyModels.DTOs
{
    public class SuccessModelDTO
    {
        public int StatusCode { get; set; }
        public string SuccessMessage { get; set; }
        public object Data { get; set; }
    }
}