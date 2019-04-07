using System.Threading.Tasks;

namespace Domain.Data
{
    public interface IReader
    {
        Task<Grid> ReadAsync();
    }
}
