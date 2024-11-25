using System.ComponentModel.DataAnnotations;
using System.Data;

namespace EjemploEnClase.Model
{
    public class Products
    {

        [Key]
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public decimal UnitPrice { get; set; }

        public int CategoryID { get; set; }




    }
}
