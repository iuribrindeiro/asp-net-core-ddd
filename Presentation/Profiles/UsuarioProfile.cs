using AutoMapper;
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
                .ForMember(uvm => uvm.Password, m => m.UseValue<string>(null));
        }
    }
}