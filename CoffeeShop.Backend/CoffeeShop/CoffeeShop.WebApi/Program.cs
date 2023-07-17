using CoffeeShop.WebApi.Apis;
using CoffeeShop.WebApi.Data;
using CoffeeShop.WebApi.Data.Kinds;
using CoffeeShop.WebApi.Data.Orders;
using CoffeeShop.WebApi.Data.PaymentMethods;

var builder = WebApplication.CreateBuilder(args);
RegisterServices();

// app
var app = builder.Build();
Configure();
app.Run();

void RegisterServices()
{
	var services = builder.Services;
	
	// swagger
	if (builder.Environment.IsDevelopment())
	{
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();
	}
	
	// set up database
	services.AddDbContext<CoffeeShopDb>(o =>
	{
		var connectionString = builder.Configuration.GetConnectionString("MySql");
		o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
	});
	
	services.AddScoped<IKindRepository, KindRepository>();
	services.AddScoped<IOrderRepository, OrderRepository>();
	services.AddScoped<IPaymentMethodRepository, PaymentMethodsRepository>();

	// cors
	services.AddCors(o => o.AddPolicy("AllowAll", policyBuilder =>
	{
		policyBuilder.SetIsOriginAllowed(_ => true)
			.AllowAnyMethod()
			.AllowAnyHeader()
			.AllowCredentials();
	}));

	// add api
	services.AddTransient<IApi, KindsApi>();
	services.AddTransient<IApi, OrdersApi>();
	services.AddTransient<IApi, PaymentMethodsApi>();
}

void Configure()
{
	// swagger
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	// db
	using var scope = app.Services.CreateScope();
	var db = scope.ServiceProvider.GetRequiredService<CoffeeShopDb>();
	db.Database.EnsureCreated();

	// app settings
	app.UseCors("AllowAll");

	// set api
	var apis = app.Services.GetServices<IApi>();
	foreach (var api in apis)
	{
		if (api is null) throw new InvalidProgramException("Api not found");
		api.Register(app);
	}
}