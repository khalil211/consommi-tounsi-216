using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsommiTounsi.Data.Models.Payment
{
    public class ResponseModel<T>
    {
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public T Body { get; set; }
    }
}
