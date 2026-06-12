using MangoFusion_API.Data;
using MangoFusion_API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddControllers();

var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");

builder.Services.AddAuthentication(u =>
{
    u.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    u.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(u =>
{
    u.RequireHttpsMetadata = false;
    u.SaveToken = true;
    u.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(key)),
        ClockSkew = TimeSpan.Zero
    };
u.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
{
    OnMessageReceived = ctx =>
    {
        // fired when the middleware reads the token from the request
        var token = ctx.Request.Headers["Authorization"].FirstOrDefault();
        // optional: write to logger
        ctx.HttpContext.RequestServices.GetService<ILoggerFactory>()?
            .CreateLogger("JwtDebug")?.LogDebug("OnMessageReceived authorization: {auth}", token);
        return Task.CompletedTask;
    },
    OnAuthenticationFailed = ctx =>
    {
        ctx.HttpContext.RequestServices.GetService<ILoggerFactory>()?
            .CreateLogger("JwtDebug")?.LogError(ctx.Exception, "Authentication failed");
        // include exception message in response when debugging only
        // ctx.Response.Headers.Add("X-Auth-Error", ctx.Exception.Message);
        return Task.CompletedTask;
    },
    OnTokenValidated = ctx =>
    {
        ctx.HttpContext.RequestServices.GetService<ILoggerFactory>()?
            .CreateLogger("JwtDebug")?.LogDebug("Token validated for {sub}", ctx.Principal?.Identity?.Name);
        return Task.CompletedTask;
    },
    OnChallenge = ctx =>
    {
        ctx.HttpContext.RequestServices.GetService<ILoggerFactory>()?
            .CreateLogger("JwtDebug")?.LogWarning("OnChallenge: {error} {errorDesc}", ctx.Error, ctx.ErrorDescription);
        return Task.CompletedTask;
    }
};



});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(
    options=> { options.AddDocumentTransformer<BearerSecuritySchemeTransformer>(); });

builder.Services.AddTransient<ApiResponse>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("*"));
app.UseAuthentication();

app.UseAuthorization();


app.MapControllers();

app.Run();

internal sealed class BearerSecuritySchemeTransformer(Microsoft.AspNetCore.Authentication.IAuthenticationSchemeProvider authenticationSchemeProvider) : IOpenApiDocumentTransformer
{
    public async Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
    {
       var authenticationSchemes = await authenticationSchemeProvider.GetAllSchemesAsync();
        if (authenticationSchemes.Any(authScheme => authScheme.Name == JwtBearerDefaults.AuthenticationScheme))
        {
            var requirement = new Dictionary<string, OpenApiSecurityScheme>
            {
                [JwtBearerDefaults.AuthenticationScheme] = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    // Name = "Authorization",
                    //Description = "JWT Authorization header using the Bearer scheme."
                }
            };
            document.Components ??= new OpenApiComponents();
            document.Components.SecuritySchemes = requirement;
            
           
        }
        document.Info = new()
        {
            Title = "MangoFusion API",
            Version = "v1",
            Description = "API for MangoFusion application",

        };
    }
}