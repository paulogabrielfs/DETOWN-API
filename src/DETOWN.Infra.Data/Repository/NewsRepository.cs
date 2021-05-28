using System.Linq;
using DETOWN.Domain.Interfaces;
using DETOWN.Domain.Models;
using DETOWN.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DETOWN.Infra.Data.Repository
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        public NewsRepository(ApplicationDbContext context)
            : base(context)
        {

        }

        public News GetNewsByTitle(string title)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Title == title);
        }
    }
}