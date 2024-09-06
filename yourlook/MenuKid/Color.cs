using Data.Models;

namespace yourlook.MenuKid
{
    public class Color : IColor
    {
        private readonly YourlookContext _context;
        public Color(YourlookContext context)
        {
            _context = context;
        }
        public DbColor add(DbColor dbColor)
        {
            _context.DbColors.Add(dbColor);
            _context.SaveChanges();
            return dbColor;
        }

        public DbColor delete(string colorid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DbColor> GetAllColor()
        {
            return _context.DbColors;
        }

        public DbColor GetColor(string colorid)
        {
            return _context.DbColors.Find(colorid);
        }

        public DbColor update(DbColor dbColor)
        {
            _context.Update(dbColor);
            _context.SaveChanges();
            return dbColor;
        }
    }
}
