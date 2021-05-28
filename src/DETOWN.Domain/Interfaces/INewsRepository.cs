using DETOWN.Domain.Models;

namespace DETOWN.Domain.Interfaces
{
    public interface INewsRepository : IRepository<News>
    {
        News GetNewsByTitle(string title);
    }
}