using AvtoCars.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvtoCars.domain;

namespace AvtoCars.Application.Services
{
    public class AddCarServices
    {
        private readonly ICarRepository _carRepository;

        public AddCarServices(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Guid> AddCar(string vincode, decimal price, string currency)
        {
            var vin = new Vin(vincode);
            var money = new Money(price,currency);
            var car = new Car(vin, money);

            await _carRepository.Add(car);
            return car.Id;

        }
    }
}
