using Data.Models;

namespace yourlook.MenuKid
{
    public interface ISize
    {
        DbSize add(DbSize dbSize);
        DbSize update(DbSize dbSize);

        DbSize delete(string sizeid);
        DbSize GetSize(string sizeid);

        IEnumerable<DbSize> GetAllSize();
    }
}
