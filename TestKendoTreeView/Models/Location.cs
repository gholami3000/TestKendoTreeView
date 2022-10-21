using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTree2
{
    public class Location
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
        public string? Title { get; set; }
        public string? Tag { get; set; }
        public bool IsSubLocation { get; set; }
    }
}
