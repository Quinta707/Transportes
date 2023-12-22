namespace Academia.Proyecto.API._Features.Reportes.Dtos
{
    public class ReporteTotalViajes
    {
        public int ViajeId { get; set; }

        public int? TransportistaId { get; set; }

        public string? TransportistaNombre { get; set; }

        public string? TransportistaApellido { get; set; }

        public int? TarifaPorKm { get; set; }

        public decimal? TotalViaje { get; set; }
    }
}
