using BusinessLayer.Contracts.Customer;
using BusinessLayer.Services.Customer;
using RepositoryLayer.Common;
using RepositoryLayer.Contracts.Customer;
using RepositoryLayer.Repos.Customer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ICustomerService,CustomerService>();
builder.Services.AddTransient<ICustomerRepo, CustomerRepo>();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:8080")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod()
                                                  .AllowCredentials();
                          });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyAllowSpecificOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
