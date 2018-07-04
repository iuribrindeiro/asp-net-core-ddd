using AutoMapper;
using Domain.DTO;
using Domain.Entidades;
using Presentation.ViewModels;

namespace Presentation.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(u => u.Password, map => map.Ignore())
                .ForMember(u => u.PasswordConfirm, map => map.Ignore());
            CreateMap<UsuariosPaginadosDTO, UsuariosPaginadosViewModel>()
                .ForMember(u => u.Items, map => map.MapFrom(u => u));
        }
    }
}