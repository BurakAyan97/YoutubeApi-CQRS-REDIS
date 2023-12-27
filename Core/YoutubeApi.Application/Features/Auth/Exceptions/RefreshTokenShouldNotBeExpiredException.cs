using YoutubeApi.Application.Bases;

namespace YoutubeApi.Application.Features.Auth.Exceptions
{
    public partial class UserAlreadyExistException
    {
        public class RefreshTokenShouldNotBeExpiredException : BaseExceptions
        {
            public RefreshTokenShouldNotBeExpiredException() : base("Oturum açma süresi sona ermiştir.Lütfen tekrar giriş yapın") { }
        }
        
    }
}
