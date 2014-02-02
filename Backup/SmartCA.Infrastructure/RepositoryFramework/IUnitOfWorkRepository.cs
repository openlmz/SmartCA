using System;
using SmartCA.Infrastructure.DomainBase;

namespace SmartCA.Infrastructure.RepositoryFramework
{
    public interface IUnitOfWorkRepository
    {
        void PersistNewItem(EntityBase item);
        void PersistUpdatedItem(EntityBase item);
        void PersistDeletedItem(EntityBase item);
    }
}