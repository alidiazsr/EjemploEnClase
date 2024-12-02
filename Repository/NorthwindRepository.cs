using EjemploEnClase.Model;
using EjemploEnClase.DataContext;
using Microsoft.EntityFrameworkCore;
using EjemploEnClase.Repository;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Data.Common;
using System.Data;


namespace EjemploEnClase.Repository
{
    public class NorthwindRepository : INorthwindRepository
    {
        private readonly DataContextNorthwind _dataContext;
        public NorthwindRepository(DataContextNorthwind dataContext)
        {
            _dataContext = dataContext;
        }



        public async Task<List<Employees>> ObtenerTodosLosEmpleados()
        {
            var result = await _dataContext.Employees.ToListAsync();
            return result;
        }
        public async Task<int> ObtenerCantidadEmpleados()
        {
            var result = await _dataContext.Employees.CountAsync();
            return result;
        }

        public async Task<Employees> ObtenerEmpleadoPorID(int id)
        {
            var result = await _dataContext.Employees.Where(e => e.EmployeeID == id).FirstOrDefaultAsync();
            return result;
        }
        public async Task<Employees> ObtenerEmpleadosPorNombre(string nombreEmpleado)
        {
            var result = await _dataContext.Employees.FirstOrDefaultAsync(e => e.FirstName == nombreEmpleado);
            return result;
        }
        public async Task<Employees> ObtenerIDempleadoPorTitulo(string titulo)
        {
            var result = from emp in _dataContext.Employees where emp.Title == titulo select emp;
            return await result.FirstOrDefaultAsync();
        }

        public async Task<List<Employees>> ObtenerEmpleadosPorPais(string pais)
        {
            var result = from emp in _dataContext.Employees
                         where emp.Country == pais
                         select emp;
            return await result.ToListAsync();
        }
        public async Task<Employees> ObtenerEmpleadoPorPais(string country)
        {
            var result = from emp in _dataContext.Employees
                         where emp.Country == country
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName

                         };
            return await result.FirstOrDefaultAsync();
        }

        public async Task<List<Employees>> ObtenerTodosEmpleadosPorPais(string Country)
        {
            var result = from emp in _dataContext.Employees
                         where emp.Country == Country
                         orderby emp.FirstName
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName

                         };

            return await result.ToListAsync();
        }


        public async Task<Employees> ObtenerEmpleadoMasGrande()
        {
            var result = from emp in _dataContext.Employees
                         orderby emp.BirthDate
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName,
                             LastName = emp.LastName

                         };
            return await result.FirstOrDefaultAsync();
        }
        //obtener la cantidad de empleados por titulos. (group by)
        // 2 soluciones

        public async Task<IEnumerable<object>> ObtenerCantidadDeEmpleadosPorTitulo()
        {
            var result = from emp in _dataContext.Employees
                         group emp by emp.Title into grouped
                         select new
                         {
                             Title = grouped.Key,
                             cantidad = grouped.Count()
                         };

            return await result.ToListAsync();
        }

        public async Task<IEnumerable<object>> ObtenerCantidadDeEmpleadosPorTitulo1()
        {
            var result = from emp in _dataContext.Employees
                         select new
                         {
                             Title = emp.Title,
                             cantidad = _dataContext.Employees.Count(e => e.Title == emp.Title)
                         };
            return await result.ToListAsync();
        }


        //obtener todos los productos con su categoria(inner join)




        public async Task<IEnumerable<object>> ObtenerProductosConCategoria()
        {
            var result = from prod in _dataContext.Products
                         join cat in _dataContext.Categories on prod.CategoryID equals cat.CategoryID
                         select new
                         {
                             Producto = prod.ProductName,
                             Categoria = cat.CategoryName
                         };

            return await result.ToListAsync();

        }






        //     obtener todos los productos que contienen la palabra "chef" (similar like)

        //     otra solucion es con expresiones regulares. (regex)

        public async Task<IEnumerable<object>> ObtenerProductosConChef()
        {
            var result = from prod in _dataContext.Products
                         where prod.ProductName.Contains("chef")
                         select new
                         {
                             Producto = prod.ProductName,
                             Precio = prod.UnitPrice
                         };
            return await result.ToListAsync();
        }

        public async Task<IEnumerable<object>> ObtenerProductosConChef1()
        {
            var result = from prod in _dataContext.Products
                         where Regex.IsMatch(prod.ProductName, "chef", RegexOptions.IgnoreCase)
                         select new
                         {
                             Producto = prod.ProductName,
                             Precio = prod.UnitPrice
                         };
            return await result.ToListAsync();
        }

        public async Task<bool> EliminarOrdenPorID(int orderID)
        {
            Orders? order = await _dataContext.Orders.Where(r => r.OrderId == orderID).FirstOrDefaultAsync();
            OrderDetails? orderDetail = await _dataContext.OrderDetails.Where(r => r.OrderId == orderID).FirstOrDefaultAsync();

            _dataContext.OrderDetails.Remove(orderDetail);
            _dataContext.Orders.Remove(order);

            var resulta = await _dataContext.SaveChangesAsync();
            return resulta > 0;
        }

        public async Task<bool> ModificarNombreEmpleado(int idEmpleado, string nombre)
        {
            bool actualizado = false;
            Employees? empleado = await _dataContext.Employees.Where(e => e.EmployeeID == idEmpleado).FirstOrDefaultAsync();
            if (empleado != null)
            {
                empleado.FirstName = nombre;
                var result = await _dataContext.SaveChangesAsync();
                actualizado = result > 0;
            }
            return actualizado;

        }

        public async Task<bool> InsertarEmpleado()
        {
            Employees empleado = new Employees();
            empleado.Title = "CEO";
            empleado.Country = "Argentina";
            empleado.FirstName = "Alicia";
            empleado.LastName = "Díaz San Román";
            empleado.HireDate = DateTime.Now;
            empleado.BirthDate = DateTime.Now;
            
            var newEmployee = await _dataContext.AddAsync(empleado);
            var result =  _dataContext.SaveChanges();
            
            return (result > 0);


            
            
        }

    }
}
