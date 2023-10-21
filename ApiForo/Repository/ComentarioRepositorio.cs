using ApiForo.Data;
using ApiForo.Models;
using ApiForo.Repository.IRepository;

namespace ApiForo.Repository;

public class ComentarioRepositorio : IComentarioRepositorio
{
    private readonly AplicationDbContext _db;

    public ComentarioRepositorio(AplicationDbContext db)
    {
        _db = db;
    }

    public IEnumerable<Comentario> GetComentarios()
    {
        return _db.Comentario.ToList();
    }

    public Comentario GetComentario(int comentarioId)
    {
        return _db.Comentario.FirstOrDefault(c => c.Id == comentarioId);
    }

    public bool ExisteComentario(int id)
    {
        bool valor = _db.Comentario.Any(c => c.Id == id);
        return valor;
    }

    public bool CrearComentario(Comentario comentario)
    {
        comentario.FechaCreacion = DateTime.Now;
        _db.Comentario.Add(comentario);
        return Guardar();
    }

    public bool ActualizarComentario(Comentario comentario)
    {
        comentario.FechaCreacion = DateTime.Now;
        _db.Comentario.Update(comentario);
        return Guardar();

    }

    public bool BorrarComentario(Comentario comentario)
    {
        _db.Comentario.Remove(comentario);
        return Guardar();
    }

    public bool Guardar()
    {
        return _db.SaveChanges() >= 0 ? true : false;
    }
}