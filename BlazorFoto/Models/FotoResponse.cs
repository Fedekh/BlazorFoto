namespace BlazorFoto.Models
{
    public class FotoResponse
    {
        public int PageCurrent { get; set; }
        public int TotalPages { get; set; }
        public int TotalResult { get; set; }
        public List<Foto>? Fotos { get; set; }

    }
}
