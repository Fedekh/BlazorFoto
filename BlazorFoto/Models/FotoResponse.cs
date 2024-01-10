namespace BlazorFoto.Models
{
    public class FotoResponse
    {
        public List<Foto> Fotos { get; set; }
        public int PageCurrent { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalPages { get; set; }

    }
}
