using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.BL.Prolfiles;
using Project.BL.Services.Abstractions;
using Project.BL.Services.Implementations;
using Project.Core.Entities;
using Project.DAL.Contexts;
using Project.DAL.Repositories.Abstractions;
using Project.DAL.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSQL")));
builder.Services.AddIdentity<AppUser, IdentityRole>(opt=>opt.Password.RequiredLength = 8).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddScoped<ITeacherRepository ,  TeacherRepository>();
builder.Services.AddScoped<IProfessionService , ProfessionService>();
builder.Services.AddScoped<ITeacherService , TeacherService>();
builder.Services.AddScoped<IProfessionRepository , ProfessionRepository>();

builder.Services.AddAutoMapper(typeof(TeacherProfile).Assembly);
builder.Services.AddAutoMapper(typeof(TeacherUpdateProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ProfessionProfile).Assembly);
builder.Services.AddAutoMapper(typeof(AppUserProfile).Assembly);



var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


/*
 Salam Hocam , zehmet olmasa Home Controlerde olan CreateTeacher ve CreateProfessionu url e elave edersiz 
bacardigim qeder her seyi yazdim , umudvaram elaciligim kesilmezz , Cox sag olun
 
 */