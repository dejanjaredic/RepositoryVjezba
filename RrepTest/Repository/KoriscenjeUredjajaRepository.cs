using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RrepTest.Interfaces.IRepository;
using RrepTest.Models;

namespace RrepTest.Repository
{
    public class KoriscenjeUredjajaRepository : Repository<KoriscenjeUredjaja>, IKoriscenjeUredjajaRepository
    {
        protected readonly DataContext _context;

        public KoriscenjeUredjajaRepository(DataContext context) : base(context)
        {
            _context = context;
        }



        //public IEnumerable<KoriscenjeUredjaja> GetAllData()
        //{
        //    return _context.KorisceniUredjaji.ToList();
        //}

        //public KoriscenjeUredjaja GetById(int id)
        //{
        //    return _context.KorisceniUredjaji.Find(id);
        //}

        //public void Delete(int id)
        //{
        //    var uredja = _context.KorisceniUredjaji.Find(id);
        //    _context.KorisceniUredjaji.Remove(uredja);
        //}
        //public void AddData(string name, string surname, string device)
        //{

        //    using (var transaction = _context.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            var histotry = new KoriscenjeUredjaja
        //            {
        //                VrijemeOd = DateTime.Now,
        //            };
        //            // ------------- Pretraga osobe po imenu i prezimenu i izbacivanje njenog id radi dodjele uredjaju ---------------------
        //            var osobe = _context.Osobe;
        //            var osobeQuery =
        //                osobe.Where(x => x.Ime.Equals(name) && x.Prezime.Equals(surname)).Select(osoba => osoba.Id).FirstOrDefault();
        //            // ------------------ Pretraga uredjaja i izbacivanje njegovog id --------------------
        //            var uredjaji = _context.Uredjaji;
        //            var uredjajiQuery =
        //                uredjaji.Where(x => x.Name.Equals(device)).Select(d => d.Id).FirstOrDefault();

        //            // --------------------- provjera koristi li neko dati uredjaj --------------------
        //            var korUredjaji = _context.KorisceniUredjaji;
        //            var korUredjajiQuery =
        //                korUredjaji.Where(x => x.UredjajId == uredjajiQuery && x.VrijemeDo == null).Select(y => y.Id);

        //            var izmjena = _context.KorisceniUredjaji.Find(korUredjajiQuery.FirstOrDefault());

        //            if (korUredjajiQuery.Count() != 0)
        //            {
        //                izmjena.VrijemeDo = DateTime.Now;
        //                _context.SaveChanges();
        //            }
        //            if (osobeQuery != null && uredjajiQuery != null)
        //            {
        //                histotry.OsobaId = osobeQuery;
        //                histotry.UredjajId = uredjajiQuery;
        //            }
        //            else
        //            {

        //            }

        //            //var mapingData = _mapper.Map<KoriscenjeUrednjaja>(histotry);
        //            _context.KorisceniUredjaji.Add(histotry);
        //            _context.SaveChanges();
        //            transaction.Commit();

        //        }
        //        catch (Exception e)
        //        {

        //        }
        //    }
        //}

        public void AddData(int osoba, int device)
        {
            
            using (var transaction = _context.Database.BeginTransaction())
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
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

    }
}
