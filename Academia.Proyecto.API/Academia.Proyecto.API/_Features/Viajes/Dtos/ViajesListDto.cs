namespace Academia.Proyecto.API._Features.Viajes.Dtos
{
    public class ViajesListDto
    {
        public int ViajeId { get; set; }

        public int? TransportistaId { get; set; }

        public string? TransportistaNombre { get; set; }

        public DateTime? FechaViaje { get; set; }

        public int? TarifaPorKm { get; set; }

    }
}
