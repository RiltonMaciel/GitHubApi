using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GitHubApiIntermediaria.Services
{
    public class GitHubService
    {
        private readonly HttpClient _httpClient;

        public GitHubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<GitHubRepository>> GetRepositoriesAsync()
        {
            // URL para buscar os repositórios
            var url = "https://api.github.com/orgs/takenet/repos?per_page=100";

            // Configurar cabeçalhos necessários
            _httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("request"); // GitHub exige User-Agent

            // Fazer a requisição
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Erro ao consumir a API do GitHub: {response.StatusCode}");

            // Ler e desserializar os dados
            var content = await response.Content.ReadAsStringAsync();
            var repositories = JsonSerializer.Deserialize<List<GitHubRepository>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // Filtrar apenas os repositórios com linguagem "C#"
            var filteredRepositories = repositories?
                .Where(r => r.Language == "C#") // Filtrar repositórios em C#
                .OrderBy(r => r.CreatedAt)     // Ordenar pelo mais antigo
                .Take(5)                       // Pegar os 5 primeiros
                .ToList();

#pragma warning disable CS8603 // Possível retorno de referência nula
            return filteredRepositories;
#pragma warning restore CS8603
        }
    }

    public class GitHubRepository
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("full_name")]
        public required string FullName { get; set; }

        [JsonPropertyName("description")]
        public required string Description { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("owner")]
        public required Owner Owner { get; set; }

        [JsonPropertyName("language")]
        public required string Language { get; set; }
    }

    public class Owner
    {
        [JsonPropertyName("avatar_url")]
        public required string AvatarUrl { get; set; }
    }
}
