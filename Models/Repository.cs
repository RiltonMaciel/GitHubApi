namespace GitHubApiIntermediaria.Models
{
    public class Repository
    {
        public string FullName { get; set; } = string.Empty; // Inicializa com string vazia
        public string Description { get; set; } = string.Empty; // Inicializa com string vazia
        public string AvatarUrl { get; set; } = string.Empty;
        
        public string Language { get; set; } = string.Empty; // Inicializa com string vazia
    }
}