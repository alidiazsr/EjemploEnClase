using Microsoft.AspNetCore.Http;
using EjemploEnClase.Model;
using EjemploEnClase.Repository;
using Microsoft.AspNetCore.Mvc;




namespace EjemploEnClase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class NorthwindController : ControllerBase
    {


        private readonly INorthwindRepository _repository;
        public NorthwindController(INorthwindRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("api/TodosLosEmpleados")]
        public async Task<List<Employees>> ObtenerTodosLosEmpleados()
        {
            return await _repository.ObtenerTodosLosEmpleados();
        }

        [HttpGet]
        [Route("api/CantidadEmpleados")]
        public async Task<int> ObtenerCantidadEmpleados()
        {
            return await _repository.ObtenerCantidadEmpleados();
        }

        [HttpGet]
        [Route("api/EmpleadoPorID")]
        public async Task<Employees> EmpleadoPorID([FromQuery] int empleadoID)
        {
            return await _repository.ObtenerEmpleadoPorID(empleadoID);
        }

        [HttpGet]
        [Route("api/EmpleadosPorNombre")]
        public async Task<Employees> ObtenerEmpleadosPorNombre([FromQuery] string nombreEmpleado)
        {
            return await _repository.ObtenerEmpleadosPorNombre(nombreEmpleado);
        }

        [HttpGet]
        [Route("api/IDempleadoPorTitulo")]
        public async Task<Employees> ObtenerIDempleadoPorTitulo([FromQuery] string titulo)
        {
            return await _repository.ObtenerIDempleadoPorTitulo(titulo);
        }
        [HttpGet]
        [Route("api/EmpleadosPorPais")]
        public async Task<List<Employees>> ObtenerEmpleadosPorPais([FromQuery] string pais)
        {
            return await _repository.ObtenerEmpleadosPorPais(pais);
        }

        [HttpGet]
        [Route("api/EmpleadoPorPais")]
        public async Task<Employees> ObtenerEmpleadoPorPais([FromQuery] string country)
        {
            return await _repository.ObtenerEmpleadoPorPais(country);
        }


        [HttpGet]
        [Route("api/ObtenerTodosEmpleadoPorPais")]
        public async Task<List<Employees>> ObtenerTodosEmpleadoPorPais([FromQuery] string country)
        {
            return await _repository.ObtenerTodosEmpleadosPorPais(country);
        }





        [HttpGet]
        [Route("api/ObtenerEmpleadoMasGrande")]
        public async Task<Employees> ObtenerEmpleadoMasGrande()
        {
            return await _repository.ObtenerEmpleadoMasGrande();
        }




        [HttpGet]
        [Route("api/ObtenerCantidadDeEmpleadosPorTitulo")]
        public async Task<IEnumerable<object>> ObtenerCantidadDeEmpleadosPorTitulo()
        {
            return await _repository.ObtenerCantidadDeEmpleadosPorTitulo();
        }


        [HttpGet]
        [Route("api/ObtenerCantidadDeEmpleadosPorTitulo1")]
        public async Task<IEnumerable<object>> ObtenerCantidadDeEmpleadosPorTitulo1()
        {
            return await _repository.ObtenerCantidadDeEmpleadosPorTitulo();
        }


        [HttpGet]
        [Route("api/ObtenerProductosConCategoria")]

        public async Task<IEnumerable<object>> ObtenerProductosConCategoria()
        {
            return await _repository.ObtenerProductosConCategoria();
        }

        [HttpGet]
        [Route("api/ObtenerProductosConChef")]

        public async Task<IEnumerable<object>> ObtenerProductosConChef()
        {
            return await _repository.ObtenerProductosConChef();
        }

        [HttpGet]
        [Route("api/ObtenerProductosConChef1")]

        public async Task<IEnumerable<object>> ObtenerProductosConChef1()
        {
            return await _repository.ObtenerProductosConChef();
        }

    }
}
