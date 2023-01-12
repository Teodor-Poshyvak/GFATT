using GFAT.DALL.Interface;
using GFAT.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
namespace GFAT.DALL.Repository;

public class FoodRepository : IBaseRepository<Food>
{
    private readonly ApplicationDbContext _db;
    
    public FoodRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public async Task Create(Food models)
    {
        await _db.Foods.AddAsync(models);
        await _db.SaveChangesAsync();
    }

    public IQueryable<Food> GetAll()
    {
        return _db.Foods;
    }

    public async Task Delete(Food models)
    {
        _db.Foods.Remove(models);
        await _db.SaveChangesAsync();
    }

    public async Task<Food> Update(Food models)
    {
        _db.Foods.Update(models);
        await _db.SaveChangesAsync();

        return models;
    }
}
