using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommercyModels.DTOs
{
    public class ErrorModelDTO
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}