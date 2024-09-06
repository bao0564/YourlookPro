using Data.Models;

namespace yourlook.MenuKid
{
    public interface IColor
    {
        DbColor add(DbColor dbColor);
        DbColor update(DbColor dbColor);

        DbColor delete(string colorid);
        DbColor GetColor(string colorid);

        IEnumerable<DbColor> GetAllColor();
    }
}
