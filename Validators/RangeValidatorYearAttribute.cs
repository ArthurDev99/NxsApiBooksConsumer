using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIConsumer.Validators
{
    public class RangeValidatorYearAttribute: RangeAttribute
    {
        public RangeValidatorYearAttribute(int minimum) : base(minimum, DateTime.Now.Year)
        {
        }
    }
}