using Academia.Proyecto.API._Common;
using Academia.Proyecto.API._Features.Viajes.Dtos;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using AutoMapper;
using Farsiman.Domain.Core.Standard.Repositories;
using Microsoft.EntityFrameworkCore;

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
            var viajesList = (from  viaje   in _unitOfWork.Repository<Viaje>().AsQueryable()
                              join  transp  in _unitOfWork.Repository<Transportista>().AsQueryable()
                              on    viaje.TransportistaId equals transp.TransportistaId
                              select new ViajesListDto
                              {
                                  ViajeId = viaje.ViajeId,

                              }).ToList();
            return Respuesta.Success(viajesList, Codigos.Success);
        }

        //public List<Viaje> ListarViajes()
        //{
        //    List<Viaje> viajes = _unitOfWork.Repository<Viaje>().AsQueryable().ToList();
        //    return viajes;
        //}


    }
}
