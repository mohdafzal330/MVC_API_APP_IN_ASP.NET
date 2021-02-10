using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class DepartmentDTO
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Department()
        //{
        //    this.Employees = new HashSet<Employee>();
        //}
    
        public long id { get; set; }
        public string Name { get; set; }
        public long AddressId { get; set; }
    
        public virtual AddressDTO Address { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Employee> Employees { get; set; }
    }

    public class AddressDTO
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Address()
        //{
        //    this.Departments = new HashSet<Department>();
        //}
    
        public long Id { get; set; }
        public long Street_No { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Status { get; set; }
    
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Department> Departments { get; set; }
    }


    public class EmployeeDTO
    {        
            public long id { get; set; }
            public long DepartmentId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Mobile { get; set; }
            public int Status { get; set; }

            public virtual DepartmentDTO Department { get; set; }
        
    }
}
