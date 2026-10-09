using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AvtoCars.domain
{
    public class Vin
    {
        public string Vin_{get; private set;}


        private Vin() { Vin_ = null!; }
        public Vin(string vin)
        {
            if (string.IsNullOrEmpty(vin)|| vin.Length != 17)
            {
                throw new ArgumentException("Win має містити 17 символів");
            } 

            Vin_ = vin; 
        }

    }
}
