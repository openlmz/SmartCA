using System;
using SmartCA.Infrastructure.DomainBase;

namespace SmartCA.Model.Companies
{
    public class Company : EntityBase
    {
        private string name;
        private string abbreviation;
        private Address address;

        public Company()
            : this(null)
        {
        }

        public Company(object key)
            : base(key)
        {
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string Abbreviation
        {
            get { return this.abbreviation; }
            set { this.abbreviation = value; }
        }

        public Address HeadquartersAddress
        {
            get { return this.address; }
            set { this.address = value; }
        }
    }
}
