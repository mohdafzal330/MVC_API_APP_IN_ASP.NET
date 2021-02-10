using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using ApiDL;
using AutoMapper;
namespace APIBL
{
    public class EmployeeBL
    {
        APIDevEntities _contect = new APIDevEntities();
        public List<EmployeeDTO> GetAllEmployees()
        {
            List<EmployeeDTO> employess = _contect.Employees.Select(Mapper.Map<Employee,EmployeeDTO>).ToList();
            return employess;
        }

        public EmployeeDTO GetEmployeeById(long id)
        {
            Employee e = _contect.Employees.Find(id);
            EmployeeDTO emp = new EmployeeDTO();
            Mapper.Map(e,emp);
            return emp;
        }
        public EmployeeDTO AddEmployee(EmployeeDTO employeeDTO)
        {
            Employee emp = Mapper.Map<EmployeeDTO,Employee>(employeeDTO);
             _contect.Employees.Add(emp);
            _contect.SaveChanges();
            return Mapper.Map(emp,employeeDTO);
        }

        public void DeleteEmployee(long id)
        {
            _contect.Employees.Remove(_contect.Employees.Find(id));
            _contect.SaveChanges();
        }

        public void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            Employee emp = _contect.Employees.Find(employeeDTO.id);
            Mapper.Map(employeeDTO, emp);
            _contect.SaveChanges();
        }

        public DepartmentDTO AddDepartment(DepartmentDTO departmentDTO)
        {
            Department department =  Mapper.Map<DepartmentDTO,Department>(departmentDTO);
            _contect.Departments.Add(department);
            _contect.SaveChanges();
            return Mapper.Map(department, departmentDTO);
        }

        public object GetAllDepartments()
        {
            return _contect.Departments.Select(Mapper.Map<Department, DepartmentDTO>).ToList();
        }

        public void UpdateDepartment(DepartmentDTO departmentDTO)
        {
            Department department = _contect.Departments.FirstOrDefault(s => s.id == departmentDTO.id);
            Mapper.Map(departmentDTO, department);
            _contect.SaveChanges();

        }

        public void DeleteDepartment(long id)
        {
            _contect.Departments.Remove(_contect.Departments.Find(id));
            _contect.SaveChanges();
        }
    }
}
