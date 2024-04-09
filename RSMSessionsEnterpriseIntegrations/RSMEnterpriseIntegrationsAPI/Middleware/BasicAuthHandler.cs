using System.Text;

namespace RSMEnterpriseIntegrationsAPI.Middleware
{
    public class BasicAuthHandler
    {
        private readonly RequestDelegate _next;
        private readonly string _relm;

        public BasicAuthHandler(RequestDelegate next, string relm)
        {
            _next = next;
            _relm = relm;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            var header = context.Request.Headers["Authorization"].ToString();
            var encodedCreds = header.Substring(6);
            var creds = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCreds));
            string[] uidpwd = creds.Split(":");
            var user = uidpwd[0];
            var password = uidpwd[1];

            if (user != "root" || password != "root")
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }

            await _next(context);
        }
    }
}