using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Bll.Concrete.Filters
{
    class HttpResponseExeption
    {
        public int Status { get; set; } = 500;
        public object Value { get; set; }
    }
}
