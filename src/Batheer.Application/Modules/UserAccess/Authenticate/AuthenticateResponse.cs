namespace Batheer.Application.Modules.UserAccess.Authenticate
{
    public class AuthenticateResponse
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public string User_Photo_ObjectKey { get; set; }
        public string CouncilId { get; set; }
        public string CouncilName { get; set; }
        public string Token { get; set; }

    }
}
