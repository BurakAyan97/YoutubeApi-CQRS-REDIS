using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Exceptions
{
    public partial class UserAlreadyExistException
    {
        public class EmailAddressShouldBeValidException : BaseExceptions
        {
            public EmailAddressShouldBeValidException() : base("Böyle bir email adresi bulunmamaktadır.") { }
        }
        
    }
}
