using DoeAqui.Domain.Interfaces;
using DoeAqui.Infrastructure.Context;

namespace DoeAqui.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DoeAquiContext _context;

        public UnitOfWork(DoeAquiContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return rowsAffected > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}