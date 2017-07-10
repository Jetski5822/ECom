using System;
using System.Runtime.Serialization;

namespace ECom.Abstractions
{
    [DataContract]
    public class OrderLine
    {
        /// <summary>
        /// Gets or Sets InventoryItemId
        /// </summary>
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or Sets Quantity
        /// </summary>
        [DataMember(Name = "quantity")]
        public int Quantity { get; set; } = 1;
    }
}
