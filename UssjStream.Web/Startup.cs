namespace UssjStream.Web
{
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Authentication.OpenIdConnect;
    using UssjStream.Web.Services.Videos;

    public class Startup
    {
        public Startup()
        {
            
        }
        public void ConfigureServices(WebApplicationBuilder builder)
        {
            var services = builder.Services;

            services.AddControllersWithViews();
            services.AddAuthentication(item =>
            {
                item.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                item.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
            {
                options.ResponseType = builder.Configuration["Authentication:Cognito:ResponseType"];
                options.MetadataAddress = builder.Configuration["Authentication:Cognito:MetadataAddress"];
                options.ClientId = builder.Configuration["Authentication:Cognito:ClientId"];
                options.ClientSecret = builder.Configuration["Authentication:Cognito:ClientSecret"];
                options.CallbackPath = builder.Configuration["Authentication:Cognito:CallbackPath"];
                options.Events = new OpenIdConnectEvents()
                {
                    // This method enables logout from Amazon Cognito, and it is invoked before redirecting to the identity provider to sign out
                    OnRedirectToIdentityProviderForSignOut = OnRedirectToIdentityProviderForSignOut
                };
                options.Scope.Clear();
                options.Scope.Add("openid");
                options.Scope.Add("email");
                options.Scope.Add("phone");

                options.SaveTokens = Convert.ToBoolean(builder.Configuration["Authentication:Cognito:SaveToken"]);
            });

            services.AddAuthorization();


            //Add services with DI
            services.AddTransient<IVideoService, VideoService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }


        // This method performs a Cognito sign-out, and then redirects user back to the application
        Task OnRedirectToIdentityProviderForSignOut(RedirectContext context)
        {
            // add configuration of WebApplicationBuilder            
            var builder = WebApplication.CreateBuilder();

            context.ProtocolMessage.Scope = "openid";
            context.ProtocolMessage.ResponseType = "code";

            var cognitoDomain = builder.Configuration["Authentication:Cognito:CognitoDomain"];

            var clientId = builder.Configuration["Authentication:Cognito:ClientId"];

            var logoutUrl = $"{context.Request.Scheme}://{context.Request.Host}{builder.Configuration["Authentication:Cognito:AppSignOutUrl"]}";

            context.ProtocolMessage.IssuerAddress = $"{cognitoDomain}/logout?client_id={clientId}&logout_uri={logoutUrl}";

            // delete cookies
            context.Properties.Items.Remove(CookieAuthenticationDefaults.AuthenticationScheme);
            // close openid session
            context.Properties.Items.Remove(OpenIdConnectDefaults.AuthenticationScheme);

            return Task.CompletedTask;
        }
    }
}
