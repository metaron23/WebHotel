using WebHotel.DTO;

namespace WebHotel.Repository.EmailRepository
{
    public interface IMailRepository
    {
        bool SendMail(EmailRequestDto mailRequest);
    }
}
