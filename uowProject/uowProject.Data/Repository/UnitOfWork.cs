using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uowProject.Data.Repository.IRepository;

namespace uowProject.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IPublisherRepository Publisher => new PublisherRepository(_context);

        public IGameRepository Game => new GameRepository(_context);

        public IDeveloperRepository Developer => new DeveloperRepository(_context);

        public IPlatformRepository Platform => new PlatformRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
