using GitHubApiIntermediaria.Services;
using Microsoft.AspNetCore.Mvc;

namespace GitHubApiIntermediaria.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GitHubController : ControllerBase
    {
        private readonly GitHubService _gitHubService;

        public GitHubController(GitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }

        [HttpGet("repos")]
        public async Task<IActionResult> GetRepositories()
        {
            try
            {
                var repositories = await _gitHubService.GetRepositoriesAsync();
                return Ok(repositories);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter repositórios: {ex.Message}");
            }
        }
    }
}
