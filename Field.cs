﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace dokumentasi
{
    public class Field
    {

    }

    class FieldInfoComparer : IComparer<FieldInfo>
    {
        public int Compare(FieldInfo a, FieldInfo b)
        {
            return String.Compare(a.Name, b.Name);
        }
    }
}
