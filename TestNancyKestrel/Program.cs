using Microsoft.AspNetCore.Server.Kestrel.Core;
using Nancy.Owin;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseOwin(x => x.UseNancy());
//app.MapGet("/", () => "Hello World!");

app.Run();

//https://www.cnblogs.com/linezero/p/5672772.html
//http://localhost:5000
//http://localhost:5000/linezero
//http://localhost:5000/404