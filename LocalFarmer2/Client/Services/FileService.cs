using Microsoft.AspNetCore.Components.Forms;

namespace LocalFarmer2.Client.Services
{
    public class FileService
    {
        public async Task HandleFileSelected(InputFileChangeEventArgs e, IDtoWithImage dto)
        {
            var file = e.File;

            if (file != null)
            {
                var buffer = new byte[file.Size];
                await file.OpenReadStream().ReadAsync(buffer);

                dto.ImageData = buffer;
                dto.ImageMimeType = file.ContentType;
            }
        }
    }
}
