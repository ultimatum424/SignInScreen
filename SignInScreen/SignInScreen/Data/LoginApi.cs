using Refit;
using SignInScreen.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SignInScreen
{
    public interface ILoginApi
    {
        [Post("/login")]
        Task<HttpResponseMessage> TryToLogin([Body(BodySerializationMethod.UrlEncoded)] LoginEntity loginForm);

        [Post("/login")]
        Task<HttpResponseMessage> Zero();
    }

    public interface IApiFactory
    {
        ILoginApi Create();
    }
}
