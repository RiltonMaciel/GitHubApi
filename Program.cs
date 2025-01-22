using GitHubApiIntermediaria.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner
builder.Services.AddHttpClient<GitHubService>();

// Adicionar controllers com NewtonsoftJson
builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

// Remova ou comente qualquer redirecionamento para HTTPS
// app.UseHttpsRedirection(); // Comente ou remova esta linha, se presente

// Configurar o pipeline de requisição HTTP
app.UseRouting();

app.MapControllers();

app.Run();
