using Microsoft.EntityFrameworkCore;
using Univer.Domain.Entities;
using Univer.Domain.Interfaces;

namespace Univer.Infrastructure.Repositories
{
    public class LecturerRepository : Repository<Lecturer>, ILecturerRepository
    {
        public LecturerRepository(DbContext context) : base(context)
        {
        }
    }
}
