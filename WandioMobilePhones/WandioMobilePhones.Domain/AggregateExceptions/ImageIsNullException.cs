using System;
using System.Collections.Generic;
using System.Text;

namespace WandioMobilePhones.Domain.AggregateExceptions
{
    public class ImageIsNullException : Exception
    {
        public ImageIsNullException(string message) : base(message)
        {

        }
    }
}
