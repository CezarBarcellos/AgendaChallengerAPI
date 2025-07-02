namespace AgendaChallenger.Domain.Commands.Create
{
    public sealed record CreateUsuarioCommand(        
        string Nome,
        string Senha
    );

}
