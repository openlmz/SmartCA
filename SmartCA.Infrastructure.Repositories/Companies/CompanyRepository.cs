using System;
using System.Collections.Generic;
using System.Text;
using SmartCA.Model.Companies;
using System.Data;
using SmartCA.Infrastructure.DomainBase;

namespace SmartCA.Infrastructure.Repositories
{
    public class CompanyRepository : SqlCeRepositoryBase<Company>, ICompanyRepository
    {
        #region Private Fields

        #endregion

        #region Public Constructors

        public CompanyRepository()
            : this(null)
        {
        }

        public CompanyRepository(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
        }

        #endregion

        #region BuildChildCallbacks

        protected override void BuildChildCallbacks()
        {
        }

        #endregion

        #region GetBaseQuery

        protected override string GetBaseQuery()
        {
            return "SELECT * FROM Company c INNER JOIN CompanyAddress ca ON ca.CompanyID = c.CompanyID";
        }

        #endregion

        #region GetBaseWhereClause

        protected override string GetBaseWhereClause()
        {
            return " WHERE c.CompanyID = '{0}';";
        }

        #endregion

        #region Unit of Work Implementation

        protected override void PersistNewItem(Company item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void PersistUpdatedItem(Company item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void PersistDeletedItem(Company item)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region Private Callback and Helper Methods

        #endregion
    }
}
