using System;

namespace SmartCA.Model
{
    /// <summary>
    /// This is an immutable Value class.
    /// </summary>
    public class Address
    {
        private string street;
        private string city;
        private string state;
        private string postalCode;

        public Address(string street, string city, string state, string postalCode)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.postalCode = postalCode;
            this.Validate();
        }

        public string Street
        {
            get { return this.street; }
        }

        public string City
        {
            get { return this.city; }
        }

        public string State
        {
            get { return this.state; }
        }

        public string PostalCode
        {
            get { return this.postalCode; }
        }

        private void Validate()
        {
            if (string.IsNullOrEmpty(this.street) ||
                string.IsNullOrEmpty(this.city) ||
                string.IsNullOrEmpty(this.state) ||
                string.IsNullOrEmpty(this.postalCode))
            {
                throw new InvalidOperationException("Invalid address.");
            }
        }
    }
}
