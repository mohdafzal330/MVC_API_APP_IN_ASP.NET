using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using ApiDL;
namespace AutoMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<Department,DepartmentDTO>();

            CreateMap<EmployeeDTO, Employee>();
            CreateMap<DepartmentDTO, Department>();
            CreateMap<Address, AddressDTO>();
            CreateMap<AddressDTO, Address>();
            
        }
    }
}
