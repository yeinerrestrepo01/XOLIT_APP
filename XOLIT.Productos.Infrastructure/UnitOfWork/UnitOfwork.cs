using System;
using XOLIT.Productos.Infrastructure.DBContext;

namespace CaseLink.Core.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly XolitDbContext _context;


        private bool _disposed;
        //private Repository<Comment> _commentRepository;


        public UnitOfWork(XolitDbContext context)
        {
            _context = context;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        //public Repository<MedicalSpeciality> MedicalSpecialityRepository
        //{
        //    get
        //    {
        //        if (_medicalSpecialityRepository == null)
        //            _medicalSpecialityRepository = new Repository<MedicalSpeciality>(_context);

        //        return _medicalSpecialityRepository;
        //    }
        //}

        #region Entity

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing) _context.Dispose();
            _disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}