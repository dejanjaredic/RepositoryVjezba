using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RrepTest.Interfaces.IRepository;
using RrepTest.Models;
using RrepTest.MyExceptions;

namespace RrepTest.Repository
{
    public class KoriscenjeUredjajaRepository : Repository<KoriscenjeUredjaja, int>, IKoriscenjeUredjajaRepository
    {
        protected readonly DataContext _context;

        public KoriscenjeUredjajaRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public void AddData(int osoba, int device)
        {
            
            
                try
                {
                    var history = new KoriscenjeUredjaja
                    {
                        VrijemeOd = DateTime.Now,
                    };
                    var korUredjaji = _context.KorisceniUredjaji;
                    var korUredjajiQuery =
                        korUredjaji.Where(x => x.UredjajId == device && x.VrijemeDo == null).Select(y => y.Id);
                    var korId = korUredjajiQuery.FirstOrDefault();
                    var izmjena = _context.KorisceniUredjaji.Find(korId);

                    if (korUredjajiQuery.Count() != 0)
                    {
                        izmjena.VrijemeDo = DateTime.Now;
                        _context.SaveChanges();
                    }
                    
                        history.OsobaId = osoba;
                        history.UredjajId = device;
                    

                    _context.KorisceniUredjaji.Add(history);
                    
                }
                catch (ExceptionFilterTest e)
                {
                    throw (new ExceptionFilterTest("Greska Prilikom Unosa"));
                }
            
        }

    }
}
