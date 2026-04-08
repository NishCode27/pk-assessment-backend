using AutoMapper;
using PkAssessmentAPI.Application.Interfaces;
using PkAssessmentAPI.Domain.Entities;
using PkAssessmentAPI.Domain.Interfaces;
using PkAssessmentAPI.Models.DTOs.Department;

namespace PkAssessmentAPI.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }

        public async Task<DepartmentDto?> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            return _mapper.Map<DepartmentDto?>(department);
        }

        public async Task<int> CreateDepartmentAsync(AddDepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            department.CreatedDate = DateTime.UtcNow;

            return await _departmentRepository.AddAsync(department);
        }

        public async Task<int> UpdateDepartmentAsync(EditDepartmentDto editDepartmentDto)
        {
            var department = _mapper.Map<Department>(editDepartmentDto);
            return await _departmentRepository.UpdateAsync(department);
        }

        public async Task<int> DeleteDepartmentAsync(int id)
        {
            return await _departmentRepository.DeleteAsync(id);
        }

        public async Task<Department?> GetDepartmentByCodeAsync(string code)
        {
            return await _departmentRepository.GetByCodeAsync(code);
        }
    }
}
