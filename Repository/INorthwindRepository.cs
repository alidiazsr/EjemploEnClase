﻿using EjemploEnClase.Model;

namespace EjemploEnClase.Repository
{
    public interface INorthwindRepository
    {
        Task<List<Employees>> ObtenerTodosLosEmpleados();

        Task<int> ObtenerCantidadEmpleados();

        Task<Employees> ObtenerEmpleadoPorID(int id);

        Task<Employees> ObtenerEmpleadosPorNombre(string nombreEmpleado);

        Task<Employees> ObtenerIDempleadoPorTitulo(string titulo);

        Task<List<Employees>> ObtenerEmpleadosPorPais(string pais);

        Task<Employees> ObtenerEmpleadoPorPais(string country);

        Task<List<Employees>> ObtenerTodosEmpleadosPorPais(string Country);

        Task<Employees> ObtenerEmpleadoMasGrande();



        Task<IEnumerable<object>> ObtenerCantidadDeEmpleadosPorTitulo();

        Task<IEnumerable<object>> ObtenerCantidadDeEmpleadosPorTitulo1();
        Task<IEnumerable<object>> ObtenerProductosConCategoria();
        Task<IEnumerable<object>> ObtenerProductosConChef();

        Task<IEnumerable<object>> ObtenerProductosConChef1();





    }
}
