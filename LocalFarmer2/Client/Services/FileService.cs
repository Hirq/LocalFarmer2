using Microsoft.AspNetCore.Components.Forms;

namespace LocalFarmer2.Client.Services
{
    public class FileService
    {
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

        private void ClearVariables()
        {
            fileNames.Clear();
            files.Clear();
        }
    }
}
