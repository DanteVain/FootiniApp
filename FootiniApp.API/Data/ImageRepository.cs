using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootiniApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FootiniApp.API.Data
{
    public class ImageRepository : IImageRepository
    {
        private readonly DataContext _context;
        public ImageRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Image> GetImage(int id)
        {
            var image = await _context.Images.FirstOrDefaultAsync(i => i.Id == id);
            return image;
        }

        public async Task<IEnumerable<Image>> GetImages(int id)
        {
            var images = await _context.Images.Where(i => i.UserId == id).ToListAsync();
            return images;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}