using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtService.Application.Common.Exceptions;

public class ValidatorException : Exception
{
    public ValidatorException(string name, object key) : base($"Entity \"{name}\" ({key} not found.") { }
}
