using Application.BasketHandler;
using Application.Discounts;

var builder = WebApplication.CreateBuilder(args);


if (builder.Environment.IsDevelopment())
{
    builder.Logging.AddConsole();
}
else
{
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<MarketContext>(options =>
{
    options.UseMySql(
        builder.Configuration.GetConnectionString("marketDB"),
         new MySqlServerVersion(new Version(8, 0, 38))
        );
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IGeneralPersist, GeneralPersist>();
builder.Services.AddScoped<IProductPersist, ProductPersist>();
builder.Services.AddScoped<IDiscountPersist, DiscountPersist>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<IBasketHandlerService, BasketHandlerService>();

builder.Services.AddScoped<IHandleFile, HandleFile>();

builder.Services.AddCarter();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.MapCarter();

app.UseHttpsRedirection();

app.Run();