using Refit;
namespace SignInScreen.Domain
{

    
    public class LoginEntity
    {
        [AliasAs("email")]
        public string Login { get; set; }

        [AliasAs("password")]
        public string Password { get; set; }

    }
}
