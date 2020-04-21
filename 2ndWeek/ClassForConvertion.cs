using System;
using System.Collections.Generic;
using System.Text;

namespace _2ndWeek
{
    // Task 3
    class ClassForConvertion : IConvertible
    {
        int value;
        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            if (value == 0)
            {
                return false;
            }
            return true;
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(value);
        }

        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(value);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(value);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(value);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(value);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(value);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return value;
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(value);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(value);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(value);
        }

        public string ToString(IFormatProvider provider)
        {
            return Convert.ToString(value);
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(value, conversionType);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(value);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(value);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(value);
        }
    }
}
