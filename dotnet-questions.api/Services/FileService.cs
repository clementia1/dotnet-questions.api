using System.IO;
using System.Threading.Tasks;
using dotnet_questions.api.Services.Abstractions;

namespace dotnet_questions.api.Services
{
    public class FileService : IFileService
    {
        public string ReadAll(string filepath)
        {
            return File.ReadAllText(filepath);
        }
    }
}