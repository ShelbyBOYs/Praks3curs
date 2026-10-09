using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoCars.domain
{
    public class Money
    {
        public decimal Price { get; private set; }
        public string Currency { get; private set; }


        private Money() { Currency = null!; }
        public Money(decimal price, string currency)
        {
            Price = price;
            Currency = currency;
        }

    }
}
