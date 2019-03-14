using System.Linq;
using RrepTest.Interfaces.IRepository;
using RrepTest.Models;
using RrepTest.MyAttributes;
using RrepTest.MyExceptions;

namespace RrepTest.Repository
{
    [UniversalDI]
    public class UredjajRepository : Repository<Uredjaj, int>, IUredjajRepository, IMoj
    {
        protected readonly DataContext _context;


        public UredjajRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public int GetByName(string device)
        {
            var uredjaj = _context.Uredjaji;
            var uredjajQuery =
                uredjaj.Where(x => x.Name.Equals(device)).Select(y => y.Id);
            if (!uredjajQuery.Any())
            {
                throw (new ExceptionFilterTest($"Nepostojeci Uredjaj: {device} "));
            }
            return uredjajQuery.FirstOrDefault();
        }
    }
}
