using Domain.Common.Exceptions;
using System.Threading.Tasks;

namespace Domain.Data
{
    /// <summary>
    /// Reader that produces a grid
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Returns a grid from the data
        /// </summary>
        /// <exception cref="ReaderException">Throws an exception when it cannot return a valid grid</exception>
        Task<Grid> ReadAsync();
    }
}
