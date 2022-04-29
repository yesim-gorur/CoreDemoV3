using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddMvc(config =>
{

    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));


});

//burda yaptýgým iþlem þu sen login sayfasýndaki sayfa linklerine týkladýgýnda hata ile karþýlaþma diye seni bir return url e yönlendiriyor
builder.Services.AddMvc();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Login/Index";

}


);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

 
   



app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}"); // buradaki yapýlan þey þu bu metod eklenecek
//lakin errorpage kýsmýndaki error1 sayfasýna yönlendiriyorum kodu da yazacagým ve null da olbilir
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();//bunu yazmadan önce sisteme giriþ yapmadý bunu yazdýktan sonra giriþ yaptý
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
