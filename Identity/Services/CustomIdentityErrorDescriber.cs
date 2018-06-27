using Identity.Errors;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DefaultError() { return new CustomIdentityError { Code = nameof(DefaultError), Description = $"Um erro desconhecido ocorreu." }; }
        public override IdentityError ConcurrencyFailure() { return new CustomIdentityError { Code = nameof(ConcurrencyFailure), Description = "Falha de concorrência otimista, o objeto foi modificado." }; }
        public override IdentityError PasswordMismatch() { return new CustomIdentityError { Code = nameof(PasswordMismatch), Description = "Senha incorreta.", Tipo = TipoIdentityErrorEnum.Password }; }
        public override IdentityError InvalidToken() { return new CustomIdentityError { Code = nameof(InvalidToken), Description = "Token inválido." }; }
        public override IdentityError LoginAlreadyAssociated() { return new CustomIdentityError { Code = nameof(LoginAlreadyAssociated), Description = "Já existe um usuário com este login.", Tipo = TipoIdentityErrorEnum.UserName }; }
        public override IdentityError InvalidUserName(string userName) { return new CustomIdentityError { Code = nameof(InvalidUserName), Description = $"Login '{userName}' é inválido, pode conter apenas letras ou dígitos.", Tipo = TipoIdentityErrorEnum.UserName }; }
        public override IdentityError InvalidEmail(string email) { return new CustomIdentityError { Code = nameof(InvalidEmail), Description = $"Email '{email}' é inválido.", Tipo = TipoIdentityErrorEnum.Email }; }
        public override IdentityError DuplicateUserName(string userName) { return new CustomIdentityError { Code = nameof(DuplicateUserName), Description = $"Login '{userName}' já está sendo utilizado.", Tipo = TipoIdentityErrorEnum.UserName}; }
        public override IdentityError DuplicateEmail(string email) { return new CustomIdentityError { Code = nameof(DuplicateEmail), Description = $"Email '{email}' já está sendo utilizado.", Tipo = TipoIdentityErrorEnum.Email }; }
        public override IdentityError InvalidRoleName(string role) { return new CustomIdentityError { Code = nameof(InvalidRoleName), Description = $"A permissão '{role}' é inválida.", Tipo = TipoIdentityErrorEnum.Permissao }; }
        public override IdentityError DuplicateRoleName(string role) { return new CustomIdentityError { Code = nameof(DuplicateRoleName), Description = $"A permissão '{role}' já está sendo utilizada.", Tipo = TipoIdentityErrorEnum.Permissao}; }
        public override IdentityError UserAlreadyHasPassword() { return new CustomIdentityError { Code = nameof(UserAlreadyHasPassword), Description = "Usuário já possui uma senha definida." }; }
        public override IdentityError UserLockoutNotEnabled() { return new CustomIdentityError { Code = nameof(UserLockoutNotEnabled), Description = "Lockout não está habilitado para este usuário." }; }
        public override IdentityError UserAlreadyInRole(string role) { return new CustomIdentityError { Code = nameof(UserAlreadyInRole), Description = $"Usuário já possui a permissão '{role}'." }; }
        public override IdentityError UserNotInRole(string role) { return new CustomIdentityError { Code = nameof(UserNotInRole), Description = $"Usuário não tem a permissão '{role}'." }; }
        public override IdentityError PasswordTooShort(int length) { return new CustomIdentityError { Code = nameof(PasswordTooShort), Description = $"Senhas devem conter ao menos {length} caracteres.", Tipo = TipoIdentityErrorEnum.Password}; }
        public override IdentityError PasswordRequiresNonAlphanumeric() { return new CustomIdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = "Senhas devem conter ao menos um caracter não alfanumérico.", Tipo = TipoIdentityErrorEnum.Password }; }
        public override IdentityError PasswordRequiresDigit() { return new CustomIdentityError { Code = nameof(PasswordRequiresDigit), Description = "Senhas devem conter ao menos um digito ('0'-'9').", Tipo = TipoIdentityErrorEnum.Password }; }
        public override IdentityError PasswordRequiresLower() { return new CustomIdentityError { Code = nameof(PasswordRequiresLower), Description = "Senhas devem conter ao menos um caracter em caixa baixa ('a'-'z').", Tipo = TipoIdentityErrorEnum.Password }; }
        public override IdentityError PasswordRequiresUpper() { return new CustomIdentityError { Code = nameof(PasswordRequiresUpper), Description = "Senhas devem conter ao menos um caracter em caixa alta ('A'-'Z').", Tipo = TipoIdentityErrorEnum.Password }; }
    }
}