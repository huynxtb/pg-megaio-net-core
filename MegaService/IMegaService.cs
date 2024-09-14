using CodeMegaUploadFileMegaZ.Models;

namespace CodeMegaUploadFileMegaZ.MegaService;

public interface IMegaService
{
    Task<List<MegaIOModel>> GetListAsync(string folder);
    Task<string> UploadAsync(IFormFile file, string folder);
    Task<Stream> DownloadAsync(string url);
    Task DeleteAsync(string url);
}