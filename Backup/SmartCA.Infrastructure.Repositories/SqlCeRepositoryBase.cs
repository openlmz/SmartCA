using System;
using System.Collections.Generic;
using SmartCA.Infrastructure.RepositoryFramework;
using SmartCA.Infrastructure.DomainBase;
using Microsoft.Practices.EnterpriseLibrary.Data.SqlCe;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using SmartCA.Infrastructure.EntityFactoryFramework;
using System.Text;

namespace SmartCA.Infrastructure.Repositories
{
    public abstract class SqlCeRepositoryBase<T> : RepositoryBase<T> 
        where T : EntityBase
    {
        #region AppendChildData Delegate

        /// <summary>
        /// The delegate signature required for callback methods
        /// </summary>
        /// <param name="entityAggregate"></param>
        /// <param name="childEntityKey"></param>
        public delegate void AppendChildData(T entityAggregate, 
            object childEntityKeyValue);

        #endregion

        #region Private Fields

        private Database database;
        private IEntityFactory<T> entityFactory;
        private Dictionary<string, AppendChildData> childCallbacks;
        private string baseQuery;
        private string baseWhereClause;

        #endregion

        #region Constructors

        protected SqlCeRepositoryBase() 
            : this(null)
        {
        }

        protected SqlCeRepositoryBase(IUnitOfWork unitOfWork) 
            : base(unitOfWork)
        {
            this.database = DatabaseFactory.CreateDatabase();
            this.entityFactory = EntityFactoryBuilder.BuildFactory<T>();
            this.childCallbacks = new Dictionary<string, AppendChildData>();
            this.BuildChildCallbacks();
            this.baseQuery = this.GetBaseQuery();
            this.baseWhereClause = this.GetBaseWhereClause();
        }

        #endregion

        #region Abstract Methods

        protected abstract string GetBaseQuery();
        protected abstract string GetBaseWhereClause();
        protected abstract void BuildChildCallbacks();
        protected abstract override void PersistNewItem(T item);
        protected abstract override void PersistUpdatedItem(T item);
        protected abstract override void PersistDeletedItem(T item);

        #endregion

        #region Properties

        protected Database Database
        {
            get { return this.database; }
        }

        protected Dictionary<string, AppendChildData> ChildCallbacks
        {
            get { return this.childCallbacks; }
        }

        protected string BaseQuery
        {
            get { return this.baseQuery; }
        }

        #endregion

        #region Public Methods

        public override IList<T> FindAll()
        {
            StringBuilder builder = new StringBuilder(50);
            builder.Append(this.baseQuery);
            builder.Append(";");
            return this.BuildEntitiesFromSql(builder.ToString());
        }

        public override T FindBy(object key)
        {
            StringBuilder builder = this.GetBaseQueryBuilder();
            builder.Append(this.BuildBaseWhereClause(key));
            return this.BuildEntityFromSql(builder.ToString());
        }


        #endregion

        #region Protected Methods

        protected IDataReader ExecuteReader(string sql)
        {
            DbCommand command = this.database.GetSqlStringCommand(sql);
            return this.database.ExecuteReader(command);
        }

        protected virtual T BuildEntityFromSql(string sql)
        {
            T entity = default(T);
            using (IDataReader reader = this.ExecuteReader(sql))
            {
                if (reader.Read())
                {
                    entity = this.BuildEntityFromReader(reader);
                }
            }
            return entity;
        }

        protected virtual T BuildEntityFromReader(IDataReader reader)
        {
            T entity = this.entityFactory.BuildEntity(reader);
            if (this.childCallbacks != null && this.childCallbacks.Count > 0)
            {
                object childKeyValue = null;
                DataTable columnData = reader.GetSchemaTable();
                foreach (string childKeyName in this.childCallbacks.Keys)
                {
                    if (DataHelper.ReaderContainsColumnName(columnData,
                        childKeyName))
                    {
                        childKeyValue = reader[childKeyName];
                    }
                    else
                    {
                        childKeyValue = null;
                    }
                    this.childCallbacks[childKeyName](entity, childKeyValue);
                }
            }
            return entity;
        }

        protected virtual List<T> BuildEntitiesFromSql(string sql)
        {
            List<T> entities = new List<T>();
            using (IDataReader reader = this.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    entities.Add(this.BuildEntityFromReader(reader));
                }
            }
            return entities;
        }

        protected virtual string BuildBaseWhereClause(object key)
        {
            return string.Format(this.baseWhereClause, key);
        }

        protected virtual StringBuilder GetBaseQueryBuilder()
        {
            StringBuilder builder = new StringBuilder(50);
            builder.Append(this.baseQuery);
            return builder;
        }

        #endregion
    }
}
