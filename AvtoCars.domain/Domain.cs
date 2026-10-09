using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvtoCars.domain
{
  
    public class Car
    {

        private Car() { Vin = null!; Price = null!; }
       public Car(Vin vin, Money price)
       {
            Id = Guid.NewGuid();
            Vin = vin;
            Price = price;
            IsSold = false;
       }
        public Guid Id { get; private set; }
        public Vin Vin { get; private set; }
        public Money Price { get; private set; }
        public bool IsSold { get; private set; }
        public void Sell()
        {
            if (IsSold == true)
            { throw new InvalidOperationException("Авто уже продано");
              
            }
            IsSold = true;

        }
    }
}
