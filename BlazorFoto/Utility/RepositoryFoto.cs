using BlazorFoto.Components.DB;
using BlazorFoto.Components.Pages;
using BlazorFoto.Models;

namespace BlazorFoto.Utility
{
    public class RepositoryFoto : IRepositoryFoto
    {
        private Context _context;

        public RepositoryFoto(Context context)
        {
            _context = context;
        }

        public async Task<FotoResponse> GetFotos(int page = 1, string? search = "")
        {
            try
            {
                FotoResponse fotoResponse = new FotoResponse();
                IQueryable<Foto> query = _context.Foto.AsQueryable();
                int pageSize = 10;
                int totalItems;

                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(f => f.Name.Contains(search));
                    totalItems = query.Count();
                }


                List<Foto>? fotos = query.OrderBy(f => f.Id)
                                        .Skip((page - 1) * pageSize)
                                        .Take(pageSize)
                                        .ToList();

                totalItems = fotos.Count();
                int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

                fotoResponse.Fotos = fotos;
                fotoResponse.PageCurrent = page;
                fotoResponse.TotalResult = totalItems;
                fotoResponse.TotalPages = totalPages;

                return fotoResponse;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante il recupero delle foto.", ex);
            }
        }


        public async Task<Foto> GetFoto(int id)
        {
            Foto? foto = _context.Foto.Find(id);

            if (foto == null)  throw new Exception($"Nessuna foto trovata con ID {id}");
            
            return foto;
        }


        public bool CreateFoto(Foto foto)
        {
            _context.Foto.Add(foto);
            _context.SaveChanges();
            return true;

        }

        public bool EditFoto(int id, Foto foto)
        {

            Foto? fotoEdit = _context.Foto.Find(id);
            if (fotoEdit == null) throw new Exception("Foto non trovata in archivio");

            fotoEdit.Name = foto.Name;
            fotoEdit.Description = foto.Description;
            fotoEdit.IsVisible = foto.IsVisible;
            fotoEdit.ImageFile = foto.ImageFile;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteFoto(int id)
        {
            Foto? fotoDelete = _context.Foto.Find(id);

            if (fotoDelete == null)
            {
                return false;
            }

            _context.Foto.Remove(fotoDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
