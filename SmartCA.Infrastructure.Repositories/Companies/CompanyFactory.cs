using System;
using System.Collections.Generic;
using System.Text;
using SmartCA.Model.Companies;
using System.Data;
using SmartCA.Model;
using SmartCA.Infrastructure.EntityFactoryFramework;

namespace SmartCA.Infrastructure.Repositories
{
    internal class CompanyFactory : IEntityFactory<Company>
    {
        #region Field Names

        internal static class FieldNames
        {
            public const string CompanyId = "CompanyID";
            public const string CompanyName = "CompanyName";
            public const string CompanyShortName = "CompanyShortName";
            public const string CompanyAddress = "Street";
            public const string CompanyCity = "City";
            public const string CompanyState = "State";
            public const string CompanyPostalCode = "PostalCode";
            public const string Phone = "Phone";
            public const string Fax = "Fax";
            public const string Url = "URL";
            public const string Remarks = "Remarks";
        }

        #endregion

        #region IEntityFactory<Company> Members

        public Company BuildEntity(IDataReader reader)
        {
 	        Company company = new Company(reader[FieldNames.CompanyId]);
            company.Name = reader[FieldNames.CompanyName].ToString();
            company.Abbreviation = reader[FieldNames.CompanyShortName].ToString();
            company.HeadquartersAddress = new Address(reader[FieldNames.CompanyAddress].ToString(),
                                  reader[FieldNames.CompanyCity].ToString(),
                                  reader[FieldNames.CompanyState].ToString(),
                                  reader[FieldNames.CompanyPostalCode].ToString());
            return company;
        }

        #endregion
    }
}
