using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ECom.Abstractions
{
    [DataContract]
    public class Invoice
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets the email address
        /// </summary>
        [DataMember(Name = "emailaddress")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or Sets the first name
        /// </summary>
        [DataMember(Name = "firstname")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets the last name
        /// </summary>
        [DataMember(Name = "lastname")]
        public string LastName { get; set; }

        /// <summary>
        /// Payments against invoice
        /// </summary>
        [DataMember(Name = "items")]
        public List<InvoiceLine> Items { get; set; }

        /// <summary>
        /// Payments against invoice
        /// </summary>
        public List<Payment> Payments { get; set; }
    }

    [DataContract]
    public class InvoiceLine
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets the last name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the last name
        /// </summary>
        [DataMember(Name = "quantity")]
        public int Quatity { get; set; }

        /// <summary>
        /// Gets or Sets the last name
        /// </summary>
        [DataMember(Name = "price")]
        public Price Price { get; set; }
    }

    [DataContract]
    public class Price {
        /// <summary>
        /// Gets or Sets the last name
        /// </summary>
        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or Sets the value of the item
        /// </summary>
        [DataMember(Name = "value")]
        public double Value { get; set; }
    }

    public class Payment
    {
        /// <summary>
        /// Gets or Sets the amount paid
        /// </summary>
        public double AmountPaid { get; set; }


        /// <summary>
        /// Gets or Sets when the payment was made
        /// </summary>
        public DateTime PaidOn { get; set; }
    }
}
