namespace API.Helpers;

public interface IHandleFile
{
    Task<string> SaveFile(IFormFile file, string folder);
    void DeleteFile(string name, string folder);
}