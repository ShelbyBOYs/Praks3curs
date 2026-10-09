using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvtoCars.Application.Interfaces;
using AvtoCars.domain;

namespace AvtoCars.Application.Services
{
    public class SellCarServices
    {
        private readonly ICarRepository _carRepository;

        public SellCarServices(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task SellCar(Guid carId)
        {
            Car? car = await _carRepository.GetByID(carId);

            if (car == null) 
            {
                throw new ArgumentException("Авто в базі немає!");
            }

            car.Sell();

            await _carRepository.Save(car);
        }
    }
}
