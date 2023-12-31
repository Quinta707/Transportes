﻿namespace Academia.Proyecto.API._Features.SucursalesXEmpleados.Dtos
{
    public class SucursalesXEmpleadoDto
    {
        public int SucursalXempleadoId { get; set; }

        public int? EmpleadoId { get; set; }

        public string? EmpleadoNombre { get; set; }

        public string? EmpleadoApellido { get; set; }

        public int? SucursalId { get; set; }

        public string? SucursalNombre { get; set; }

        public int? Kilometros { get; set; }

        public int? UsuarioCreacionId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public int? UsuarioModificacionId { get; set; }

        public DateTime? FechaModicicacion { get; set; }

    }
}
