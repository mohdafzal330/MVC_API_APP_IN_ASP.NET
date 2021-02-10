using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTOs;
using APIBL;
namespace APIApplication.Controllers.API
{
    public class EmployeeController : ApiController
    {
        EmployeeBL empBL = new EmployeeBL();
        [HttpGet]
        public IHttpActionResult GetAllEMployees()
        {
            return Ok(empBL.GetAllEmployees());
        }
        [HttpGet]
        public EmployeeDTO GetEmployeeById(long id)
        {
            EmployeeDTO e = empBL.GetEmployeeById(id);
            return e;
        }
        [HttpPost]
        public IHttpActionResult InsertEmployee(EmployeeDTO employee)
        {
            EmployeeDTO e = empBL.AddEmployee(employee);
            return Created(new Uri(Request.RequestUri+"/"+e.id), e);
        }
        [HttpDelete]
        [Route("api/employee/RemoveEmployee/{id}")]
        public IHttpActionResult RemoveEmployee(long id)
        {
            empBL.DeleteEmployee(id);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult EditEmployee(EmployeeDTO employeeDTO)
        {
            empBL.UpdateEmployee(employeeDTO);
            return Ok();
        }
        [HttpPost]
        [Route("api/employee/InsertDepartment")]
        public IHttpActionResult InsertDepartment(DepartmentDTO departmentDTO)
        {
            DepartmentDTO deptDTO = empBL.AddDepartment(departmentDTO);
            return Created(new Uri(Request.RequestUri + "/" + deptDTO.id), deptDTO);
        }
        [Route("api/employee/GetAllDepartments")]
        [HttpGet]
        public IHttpActionResult GetAllDepartments()
        {
            return Ok(empBL.GetAllDepartments());
        }

        [HttpPut]
        [Route("api/employee/UpdateDepartment")]
        public IHttpActionResult UpdateDepartment(DepartmentDTO departmentDTO)
        {
            empBL.UpdateDepartment(departmentDTO);
            return Ok();
        }
        [HttpDelete]
        [Route("api/employee/RemoveDepartment/{id}")]
        public IHttpActionResult RemoveDepartment(long id)
        {
            empBL.DeleteDepartment(id);
            return Ok();
        }
    }
}
