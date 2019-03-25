using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RrepTest.Interfaces.IRepository;
using RrepTest.Models;
using RrepTest.MyAttributes;
using RrepTest.MyExceptions;

namespace RrepTest.Repository
{
    [UniversalDI]
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

        
        public IQueryable Aloha([FromBody]QueryInfo input)
        {
            QueryInfo info = new QueryInfo();
            var result = _context.KorisceniUredjaji.AsQueryable();
            var ruleInputs = input.Filter.Rules;
            
            Expression<Func<KoriscenjeUredjaja, bool>> whereLaqmbdaExpression = null;
            BinaryExpression binWhereExp = null;

            //var filterCondition = input.Filter.Condition;
            ParameterExpression parExp = Expression.Parameter(typeof(KoriscenjeUredjaja), "x");
            Expression findExp = null;

            foreach (var ruleInput in ruleInputs)
            {


                if (input.Filter.Condition == "and")
                {
                    findExp = Expression.Constant(true);
                    binWhereExp =
                        info.GetWhereExp<KoriscenjeUredjaja>(parExp, ruleInput.Operator, ruleInput.Property, ruleInput.Value);
                    findExp = Expression.AndAlso(findExp, binWhereExp);
                }
                else if (input.Filter.Condition == "or")
                {
                    findExp = Expression.Constant(false);
                    binWhereExp =
                        info.GetWhereExp<KoriscenjeUredjaja>(parExp, ruleInput.Operator, ruleInput.Property, ruleInput.Value);
                    findExp = Expression.OrElse(findExp, binWhereExp);
                }
                
            }

            whereLaqmbdaExpression = info.GetWhereLambda<KoriscenjeUredjaja>(findExp, parExp);

            Expression<Func<KoriscenjeUredjaja, object>> order = null;
            result = result.Where(whereLaqmbdaExpression);
            var sorters = input.Sorters;
            bool condition = false;
            foreach (var sorter in sorters)
            {
                order = info.OrderThings<KoriscenjeUredjaja>(sorter.Property, sorter.SortDirection);

                    if (sorter.SortDirection.ToLower().Equals("asc"))
                    {
                        if (!condition)
                        {
                        result = result.OrderBy(order);
                        condition = true;
                        }
                        else
                        {
                            result = ((IOrderedQueryable<KoriscenjeUredjaja>)result).ThenBy(order);
                        }
                        
                    }
                    if (sorter.SortDirection.ToLower().Equals("desc"))
                    {
                        if (!condition)
                        {
                        result = result.OrderByDescending(order);
                        condition = true;
                        }
                        else
                        {
                        result = ((IOrderedQueryable<KoriscenjeUredjaja>)result).ThenByDescending(order);
                        }
                    }          
            }

            result = result.Skip(input.Skip).Take(input.Take);

            return result;
        }

    }
}
