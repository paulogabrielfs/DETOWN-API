using System.Threading.Tasks;
using Refit;

namespace DETOWN.Domain.Services
{
    public interface IFooClient
    {
        [Get("/")]
        Task<object> GetAll();
    }
}
