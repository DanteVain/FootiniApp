using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootiniApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FootiniApp.API.Data
{
    public class BoardsRepository : IBoardsRepository
    {
        private readonly DataContext _context;
        public BoardsRepository(DataContext context)
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

        public async Task<Board> GetBoard(int id)
        {
            //var board = await _context.Boards.Include(b => b.Images).FirstOrDefaultAsync(i => i.Id == id);
            var board = await _context.Boards.FirstOrDefaultAsync(i => i.Id == id);
            return board;
        }

        public async Task<IEnumerable<Board>> GetBoards(int id)
        {
            var board = await _context.Boards.Where(b => b.UserId == id).ToListAsync();
            return board;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;   
        }
    }
}