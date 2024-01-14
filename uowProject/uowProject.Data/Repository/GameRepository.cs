using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uowProject.Data.Repository.IRepository;
using uowProject.Models;

namespace uowProject.Data.Repository
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        private ApplicationDbContext _context;
        public GameRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
