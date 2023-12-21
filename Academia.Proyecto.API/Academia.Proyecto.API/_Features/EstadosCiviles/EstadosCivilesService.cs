using Academia.Proyecto.API._Common;
using Academia.Proyecto.API._Features.EstadosCiviles.Dtos;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace Academia.Proyecto.API._Features.EstadosCiviles
{
    public class EstadosCivilesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EstadosCivilesService(IMapper mapper, UnitOfWorkBuilder unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork.BuilderProyectoTransporte();
        }

        public Respuesta<List<EstadosCivilesDto>> ListarEstadosCiviles()
        {
            var estadoscivlesList = (from estados in _unitOfWork.Repository<EstadosCivile>().AsQueryable()
                                     select new EstadosCivilesDto
                                     {
                                         EstadoCivilId = estados.EstadoCivilId,
                                         Descripcion = estados.Descripcion,
                                         UsuarioCreacionId = estados.UsuarioCreacionId,
                                         FechaCreacion = estados.FechaCreacion,
                                         UsuarioModificacionId = estados.UsuarioModificacionId,
                                         FechaModicicacion = estados.FechaModicicacion,

                                     }).ToList();

            return Respuesta.Success(estadoscivlesList, Mensajes.Proceso_Exitoso, Codigos.Success);
        }
    }
}
