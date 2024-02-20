namespace GörHesapla.Application.Features.AuthCQRS.Command.RefreshToken
{
    public class RefreshTokenCommandResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
