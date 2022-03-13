using VNEDU.CORE.Interfaces.Repositorys;
using VNEDU.CORE.Interfaces.Services;
using VNEDU.CORE.Services;
using VNEDU.INFRASTRUCTURE.Repositorys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

builder.Services.AddControllers().AddJsonOptions(o => o.JsonSerializerOptions.PropertyNamingPolicy = null);
builder.Services.AddHttpClient();

// Xử lý DI
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IDecentralizationService, DecentralizationService>();
builder.Services.AddScoped<IDecentralizationRepository, DecentralizationRepository>();

builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();

builder.Services.AddScoped<ISchoolYearService, SchoolYearService>();
builder.Services.AddScoped<ISchoolYearRepository, SchoolYearRepository>();

builder.Services.AddScoped<ISemesterService, SemesterService>();
builder.Services.AddScoped<ISemesterRepository, SemesterRepository>();

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();

builder.Services.AddScoped<IDetailedTableScoreService, DetailedTableScoreService>();
builder.Services.AddScoped<IDetailedTableScoreRepository, DetailedTableScoreRepository>();

builder.Services.AddScoped<IStudent_ClassService, Student_ClassService>();
builder.Services.AddScoped<IStudent_ClassRepository, Student_ClassRepository>();

builder.Services.AddScoped<IStudent_SubjectService, Student_SubjectService>();
builder.Services.AddScoped<IStudent_SubjectRepository, Student_SubjectRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(o => o.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());
app.MapControllers();

app.Run();
