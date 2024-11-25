using System.ComponentModel.DataAnnotations;
using System.Data;

namespace EjemploEnClase.Model
{
    public class Categories
    {
        [Key] public int Id { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
