using System;
using System.Threading.Tasks;

namespace CaseLink.Core.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //Repository<MedicalSpeciality> MedicalSpecialityRepository { get; }
        int Save();
        Task<int> SaveAsync();
    }
}