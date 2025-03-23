namespace ChatApp.Application.Service.Interfaces;
public interface IPasswordService
{
    string Hash(string password);

    bool Verify(string password, string PasswordHash);

}
