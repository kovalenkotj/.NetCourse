using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace _2ndWeek
{
    // Task 11 custom attribute
    class CustomAttribute : Attribute
    {

    }

    // Task 3
    class ClassForConvertion : IConvertible
    {
        int value;

        public ClassForConvertion(int value)
        {
            this.value = value;
        }
        public override string ToString()
        {
            Type type = Type.GetType("System.String");
            return $"\nTo Boolean: {ToBoolean(null)}\nTo Byte: {ToByte(null)}\nTo Char: {ToChar(null)}\nTo DateTime: {ToDateTime(null)}\n" +
                $"To Decimal: {ToDecimal(null)}\nTo Double: {ToDouble(null)}\nTo Int16: {ToInt16(null)}\nTo Int32: {ToInt32(null)}\n" +
                $"To Int64: {ToInt64(null)}\nTo SByte: {ToSByte(null)}\nTo Single: {ToSingle(null)}\nTo String: {ToString(null)}\n" +
                $"To String Type: {ToType(type, null)}\nTo UInt16: {ToUInt16(null)}\nTo UInt32: {ToUInt32(null)}\nTo UInt64: {ToUInt64(null)}";
                
        }

        // also for Task 11
        public string CustomAttributedMethods()
        {
            Type type = this.GetType();
            MethodInfo[] methods = type.GetMethods();
            string methodsStr = "\nMethods with CustomAttribute:";
            CustomAttribute customAttribute = new CustomAttribute();
            foreach(MethodInfo m in methods)
            {
                var mAttributes = m.GetCustomAttributes();
                foreach(var a in mAttributes)
                {
                    if (a.GetType() == customAttribute.GetType())
                    {
                        methodsStr += "\n" + m.Name;
                        break;
                    }
                }
            }
            return methodsStr;
        }

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
            return (byte)value;
        }


        public char ToChar(IFormatProvider provider)
        {
            //return Convert.ToChar(value);
            return (char)value;
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            if (value < 0)
            {
                return DateTime.MinValue;
            }
            DateTime dt = new DateTime(value);
            return dt;
        }

        [Custom]
        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(value);
        }

        [Custom]
        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(value);
        }

        public short ToInt16(IFormatProvider provider)
        {
            //return Convert.ToInt16(value);
            return (short)value;
        }

        [Custom]
        public int ToInt32(IFormatProvider provider)
        {
            return value;
        }

        [Custom]
        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(value);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return (sbyte)value;
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(value);
        }

        [Custom]
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
            return (ushort)value;
            //return Convert.ToUInt16(value);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return (uint)value;
            //return Convert.ToUInt32(value);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return (ulong)value;
            //return Convert.ToUInt64(value);
        }
    }
}
