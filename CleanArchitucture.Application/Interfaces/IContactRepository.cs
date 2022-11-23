using CleanArchitucture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitucture.Application.Interfaces
{
    public interface IContactRepository : IRepository<Contact>
    {
    }
}
