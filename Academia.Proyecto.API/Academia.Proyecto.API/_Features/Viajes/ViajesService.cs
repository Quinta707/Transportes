using Academia.Proyecto.API._Common;
using Academia.Proyecto.API._Features.Viajes.Dtos;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Dataflow;

namespace Academia.Proyecto.API._Features.Viajes
{
    public class ViajesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ViajesService(UnitOfWorkBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderProyectoTransporte();
            _mapper = mapper;
        }

        public Respuesta<List<ViajesListDto>> ListarViajes()
        {
            var viajesList = (from viaje in _unitOfWork.Repository<Viaje>().AsQueryable()
                              join transp in _unitOfWork.Repository<Transportista>().AsQueryable()
                              on viaje.TransportistaId equals transp.TransportistaId
                              select new ViajesListDto
                              {
                                  ViajeId = viaje.ViajeId,
                                  FechaViaje = viaje.FechaViaje,
                                  TransportistaId = transp.TransportistaId,
                                  TransportistaNombre = transp.Nombre,
                                  TransportistaApellido = transp.Apellido,
                                  TarifaPorKm = transp.TarifaPorKm,
                                  //ViajesDetalles = (from viajedetalle in _unitOfWork.Repository<ViajesDetallesListDto>().AsQueryable()
                                  //                  join viajes in _unitOfWork.Repository<ViajesListDto>().AsQueryable()
                                  //                  on viajedetalle.ViajeId equals viajes.ViajeId
                                  //                  join sucursalxempleado in _unitOfWork.Repository<SucursalesXempleado>().AsQueryable()
                                  //                  on viajedetalle.SucursalXempleadoId equals sucursalxempleado.SucursalXempleadoId
                                  //                  join empleados in _unitOfWork.Repository<Empleado>().AsQueryable()
                                  //                  on sucursalxempleado.EmpleadoId equals empleados.EmpleadoId
                                  //                  join sucursales in _unitOfWork.Repository<Sucursale>().AsQueryable()
                                  //                  on sucursalxempleado.SucursalId equals sucursales.SucursalId
                                  //                  select new ViajesDetallesListDto
                                  //                  {
                                  //                      ViajeDetalleId = viajedetalle.ViajeDetalleId,
                                  //                      EmpleadoNombre = empleados.Nombre,
                                  //                      EmpleadoApellido = empleados.Apellido,
                                  //                      SucursalNombre = sucursales.Nombre,
                                  //                      Kilometros = sucursalxempleado.Kilometros,

                                  //                  }).ToList(),

                              }).ToList();
            return Respuesta.Success(viajesList, Mensajes.Proceso_Exitoso, Codigos.Success);
        }

        //public List<Viaje> ListarViajes()
        //{
        //    List<Viaje> viajes = _unitOfWork.Repository<Viaje>().AsQueryable().ToList();
        //    return viajes;
        //}

        //public Respuesta<ViajesListDto> InsertarViaje(ViajesDto viajesDto)
        //{

        //}
    }
}

