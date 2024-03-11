using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace session2.Model
{
    public class Person
    {
        [JsonPropertyName("personCode")]
        public int personCode { get; set; }
        [JsonPropertyName("personRole")]
        public string? personRole { get; set; }

        public int lastSecurityPointNumber { get; set; }

        public string? lastSecurityPointDirection { get; set; }

        public string? lastSecurityPointTime { get; set; }
    }
}
