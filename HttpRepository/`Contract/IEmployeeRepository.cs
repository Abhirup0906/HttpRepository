using HttpRepository.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpRepository.Contract
{
    public interface IEmployeeRepository : IBaseHttpRepository
    {
        Task<IEnumerable<EmployeeModel>> GetEmployee();
        Task UpdateEmployee(EmployeeModel employeeModel);
    }
}
