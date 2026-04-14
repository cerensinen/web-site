var builder = WebApplication.CreateBuilder(args);

// 1. CORS Politikasýný Tanýmla (Sadece tek bir isim kullanýyoruz: "AllowAll")
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build(); // <--- Uygulama burada inþa ediliyor

// 2. Middleware Sýralamasý (Buradaki sýra çok önemlidir!)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Güvenlik Yönlendirmesi
// NOT: Eðer frontend http, backend https ise bazen yönlendirme sorun çýkarabilir. 
// Sorun devam ederse bu satýrý geçici olarak yorum satýrý yapabilirsin.
app.UseHttpsRedirection();

// CORS Politikasý mutlaka MapControllers'dan önce gelmelidir.
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();