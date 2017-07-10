using System.Runtime.Serialization;

namespace ECom.Abstractions
{
    [DataContract]
    public class Manufacturer
    {
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets HomePage
        /// </summary>
        [DataMember(Name = "homePage")]
        public string HomePage { get; set; }

        /// <summary>
        /// Gets or Sets Phone
        /// </summary>
        [DataMember(Name = "phone")]
        public string Phone { get; set; }
    }
}
