using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class AttachmentModel
    {
        public string Name { get; set; }
        public IFormCollection Files { get; set; }
    }
}
