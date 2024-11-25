using System.ComponentModel.DataAnnotations;
using System.Data;

namespace EjemploEnClase.Model
{
    public class Employees
    {
        [Key]
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }

        public DataSetDateTime BirthDate { get; set; }
    }
}
