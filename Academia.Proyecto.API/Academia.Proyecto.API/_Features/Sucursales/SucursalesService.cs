using Academia.Proyecto.API._Common;
using Academia.Proyecto.API._Features.Sucursales.Dtos;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;

namespace Academia.Proyecto.API._Features.Sucursales
{
    public class SucursalesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SucursalesService(IMapper mapper, UnitOfWorkBuilder unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork.BuilderProyectoTransporte();
        }

        public Respuesta<List<SucursalesDto>> ListarSucursales()
        {
            var sucursalesList = (from sucursales in _unitOfWork.Repository<Sucursale>().AsQueryable()
                                  select new SucursalesDto
                                  {
                                      SucursalId = sucursales.SucursalId,
                                      Nombre = sucursales.Nombre,
                                      UsuarioCreacionId = sucursales.UsuarioCreacionId,
                                      FechaCreacion = sucursales.FechaCreacion,
                                      UsuarioModificacionId = sucursales.UsuarioModificacionId,
                                      FechaModicicacion = sucursales.FechaModicicacion,
                                  }).ToList();
            return Respuesta.Success(sucursalesList, Mensajes.Proceso_Exitoso, Codigos.Success);
        }
    }
}
