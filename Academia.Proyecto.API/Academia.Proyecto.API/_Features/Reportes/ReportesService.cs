using Academia.Proyecto.API._Common;
using Academia.Proyecto.API._Features.Reportes.Dtos;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace Academia.Proyecto.API._Features.Reportes
{
    public class ReportesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReportesService(IMapper mapper, UnitOfWorkBuilder unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork.BuilderProyectoTransporte();
        }

        public Respuesta<List<ReporteViajes>> ReporteViajesEmpleados()
        {
            var reporteList = (from empleados in _unitOfWork.Repository<Empleado>().AsQueryable()
                               join sucursalxempleado in _unitOfWork.Repository<SucursalesXempleado>().AsQueryable()
                               on empleados.EmpleadoId equals sucursalxempleado.EmpleadoId
                               join viajedet in _unitOfWork.Repository<ViajesDetalle>().AsQueryable()
                               on sucursalxempleado.SucursalXempleadoId equals viajedet.SucursalXempleadoId
                               join sucursales in _unitOfWork.Repository<Sucursale>().AsQueryable()
                               on sucursalxempleado.SucursalId equals sucursales.SucursalId
                               select new ReporteViajes
                               {
                                   EmpleadoId = empleados.EmpleadoId,
                                   EmpleadoNombre = empleados.Nombre,
                                   EmpleadoApellido = empleados.Apellido,
                                   //CantidadViajes = empleados.Count(),
                               }).ToList();
            return Respuesta.Success(reporteList, Mensajes.Proceso_Exitoso, Codigos.Success);
        }

    }
}
