using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace l3.Models
{
    public class DictObj
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("FIO")]
        public string FIO { get; set; }
        [JsonProperty("Telephone")]
        public string Telephone { get; set; }
    }
}