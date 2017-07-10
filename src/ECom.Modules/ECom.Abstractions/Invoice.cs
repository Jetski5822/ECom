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
        /// Gets or Sets the amount due
        /// </summary>
        public double AmountDue { get; set; }

        /// <summary>
        /// Payments against invoice
        /// </summary>
        public List<Payment> Payments { get; set; }
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
