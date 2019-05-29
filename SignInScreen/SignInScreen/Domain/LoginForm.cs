using Refit;
namespace SignInScreen.Domain
{

    
    public class LoginForm
    {
        [AliasAs("email")]
        public string Login { get; set; }

        [AliasAs("password")]
        public string Password { get; set; }

    }
}
