using Microsoft.EntityFrameworkCore;
using Univer.Domain.Entities;

namespace Univer.Infrastructure.Database
{
    public class LecturerDbContext : DbContext
    {
        public LecturerDbContext(DbContextOptions<LecturerDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Lecturer> Lecturers { get; set; }
    }
}
