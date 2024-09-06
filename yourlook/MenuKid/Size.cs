using Data.Models;

namespace yourlook.MenuKid
{
    public class Size : ISize
    {
        private readonly YourlookContext _context;
        public Size(YourlookContext context)
        {
            _context = context;
        }
        public DbSize add(DbSize dbSize)
        {
            _context.DbSizes.Add(dbSize);
            _context.SaveChanges();
            return dbSize;
        }

        public DbSize delete(string sizeid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DbSize> GetAllSize()
        {
            return _context.DbSizes;
        }

        public DbSize GetSize(string sizeid)
        {
            return _context.DbSizes.Find(sizeid);
        }

        public DbSize update(DbSize dbSize)
        {
            _context.Update(dbSize);
            _context.SaveChanges();
            return dbSize;
        }
    }
}
