namespace DutchTreat.Services

{
    public interface IMailService
    {
        void SendMessage(string to, string email, string subject, string body);
    }
}