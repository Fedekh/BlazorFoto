using BlazorFoto.Models;

namespace BlazorFoto.Utility
{
    public interface IRepositoryFoto
    {
        public Task<FotoResponse> GetFotos(int page=1,string? search="");
        public  Task<Foto> GetFoto(int id);
        public bool CreateFoto(Foto foto);
        public bool EditFoto(int id, Foto foto);
        public bool DeleteFoto(int id);
    }
}
