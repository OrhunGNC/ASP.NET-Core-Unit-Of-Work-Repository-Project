using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uowProject.Data.Repository.IRepository;
using uowProject.Models;

namespace uowProject.Data.Repository
{
    public class DeveloperRepository : Repository<Developer>, IDeveloperRepository
    {
        private ApplicationDbContext _context;
        public DeveloperRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
