using CleanArchitucture.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitucture.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IContactRepository contactRepository)
        {
            Contacts = contactRepository;
        }
        public IContactRepository Contacts { get; set; }
    }
}
