﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimpMyRideContratcs.Extensions;

public static class StringExtensions
{
    public static bool IsEmpty(this string str) 
    {
        return string.IsNullOrWhiteSpace(str);
    }
    public static bool IsGuid(this string str)
    {
        return Guid.TryParse(str, out _);
    }
}
