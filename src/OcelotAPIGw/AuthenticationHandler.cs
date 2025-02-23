

using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using StackExchange.Redis;
using System.Net.Http.Headers;
using System.Text;

namespace OcelotAPIGw
{
    public class AuthenticationHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor contextAccessor;

        public AuthenticationHandler(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var httpRequest = this.contextAccessor.HttpContext.Request;

            ConfigurationOptions conn = new ConfigurationOptions
            {
                EndPoints = { "host.docker.internal:14005" },
                User = "root",
                Password = "Users25!"
            };

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(conn);
            IDatabase db = redis.GetDatabase();
            
            var imageBytes = File.ReadAllBytes(Path.Combine(Environment.CurrentDirectory, "Resources/image.jpg"));

            var saml = db.StringGet("saml");
            if (saml.IsNullOrEmpty)
            {
                db.StringSet("saml", Convert.ToBase64String(imageBytes), new TimeSpan(0, 0, 20));
            }

            //var headers = request.Headers;
            return base.SendAsync(request, cancellationToken);
        }
    }
}
