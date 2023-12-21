namespace Academia.Proyecto.API._Features.Viajes.Dtos
{
    public class ViajesDetallesDto
    {
        public int ViajeDetalleId { get; set; }

        public int? ViajeId { get; set; }

        public int? SucursalXempleadoId { get; set; }

        public decimal? Kilometros { get; set; }

        public int? UsuarioCreacionId { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public int? UsuarioModificacionId { get; set; }

        public DateTime? FechaModicicacion { get; set; }
    }
}
