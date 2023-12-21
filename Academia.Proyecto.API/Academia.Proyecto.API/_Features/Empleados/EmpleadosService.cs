using Academia.Proyecto.API._Common;
using Academia.Proyecto.API._Features.Empleados.Dtos;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Maps.EstadosCiviles;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace Academia.Proyecto.API._Features.Empleados
{
    public class EmpleadosService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EmpleadosService(UnitOfWorkBuilder unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork.BuilderProyectoTransporte();
            _mapper = mapper;
        }

        public Respuesta<List<EmpleadosListDto>> ListarEmpleados()
        {
            var empleadosList = (from empleados in _unitOfWork.Repository<Empleado>().AsQueryable()
                                 join estadosciviles in _unitOfWork.Repository<EstadosCivile>().AsQueryable()
                                 on empleados.EstadoCivilId equals estadosciviles.EstadoCivilId
                                 select new EmpleadosListDto
                                 {
                                     EmpleadoId = empleados.EmpleadoId,
                                     Nombre = empleados.Nombre,
                                     Apellido = empleados.Apellido,
                                     Telefono = empleados.Telefono,
                                     Identidad = empleados.Identidad,
                                     EstadoCivilId = empleados.EstadoCivilId,
                                     EstadoCivilDescripcion = estadosciviles.Descripcion,
                                 }).ToList();
            return Respuesta.Success(empleadosList, Mensajes.Proceso_Exitoso, Codigos.Success);
        }
    }
}
