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

//burda yapt�g�m i�lem �u sen login sayfas�ndaki sayfa linklerine t�klad�g�nda hata ile kar��la�ma diye seni bir return url e y�nlendiriyor
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

 
   



app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}"); // buradaki yap�lan �ey �u bu metod eklenecek
//lakin errorpage k�sm�ndaki error1 sayfas�na y�nlendiriyorum kodu da yazacag�m ve null da olbilir
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();//bunu yazmadan �nce sisteme giri� yapmad� bunu yazd�ktan sonra giri� yapt�
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
