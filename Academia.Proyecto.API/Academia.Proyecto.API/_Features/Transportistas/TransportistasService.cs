using Academia.Proyecto.API._Common;
using Academia.Proyecto.API._Features.Transportistas.Dtos;
using Academia.Proyecto.API._Features.Usuarios.Dtos;
using Academia.Proyecto.API.Infrastructure;
using Academia.Proyecto.API.Infrastructure.TransporteDB.Entities;
using AutoMapper;
using Farsiman.Application.Core.Standard.DTOs;
using Farsiman.Domain.Core.Standard.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Academia.Proyecto.API._Features.Transportistas
{
    public class TransportistasService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TransportistasService(IMapper mapper, UnitOfWorkBuilder unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork.BuilderProyectoTransporte();
        }

        public Respuesta<List<TransportistasDto>> ListarTransportista()
        {
            var transportistaList = (from transp in _unitOfWork.Repository<Transportista>().AsQueryable()
                                     join estadocivil in _unitOfWork.Repository<EstadosCivile>().AsQueryable()
                                     on transp.EstadoCivilId equals estadocivil.EstadoCivilId
                                     join usuariocrea in _unitOfWork.Repository<Usuario>().AsQueryable()
                                     on transp.UsuarioCreacionId equals usuariocrea.UsuarioId
                                     //join usuadiomodifica in _unitOfWork.Repository<Usuario>().AsQueryable()
                                     //on transp.UsuarioModificacionId equals usuadiomodifica.UsuarioId
                                     select new TransportistasDto
                                     {
                                         TransportistaId = transp.TransportistaId,
                                         Nombre = transp.Nombre,
                                         Apellido = transp.Apellido,
                                         Telefono = transp.Telefono,
                                         Identidad = transp.Identidad,
                                         EstadoCivilId = transp.EstadoCivilId,
                                         EstadoCivilDescripcion = estadocivil.Descripcion,
                                         TarifaPorKm = transp.TarifaPorKm,
                                         UsuarioCreacionId = transp.UsuarioCreacionId,
                                         UsuarioCreacionNombre = usuariocrea.Usuario1,
                                         FechaCreacion = transp.FechaCreacion,
                                         UsuarioModificacionId = transp.UsuarioModificacionId,
                                         FechaModicicacion = transp.FechaModicicacion,

                                     }).ToList();
            //var transportistaList = (from transp in _unitOfWork.Repository<Transportista>().AsQueryable()
            //                         join estadocivil in _unitOfWork.Repository<EstadosCivile>().AsQueryable()
            //                         on transp.EstadoCivilId equals estadocivil.EstadoCivilId
            //                         select new TransportistasDto
            //                         {
            //                             TransportistaId = transp.TransportistaId,
            //                             Nombre = transp.Nombre,
            //                             Apellido = transp.Apellido,
            //                             Telefono = transp.Telefono,
            //                             Identidad = transp.Identidad,
            //                             EstadoCivilId = transp.EstadoCivilId,
            //                             EstadoCivilDescripcion = estadocivil.Descripcion,
            //                             TarifaPorKm = transp.TarifaPorKm,


            //                         }).ToList();
            return Respuesta.Success(transportistaList, Mensajes.Proceso_Exitoso, Codigos.Success);
        }

        //public Respuesta<Transportista> InsertarTransportista(TransportistasDto transportistasdto)
        //{
        //    _unitOfWork.Repository<Transportista>().Add(transportistasdto);
        //    _unitOfWork.SaveChanges();

        //    return Respuesta.Success(_mapper.Map<TransportistasDto>(_unitOfWork.Repository<Transportista>().Where(x => x.TransportistaId == transportistasDto.TransportistaId).FirstOrDefault()), Mensajes.Proceso_Exitoso, Codigos.Success);
            
        //}
    }
}


