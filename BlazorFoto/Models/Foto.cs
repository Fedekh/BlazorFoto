namespace BlazorFoto.Models
{
    public class Foto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public byte[]? ImageFile { get; set; }
        public string ImagePath => ImagePath is null ? "https://cdn.dribbble.com/users/476251/screenshots/2619255/attachments/523315/placeholder.png?resize=400x300&vertical=center"
                                                                : $"data:image/jpeg;base64, {Convert.ToBase64String(ImageFile)}";
        public Foto() { }

        public Foto(string name, string description, bool isVisible, byte[]? imageFile)
        {
            Name = name;
            Description = description;
            IsVisible = isVisible;
            ImageFile = imageFile;
        }
    }
}
