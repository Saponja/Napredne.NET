using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Airport.Domain.Validation
{
    class PassangerAge : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is int i)
            {
                if (i > 3 && i < 93)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
