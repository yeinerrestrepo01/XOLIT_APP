using System;
using System.Threading.Tasks;
using XOLIT.ShoppingCart.Domain.Entities;
using XOLIT.ShoppingCart.Infrastructure.Repository;

namespace CaseLink.Core.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Repository<Producto> ProductoRepository { get; }
        int Save();
        Task<int> SaveAsync();
    }
}