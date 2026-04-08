using AutoMapper;
using PkAssessmentAPI.Models.DTOs.Department;
using PkAssessmentAPI.Models.DTOs.Employee;
using PkAssessmentAPI.Domain.Entities;

namespace PkAssessmentAPI.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentDto>()
                .ReverseMap();

            CreateMap<AddDepartmentDto, Department>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<EditDepartmentDto, Department>()
                .ReverseMap();

            // Employee Mappings
            CreateMap<Employee, EmployeeDto>()
                .ReverseMap();

            CreateMap<AddEmployeeDto, Employee>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Age, opt => opt.Ignore()) // Calculated in DB
                .ReverseMap();

            CreateMap<EditEmployeeDto, Employee>()
                .ForMember(dest => dest.ModifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.Age, opt => opt.Ignore()) // Calculated in DB
                .ReverseMap();
        }
    }
}
