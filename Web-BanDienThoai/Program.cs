using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web.Persistances;
using Web.Services;
using Web.Services.implementation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<INhapHangServices, NhapHangServices>();
builder.Services.AddScoped<IChiTietHoaDonServices, ChiTietHoaDonServices>();
builder.Services.AddScoped<IHoaDonServices, HoaDonServices>();
builder.Services.AddScoped<IKhachHangServices, KhachHangServices>();
builder.Services.AddScoped<INhanVienServices, NhanVienServices>();
builder.Services.AddScoped<INhaCungCapServices, NhaCungCapServices>();
builder.Services.AddScoped<ILoaiSanPhamServices, LoaiSanPhamServices>();
builder.Services.AddScoped<IDanhMucConServices, DanhMucConServices>();
builder.Services.AddScoped<ISanPhamServices, SanPhamServices>();
builder.Services.AddScoped<IMauSacServices, MauSacServices>();
builder.Services.AddScoped<ICauHinhServices, CauHinhServices>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SanPham}/{action=Index}/{id?}");

app.Run();
