using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimpMyRideContratcs.Exceptions;

public class ValidationException(string message) : Exception(message)
{
}
