
namespace API.Helpers;

public class HandleFile(IWebHostEnvironment hostEnvironment) : IHandleFile
{
    private readonly IWebHostEnvironment _hostEnvironment = hostEnvironment;

    public async Task<string> SaveFile(IFormFile file, string folder)
    {
        string name = new String(Path.GetFileNameWithoutExtension(file.FileName)
                                          .Take(10)
                                          .ToArray()
                                     ).Replace(' ', '-');

        name = $"{name}{DateTime.UtcNow.ToString("yymmssfff")}{Path.GetExtension(file.FileName)}";

        var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @$"Resources/{folder}", name);

        using (var fileStream = new FileStream(imagePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        return name;
    }

    public void DeleteFile(string name, string folder)
    {
        if (!string.IsNullOrEmpty(name)) 
        {
            var imagePath = Path.Combine(_hostEnvironment.ContentRootPath, @$"Resources/{folder}", name);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}