using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class CustomLookp<KeyType,ValueType>
    {
        public KeyType Key { get; set; }
        public ValueType Value { get; set; }
    }
}
