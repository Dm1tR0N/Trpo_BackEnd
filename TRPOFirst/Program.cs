using TRPOFirst.Domian;
using TRPOFirst.Installer;
using TRPOFirst.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connection = "DefaultConnection";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AddSingleton создает один объект для всех последующих запросов,
// при этом объект создается только тогда, когда он непосредственно необходим.
// Этот метод имеет все те же перегруженые версии, что и AddTransient и AddScoped.

builder.Services.AddSingleton<IDoctorService, DoctorService>(); 
builder.Services.AddSingleton<IPacientService, PacientService>();
builder.Services.AddSingleton<IPostService, PostService>();
builder.Services.AddSingleton<IScheduleResponseService, ScheduleResponseService>();
// builder.Services.AddSingleton<IDoctorsAppointmentsService, DoctorsAppointmentsService>();

builder.Services.AddDbContext(configuration: new ConfigurationManager().GetConnectionString(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();