using System;
using System.Runtime.Serialization;

namespace ECom.Abstractions
{
    [DataContract]
    public class InventoryItem
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id")]
        public Guid? Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        [DataMember(Name = "tags")]
        public string Tags { get; set; }

        /// <summary>
        /// Gets or Sets QuantityInStock
        /// </summary>
        [DataMember(Name = "quantityInStock")]
        public int QuantityInStock { get; set; } = 0;

        /// <summary>
        /// Gets or Sets Manufacturer
        /// </summary>
        [DataMember(Name = "manufacturer")]
        public Manufacturer Manufacturer { get; set; }
    }
}
