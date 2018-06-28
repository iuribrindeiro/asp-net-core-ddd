using Microsoft.AspNetCore.Identity;

namespace Identity.Errors
{
    public class CustomIdentityError : IdentityError
    {
        public TipoIdentityErrorEnum Tipo { get; set; }
    }
}