using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ECom.Abstractions
{
    [DataContract]
    public class OrderError
    {
        [DataMember(Name = "lines")]
        public List<OrderErrorLine> Lines { get; set; }
    }

    [DataContract]
    public class OrderErrorLine
    {
        /// <summary>
        /// Gets or Sets InventoryItemId
        /// </summary>
        [DataMember(Name = "inventoryItemId")]
        public Guid? InventoryItemId { get; set; }

        /// <summary>
        /// Gets or Sets Error
        /// </summary>
        [DataMember(Name = "error")]
        public string Error { get; set; }
    }
}
