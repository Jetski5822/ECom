using System;
using System.Runtime.Serialization;

namespace ECom.Abstractions
{
    [DataContract]
    public class User
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
        /// Gets or Sets a signing hash
        /// </summary>
        [DataMember(Name = "signinghash")]
        public string SigningHash { get; set; }
    }

    [DataContract]
    public class UserError
    {
        /// <summary>
        /// Gets or Sets Error
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}
