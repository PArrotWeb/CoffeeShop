// builder
var builder = WebApplication.CreateBuilder(args);
RegisterServices(builder.Services);

// app
var app = builder.Build();
Configure(app);
app.Run();

void RegisterServices(IServiceCollection services)
{
	// swagger
	services.AddEndpointsApiExplorer();
	services.AddSwaggerGen();

	// db
	services.AddDbContext<CoffeeShopDb>(o =>
	{
		var connectionString = builder.Configuration.GetConnectionString("MySql");
		o.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
	});
	
	services.AddScoped<IKindRepository, KindRepository>();
	services.AddScoped<IOrderRepository, OrderRepository>();
	services.AddScoped<IPaymentMethodRepository, PaymentMethodsRepository>();
	
	// add app settings (cors)
	services.AddCors(o => o.AddPolicy("AllowAll", builder =>
	{
		builder.SetIsOriginAllowed(_ => true)
			.AllowAnyMethod()
			.AllowAnyHeader()
			.AllowCredentials();
	}));
	
	// add api
	services.AddTransient<IApi, KindsApi>();
	services.AddTransient<IApi, OrdersApi>();
	services.AddTransient<IApi, PaymentMethodsApi>();
	
	
}

void Configure(WebApplication app)
{
	// swagger
	app.UseSwagger();
	app.UseSwaggerUI();

	// db
	using var scope = app.Services.CreateScope();
	var db = scope.ServiceProvider.GetRequiredService<CoffeeShopDb>();
	db.Database.EnsureCreated();

	// app settings
	app.UseHttpsRedirection();
	app.UseCors("AllowAll");
	
	// set api
	var apis = app.Services.GetServices<IApi>();
	foreach (var api in apis)
	{
		if (api is null) throw new InvalidProgramException("Api not found");
		api.Register(app);
	}
}