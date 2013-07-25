using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.StoreExample
{
    public class Customer
    {
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfFirstPurchase { get; set; }
        public bool IsVetaran { get; set; }
    }
}
