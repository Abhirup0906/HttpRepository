using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpRepository.Contract
{
    public interface IBaseHttpRepository
    {
        string ContentType { get; set; }
        Dictionary<string, string> HeaderProperties { get; set; }
        Task<bool> Delete<T>(T request, string requestUri);
        Task<U> Get<U>(string requestUri);
        Task<U> Post<T, U>(T request, string requestUri);
        Task<bool> Put<T>(T request, string requestUri);
    }
}
