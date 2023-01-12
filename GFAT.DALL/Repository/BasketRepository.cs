using GFAT.DALL.Interface;
using GFAT.Domain.Models;

namespace GFAT.DALL.Repository;

public class BasketRepository : IBaseRepository<Basket>
{
    private readonly ApplicationDbContext _db;

        public BasketRepository(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task Create(Basket models)
        {
            await _db.Baskets.AddAsync(models);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Basket> GetAll()
        {
            return _db.Baskets;
        }

        public async Task Delete(Basket models)
        {
            _db.Baskets.Remove(models);
            await _db.SaveChangesAsync();
        }

        public async Task<Basket> Update(Basket entity)
        {
            _db.Baskets.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

}   

