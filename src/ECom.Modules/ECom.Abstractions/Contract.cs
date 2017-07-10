using System;
using System.Runtime.Serialization;

namespace ECom.Abstractions
{
    [DataContract]
    public class Contract
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or Sets Account Id
        /// </summary>
        [DataMember(Name = "accountId")]
        public Guid AccountId { get; set; }

        /// <summary>
        /// Gets or Sets ContractDetails
        /// </summary>
        [DataMember(Name = "ContractDetails")]
        public string ContractDetails { get; set; }

        /// <summary>
        /// Gets or Sets if contract is approved
        /// </summary>
        [DataMember(Name = "IsApproved")]
        public bool IsApproved { get; set; }
    }
}
