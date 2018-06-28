namespace Identity.Errors
{
    public enum TipoIdentityErrorEnum
    {
        Email,
        UserName,
        Password,
        Permissao,
        DefaultErro,
        ConcurrencyFailure,
        InvalidToken,
        UserAlreadyHasPassword,
        UserLockoutNotEnabled,
        UserAlreadyInRole,
        UserNotInRole
    }
}