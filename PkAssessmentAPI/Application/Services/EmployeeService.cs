using AutoMapper;
using PkAssessmentAPI.Application.Interfaces;
using PkAssessmentAPI.Domain.Entities;
using PkAssessmentAPI.Domain.Interfaces;
using PkAssessmentAPI.Models.DTOs.Employee;

namespace PkAssessmentAPI.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            return _mapper.Map<EmployeeDto?>(employee);
        }

        public async Task<int> CreateEmployeeAsync(AddEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            return await _employeeRepository.AddAsync(employee);
        }

        public async Task<int> UpdateEmployeeAsync(EditEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            return await _employeeRepository.UpdateAsync(employee);
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            return await _employeeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByDepartmentIdAsync(int departmentId)
        {
            var employees = await _employeeRepository.GetByDepartmentIdAsync(departmentId);
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }
    }
}
