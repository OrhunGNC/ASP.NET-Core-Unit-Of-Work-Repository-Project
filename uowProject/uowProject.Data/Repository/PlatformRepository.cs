using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uowProject.Data.Repository.IRepository;
using uowProject.Models;

namespace uowProject.Data.Repository
{
    public class PlatformRepository : Repository<Platform>, IPlatformRepository
    {
        private ApplicationDbContext _context;
        public PlatformRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
