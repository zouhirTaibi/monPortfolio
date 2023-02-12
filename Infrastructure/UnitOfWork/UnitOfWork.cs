using Core.Interfaces;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.UnitOfWork
{
    //on va utiliser cette classe pour sauvegarder les donnees au database
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DataContext _context;
        public IGenericRepository<T> _entity;

        //Injection dependency de dataConext au niveau du constrcuetur
        public UnitOfWork(DataContext context)
        {
            this._context = context;
        }
        public IGenericRepository<T> Entity{
            get
            {
                return _entity ?? (_entity=new GenericRepository<T>(_context));
            }
            }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
