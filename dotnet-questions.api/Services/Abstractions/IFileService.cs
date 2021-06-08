using System.Threading.Tasks;

namespace dotnet_questions.api.Services.Abstractions
{
    public interface IFileService
    {
        string ReadFile(string filepath);
    }
}