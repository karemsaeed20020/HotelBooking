using HotelBooking.Application.Interfaces;
using HotelBooking.Application.Interfaces.Repositories;
using HotelBooking.Domain.Entities.Common;
using HotelBooking.Infrastructure.Data.DbContexts;
using HotelBooking.Infrastructure.Implmentations.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelBookingDbContext _context;
        private readonly Dictionary<Type, object> _repositories = [];
        public UnitOfWork(HotelBookingDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            var entityType = typeof(TEntity);
            if (_repositories.TryGetValue(entityType, out object? reposiotry))
            {
                return (IGenericRepository<TEntity>)reposiotry;
            }
            var newRepo = new GenericRepository<TEntity>(_context);
            _repositories[entityType] = newRepo;
            return newRepo;

        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
        
    }
}
