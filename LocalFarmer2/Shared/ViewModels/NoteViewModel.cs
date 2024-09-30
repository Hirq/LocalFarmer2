namespace LocalFarmer2.Shared.ViewModels
{
    public class NoteViewModel
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public bool IsArchive { get; set; }
        public bool IsFlipped { get; set; } = false;
    }
}
