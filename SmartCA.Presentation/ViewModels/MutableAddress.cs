using System;
using SmartCA.Model;

namespace SmartCA.Presentation.ViewModels
{
    public class MutableAddress
    {
        private string street;
        private string city;
        private string state;
        private string postalCode;

        public string Street
        {
            get { return this.street; }
            set { this.street = value; }
        }

        public string City
        {
            get { return this.city; }
            set { this.city = value; }
        }

        public string State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public string PostalCode
        {
            get { return this.postalCode; }
            set { this.postalCode = value; }
        }

        public Address ToAddress()
        {
            return new Address(this.street, this.city, 
                       this.state, this.postalCode);
        }
    }
}
