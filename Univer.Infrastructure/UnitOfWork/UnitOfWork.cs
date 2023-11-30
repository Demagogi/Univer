using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univer.Domain.Interfaces;
using Univer.Infrastructure.Database;

namespace Univer.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly LecturerDbContext _context;
        public ILecturerRepository LecturerRepository {  get; init; }

        public UnitOfWork(LecturerDbContext context, ILecturerRepository lecturerRepository)
        {
            _context = context;
            LecturerRepository = lecturerRepository;
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
