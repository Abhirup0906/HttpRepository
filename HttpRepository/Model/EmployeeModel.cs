using System;

namespace HttpRepository.Model
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
    }
}
