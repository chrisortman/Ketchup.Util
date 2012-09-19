using System;
using System.Collections.Generic;
using System.Globalization;

namespace Ketchup.Util.ValueTypes
{
    public struct MacAddress : IComparable<MacAddress>
    {
        private Int64 _value;

        public MacAddress(string stringValueAsHex)
        {
            _value = Int64.Parse(stringValueAsHex, NumberStyles.HexNumber);
        }

        private MacAddress(Int64 value)
        {
            _value = value;
        }
        public MacAddress Add(int x)
        {
            return new MacAddress(_value + x);
        }

        public MacAddress Subtract(int x)
        {
            return new MacAddress(_value - x);
        }

        public IEnumerable<MacAddress> Adjacent(int num)
        {
            for(int i = 1; i <= num; i++)
            {
                yield return Subtract(i);
            }
            for(int i = 1; i <= num; i++)
            {
                yield return Add(i);
            }
        }

        public override string ToString()
        {
            return _value.ToString("X12");
        }

        public bool Equals(MacAddress other)
        {
            return other._value == _value;
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj))
            {
                return false;
            }
            if(obj.GetType() != typeof(MacAddress))
            {
                return false;
            }
            return Equals((MacAddress)obj);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(MacAddress left, MacAddress right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MacAddress left, MacAddress right)
        {
            return !left.Equals(right);
        }

        public static bool operator <(MacAddress lhs, MacAddress rhs)
        {
            return lhs._value < rhs._value;
        }

        public static bool operator >(MacAddress lhs, MacAddress rhs)
        {
            return lhs._value > rhs._value;
        }

        public static bool operator >=(MacAddress lhs, MacAddress rhs)
        {
            return lhs._value >= rhs._value;
        }

        public static bool operator <=(MacAddress lhs, MacAddress rhs)
        {
            return lhs._value <= rhs._value;
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(MacAddress other)
        {
            return _value.CompareTo(other._value);
        }
    }
}