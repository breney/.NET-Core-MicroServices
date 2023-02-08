using Mango.Service.Email.Messages;

namespace Mango.Service.Email.Repository
{
    public interface IEmailRepository
    {

        Task SendAndLogEmail(UpdatePaymentResultMessage message);
    }
}
