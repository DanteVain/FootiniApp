using System.Collections.Generic;
using System.Threading.Tasks;
using FootiniApp.API.Models;

namespace FootiniApp.API.Data
{
    public interface IImageRepository
    {
        void Add<T>(T entity) where T: class;

        void Delete<T>(T entity) where T: class;

        Task<bool> SaveAll();
        Task<IEnumerable<Image>> GetImages(int id);

        Task<Image> GetImage(int id);  
    }
}