using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AvtoCars.domain;
using AvtoCars.Application.Interfaces;
using AvtoCars.Infrastructure.Persistence;

namespace AvtoCars.Infrastructure.Repositories
{
     public class CarRepository : ICarRepository
     {
        private readonly AppDbContext _context;

        public CarRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<Car?> GetByID(Guid id)
        {
            return await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task Add(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }
        public async Task Save(Car car)
        {
             _context.Update(car);
            await _context.SaveChangesAsync();
        }



     }
}
