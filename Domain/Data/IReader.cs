using Domain.Data;
using System.Threading.Tasks;

namespace Services.Data
{
    public interface IReader
    {
        Task<Grid> ReadAsync();
    }
}
