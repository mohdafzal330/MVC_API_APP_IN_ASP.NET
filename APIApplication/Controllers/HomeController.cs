using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using DTOs;
namespace APIApplication.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:4399/api/");
                var result = client.GetAsync("employee").Result;
                var newresult = result.Content.ReadAsAsync<List<EmployeeDTO>>().Result;
                ViewBag.Departments = newresult;
            }
            return View();
        }
        public ActionResult PostIndex()
        {
            EmployeeDTO emp = new EmployeeDTO {
                DepartmentId = 1,
                FirstName = "Mo",
                LastName = "Abjal",
                Email = "moomo",
                Password = "123",
                Mobile = "123",
                Status = 1
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:4399/api/employee/");
                var post = client.PostAsJsonAsync<EmployeeDTO>("InsertEmployee", emp);
                post.Wait();
                var result = post.Result;
                if (result.IsSuccessStatusCode)
                {
                    return Content("Done");
                }
                else
                {
                    return Content("Not Done");
                }
            }
            
        }
        public ActionResult PutIndex()
        {
            DepartmentDTO departmentDTO = new DepartmentDTO()
            {
                id = 3,
                Name = "HR",
                
            };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:4399/api/employee/");
                var result = client.PutAsJsonAsync<DepartmentDTO>("UpdateDepartment", departmentDTO).Result;
                if (result.IsSuccessStatusCode)
                {
                    return Content("Done" + result);
                }
                else
                {
                    return Content("Not Done" + result);
                }
            }
        }

        public ActionResult DeleteIndex()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:4399/api/employee/");
                var result = client.DeleteAsync("RemoveDepartment/" + 4).Result;
                if (result.IsSuccessStatusCode)
                {
                    return Content("Done " + result);
                }
                else
                {
                    return Content("Not Done " + result);

                }

            }
        }
    }
}