using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTree2
{
    public class TreeItem<T>
    {
        public T Item { get; set; }
        public IEnumerable<TreeItem<T>> Items { get; set; }
        public bool HasChildren { get; set; }
        public bool Expanded { get; set; }

    }
}
