using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ECom.Abstractions
{
    [DataContract]
    public class Order
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets what is to order
        /// </summary>
        [DataMember(Name = "items")]
        public List<OrderLine> Lines { get; set; }

        /// <summary>
        /// Gets or Sets ShippingDate
        /// </summary>
        [DataMember(Name = "shippingDate")]
        public DateTime? ShippingDate { get; set; }

        /// <summary>
        /// Order Status
        /// </summary>
        /// <value>Order Status</value>
        [DataMember(Name = "status")]
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Gets or Sets Complete
        /// </summary>
        [DataMember(Name = "complete")]
        public bool Complete { get; set; } = false;
    }
}
