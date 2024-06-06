using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace LocalFarmer2.Client.Services
{
    public class FileService
    {
        private readonly IJSRuntime _jsRuntime;

        public FileService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public IList<IBrowserFile> files = new List<IBrowserFile>();
        public List<string> fileNames = new List<string>();

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

        public async Task Clear(IDtoWithImage dto)
        {
            ClearVariables();
            dto.ImageData = null;
            dto.ImageMimeType = string.Empty;
            await Task.Delay(100);
        }

        private (string Base64Data, string MimeType) GetImageSrc(IDtoWithImage dto)
        {
            if (dto.ImageData == null)
            {
                return (string.Empty, string.Empty);
            }

            var base64 = Convert.ToBase64String(dto.ImageData);
            return (base64, dto.ImageMimeType);
        }

        public async Task OpenImageInNewTab(IDtoWithImage dto)
        {
            var (base64Data, mimeType) = GetImageSrc(dto);
            await _jsRuntime.InvokeVoidAsync("openBase64Image", base64Data, mimeType);

        }

        public void SetName(string name)
        {
            ClearVariables();
            fileNames.Add(name);
        }

        public async Task OnInputFileChanged(InputFileChangeEventArgs e, IDtoWithImage dto)
        {
            var file = e.File;

            if (file != null)
            {
                fileNames.Clear();
                files.Add(file);
                fileNames.Add(file.Name);

                var buffer = new byte[file.Size];
                await file.OpenReadStream().ReadAsync(buffer);

                dto.ImageData = buffer;
                dto.ImageMimeType = file.ContentType;
            }
        }

        public void ClearVariables()
        {
            fileNames.Clear();
            files.Clear();
        }
    }
}
