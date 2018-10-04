using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootiniApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FootiniApp.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
             _context.Add(entity);
        }

        public async Task<Image> GetImage(int id)
        {
            var image = await _context.Images.FirstOrDefaultAsync(i => i.Id == id);
            return image;
        }

        public async Task<List<Image>> GetImages(int userid)
        {
            List<Image> images = await _context.Images.Where(i => i.User.Id == userid).ToListAsync();
            return images;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}