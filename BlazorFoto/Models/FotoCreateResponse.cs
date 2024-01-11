
namespace BlazorFoto.Models
{
    public class FotoCreateResponse
    {
        public Foto? Foto { get; set; }
        public string? Message {  get; set; }
        public List<string>? Errors { get; internal set; }
    }
}
