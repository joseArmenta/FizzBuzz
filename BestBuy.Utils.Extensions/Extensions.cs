using System;

namespace BestBuy.Utils.Extensions
{
    public static class Extensions
    {
        public static bool IsNumeric(this string o)
        {
            double result;
            return double.TryParse(o, out result);
        }

        public static double ToDouble(this string o)
        {
            double result;
            double.TryParse(o, out result);

            return result;
        }
        /*
        public static bool IsNumericType(this object o)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsUInt(this object o)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsInt(this object o)
        {
            switch (Type.GetTypeCode(o.GetType()))
            {
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsDecimal(this object o)
        {
            return (Type.GetTypeCode(o.GetType()) == TypeCode.Decimal);            
        }

        public static bool IsDouble(this object o)
        {
            return (Type.GetTypeCode(o.GetType()) == TypeCode.Double);
        }

        public static bool IsSingle(this object o)
        {
            return (Type.GetTypeCode(o.GetType()) == TypeCode.Single);
        }

        //public static uint GetUIntValue(this object o)
        //{
        //    return (uint)o;
        //}*/
    }
}
