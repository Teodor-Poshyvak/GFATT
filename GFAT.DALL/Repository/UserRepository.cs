
using System.Linq;
using System.Threading.Tasks;
using GFAT.DALL.Interface;
using GFAT.Domain.Models;


namespace GFAT.DALL.Repository;

    public class UserRepository : IBaseRepository<User>
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<User> GetAll()
        {
            return _db.Users;
        }

        public async Task Delete(User models)
        {
            _db.Users.Remove(models);
            await _db.SaveChangesAsync();
        }

        public async Task Create(User models)
        {
            await _db.Users.AddAsync(models);
            await _db.SaveChangesAsync();
        }

        public async Task<User> Update(User models)
        {
            _db.Users.Update(models);
            await _db.SaveChangesAsync();

            return models;
        }
    }
