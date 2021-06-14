using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    class Texno
    {
        public class GeoData
        {
            public List<double> coordinates { get; set; }
            public string type { get; set; }
        }

        public class Cells
        {
            public string Name { get; set; }
            public int global_id { get; set; }
            public string AdmArea { get; set; }
            public string District { get; set; }
            public string Address { get; set; }
            public List<object> PublicPhone { get; set; }
            public string WebSite { get; set; }
            public List<object> Specialty { get; set; }
            public string Infrastructure { get; set; }
            public GeoData geoData { get; set; }
        }

        public class Root
        {
            public int global_id { get; set; }
            public int Number { get; set; }
            public Cells Cells { get; set; }
        }
    }
}
