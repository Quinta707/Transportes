using Academia.Proyecto.API._Common;
using Academia.Proyecto.API._Features.SucursalesXEmpleados.Dtos;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace Academia.Proyecto.API._Features.SucursalesXEmpleados
{
    public class SucursalesXEmpleadoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SucursalesXEmpleadoService(IMapper mapper, UnitOfWorkBuilder unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork.BuilderProyectoTransporte();
        }

        public Respuesta<List<SucursalesXEmpleadoDto>> ListarSucursalXEmpleado()
        {
            var sucurslesXEmpleadoList = (from sucursalempleado in _unitOfWork.Repository<SucursalesXempleado>().AsQueryable()
                                          join empleado in _unitOfWork.Repository<Empleado>().AsQueryable()
                                          on sucursalempleado.EmpleadoId equals empleado.EmpleadoId
                                          join sucursal in _unitOfWork.Repository<Sucursale>().AsQueryable()
                                          on sucursalempleado.SucursalId equals sucursal.SucursalId
                                          select new SucursalesXEmpleadoDto
                                          {
                                              SucursalXempleadoId = sucursalempleado.SucursalXempleadoId,
                                              SucursalId = sucursalempleado.SucursalId,
                                              SucursalNombre = sucursal.Nombre,
                                              EmpleadoId = empleado.EmpleadoId,
                                              EmpleadoNombre = empleado.Nombre,
                                              EmpleadoApellido = empleado.Apellido,
                                              Kilometros = (int?)sucursalempleado.Kilometros,
                                              UsuarioCreacionId = sucursalempleado.UsuarioCreacionId,

                                          }).ToList();

            return Respuesta.Success(sucurslesXEmpleadoList, Mensajes.Proceso_Exitoso, Codigos.Success);
        }
    }
}
