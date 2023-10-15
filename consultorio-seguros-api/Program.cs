using consultorio_seguros_api.Contexto;
using consultorio_seguros_api.Utilitarios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<svrlogsContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConsultorioSQL"),
         x =>
         {
             x.MigrationsHistoryTable("HistorialMigraciones");
             x.EnableRetryOnFailure(5);
         }
        )
    );

Dependencias.AddDependencyDeclaration(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());
app.Run();
