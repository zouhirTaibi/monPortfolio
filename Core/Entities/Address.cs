using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
  public class Address:EntityBase
    {
        public string Street { get; set; }
        public int MyProperty { get; set; }
        public int Number { get; set; }
    }
}
