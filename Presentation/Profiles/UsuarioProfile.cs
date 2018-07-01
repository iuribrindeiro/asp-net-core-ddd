using AutoMapper;
using Domain.Entidades;
using Presentation.ViewModels;

namespace Presentation.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<NovoUsuarioViewModel, Usuario>();
            CreateMap<Usuario, EditUsuarioViewModel>();
            CreateMap<EditUsuarioViewModel, Usuario>();
        }
    }
}