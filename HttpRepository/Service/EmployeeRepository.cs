using HttpRepository.Contract;
using HttpRepository.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpRepository.Service
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(HttpClient httpClient) : base(httpClient)
        {

        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployee()
        {
            var employee = await Get<IEnumerable<EmployeeModel>>("/api/v1/GetEmployee");
            return employee;
        }

        public async Task UpdateEmployee(EmployeeModel employeeModel)
        {
            await Post<EmployeeModel, bool>(employeeModel, "/api/v1/UpdateEmployee");
        }
    }
}
