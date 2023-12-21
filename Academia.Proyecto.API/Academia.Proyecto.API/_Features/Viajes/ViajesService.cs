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

//namespace AcademiaFS.Proyecto.API._Features.Viajes
//{
//    public class ViajeService
//    {

//        private readonly IMapper _mapper;
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly DomainService _domainService;

//        public ViajeService(UnitOfWorkBuilder unitOfWork, IMapper mapper, DomainService validacionesDomain)
//        {
//            _unitOfWork = unitOfWork.BuilderSistemaViajes();
//            _mapper = mapper;
//            _domainService = validacionesDomain;
//        }

//        public Respuesta<List<ViajeListarDto>> ListarViajes()
//        {

//            var viajesList = (from viaje in _unitOfWork.Repository<Viaje>().AsQueryable()
//                              join tran in _unitOfWork.Repository<Transportista>().AsQueryable()
//                              on viaje.IdTransportista equals tran.IdTransportista
//                              join sucu in _unitOfWork.Repository<Sucursale>().AsQueryable()
//                              on viaje.IdSucursal equals sucu.IdSucursal
//                              select new ViajeListarDto
//                              {
//                                  IdViaje = viaje.IdViaje,
//                                  FechaYhora = viaje.FechaYhora,
//                                  IdSucursal = viaje.IdSucursal,
//                                  NombreSucursal = sucu.Nombre,
//                                  IdTransportista = viaje.IdTransportista,
//                                  NombreTransportista = $"{tran.Nombres} {tran.Apellidos}",
//                                  TarifaActual = viaje.TarifaActual,
//                                  TotalKm = viaje.TotalKm,
//                                  ViajesDetalles = (from detalles in viaje.ViajesDetalles.AsQueryable()
//                                                    join colab in _unitOfWork.Repository<Colaboradore>().AsQueryable()
//                                                    on detalles.IdColaborador equals colab.IdColaborador
//                                                    select new ViajesDetalleListarDto
//                                                    {
//                                                        IdViajeDetalle = detalles.IdViajeDetalle,
//                                                        IdViaje = detalles.IdViaje,
//                                                        IdColaborador = colab.IdColaborador,
//                                                        ColaboradorNombre = colab.Nombres,
//                                                        DistanciaActual = detalles.DistanciaActual
//                                                    }).ToList()
//                              }).ToList();


//            return Respuesta.Success(viajesList, Mensajes.PROCESO_EXITOSO, Codigos.Success);
//        }

//        public Respuesta<ViajeListarDto> InsertarViaje(ViajeDto viajeDto)
//        {
//            try
//            {
//                if (viajeDto.Admin)
//                {
//                    var viaje = _mapper.Map<Viaje>(viajeDto);
//                    viaje.UsuaCreacion = 1;
//                    viaje.FechaCreacion = DateTime.Now;

//                    viaje.TotalKm = viaje.ViajesDetalles.Select(x => x.DistanciaActual).Sum();

//                    if (viaje.ViajesDetalles.Select(g => g.IdColaborador).Count() !=
//                    viaje.ViajesDetalles.Select(g => g.IdColaborador).Distinct().Count())
//                        return Respuesta.Fault<ViajeListarDto>("No puede ingresar dos veces el mismo colaborador", Codigos.BadRequest);

//                    if (viaje.TotalKm > 100)
//                        return Respuesta.Fault<ViajeListarDto>("La distancia total no debe ser mayor a 100Km", Codigos.BadRequest);

//                    viaje.TarifaActual = (from tran in _unitOfWork.Repository<Transportista>().AsQueryable()
//                                          where tran.IdTransportista == viaje.IdTransportista
//                                          select tran.TarifaKm).FirstOrDefault();

//                    foreach (var item in viaje.ViajesDetalles)
//                    {
//                        var repiteColaboradorPorDia = from vd in _unitOfWork.Repository<ViajesDetalle>().AsQueryable()
//                                                      join v in _unitOfWork.Repository<Viaje>().AsQueryable() on vd.IdViaje equals v.IdViaje
//                                                      where vd.IdColaborador == item.IdColaborador
//                                                      && v.FechaYhora.Date == viaje.FechaYhora.Date
//                                                      select vd;

//                        if (repiteColaboradorPorDia.Count() > 0)
//                            return Respuesta.Fault<ViajeListarDto>("Uno de los colaboradores ya tiene un viaje en esa fecha", Codigos.BadRequest);
//                        else
//                        {
//                            item.DistanciaActual = (from colab in _unitOfWork.Repository<Colaboradore>().AsQueryable()
//                                                    join colabXsucu in _unitOfWork.Repository<SucursalesXcolaboradore>().AsQueryable()
//                                                    on colab.IdColaborador equals colabXsucu.IdColaborador
//                                                    where colab.IdColaborador == item.IdColaborador
//                                                    && colabXsucu.IdSucursal == viaje.IdSucursal
//                                                    select colabXsucu.DistanciaKm).FirstOrDefault();

//                            viaje.TotalKm += item.DistanciaActual;

//                            item.UsuaCreacion = viaje.UsuaCreacion;
//                            item.FechaCreacion = DateTime.Now;
//                        }
//                    }


//                    _unitOfWork.Repository<Viaje>().Add(viaje);

//                    _unitOfWork.SaveChanges();

//                    return Respuesta.Success(_mapper.Map<ViajeListarDto>(_unitOfWork.Repository<Viaje>().Where(x => x.IdViaje == viaje.IdViaje).FirstOrDefault()), Mensajes.PROCESO_EXITOSO, Codigos.Success);

//                }
//                else
//                {
//                    return Respuesta.Fault<ViajeListarDto>("Sólo los administradores pueden registrar viajes", Codigos.Unauthorized);
//                }
//            }
//            catch (Exception ex)
//            {
//                return _domainService.ValidacionCambiosBase<ViajeListarDto>(ex);
//            }
//        }

//        public Respuesta<ViajeReporteRangoFechaDto> ReporteViajes(DateTime fechaInicio, DateTime fechaFinal)
//        {
//            try
//            {
//                var reporteEncabezado = from v in _unitOfWork.Repository<Viaje>().AsQueryable()
//                                        where v.FechaYhora.Date >= fechaInicio.Date && v.FechaYhora.Date <= fechaFinal.Date
//                                        select new ViajeListarDto
//                                        {
//                                            IdViaje = v.IdViaje,
//                                            IdSucursal = v.IdSucursal,
//                                            IdTransportista = v.IdTransportista,
//                                            TarifaActual = v.TarifaActual,
//                                            TotalKm = v.TotalKm,
//                                            TotalPagar = v.TarifaActual * v.TotalKm,
//                                            FechaYhora = v.FechaYhora,
//                                            ViajesDetalles = _mapper.Map<List<ViajesDetalleListarDto>>(v.ViajesDetalles)
//                                        };

//                var totalAPagar = reporteEncabezado.Sum(v => v.TotalPagar);

//                ViajeReporteRangoFechaDto reporteTotal = new ViajeReporteRangoFechaDto
//                {
//                    totalAPagar = totalAPagar,
//                    reporte = reporteEncabezado
//                };

//                return Respuesta.Success(reporteTotal, Mensajes.PROCESO_EXITOSO, Codigos.Success);
//            }
//            catch
//            {
//                return Respuesta.Fault<ViajeReporteRangoFechaDto>(Mensajes.PROCESO_FALLIDO, Codigos.Error);
//            }
//        }
//    }
//}