using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Refit;

namespace SignInScreen
{
    public class ApiFactory: IApiFactory
    {
        public ILoginApi Create() => RestService.For<ILoginApi>(
            new HttpClient(new HttpClientHandler())
            {
                BaseAddress = new Uri("https://reqres.in/api")
            });
    }
}
