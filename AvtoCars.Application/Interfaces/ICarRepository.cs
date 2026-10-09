using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvtoCars.domain;

namespace AvtoCars.Application.Interfaces
{
    public interface ICarRepository
    {
        Task<Car?> GetByID(Guid id);
        Task Add(Car car);
        Task Save(Car car);
    }
}
