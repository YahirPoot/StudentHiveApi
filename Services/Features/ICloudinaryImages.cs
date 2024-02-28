using CloudinaryDotNet;
using CloudinaryDotNet.Actions;


public class ImageUploadService
{
    private readonly Cloudinary _cloudinary;

    public ImageUploadService(Cloudinary cloudinary)
    {
        this._cloudinary = cloudinary;
    }

    public async Task<string> UploadImageAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("No file uploaded or file is empty");
        }

        using (var stream = file.OpenReadStream())
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
                // Puedes agregar más opciones de configuración aquí, como el tamaño máximo de archivo, el formato permitido, etc.
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            return uploadResult.SecureUrl.ToString();
        }
    }
}
