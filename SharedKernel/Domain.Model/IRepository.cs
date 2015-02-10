using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain.Model
{
    public interface IRepository<TEntity> where TEntity: Entity
    {
        IDataContext GetDataContext();
    }
}
