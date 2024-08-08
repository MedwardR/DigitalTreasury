using System;

namespace DigitalTreasury.Objects.Generic
{
    public class MonthYear : IComparable<MonthYear>, IEquatable<MonthYear>
    {
        public int Year { get; private set; }
        public Month Month { get; private set; }

        public MonthYear(Month month)
        {
            Year = DateTime.Now.Year;
            Month = month;
        }
        public MonthYear(Month month, int year)
        {
            Year = year;
            Month = month;
        }

        #region "Override Methods"
        public override string ToString()
        {
            return $"{this.Month.ToString()}, {this.Year.ToString()}";
        }

        public int CompareTo(MonthYear? other)
        {
            if (other is null) return 1;
            return this.Month.CompareTo(other.Month);
        }

        public bool Equals(MonthYear? other)
        {
            if (other is null) return false;
            return Year == other.Year && Month == other.Month;
        }
        public override bool Equals(object? obj)
        {
            if (obj is MonthYear other)
            {
                return base.Equals(other);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Year, Month);
        }
        #endregion

        #region "Operators"
        public static bool operator ==(MonthYear left, MonthYear right)
        {
            if (left is null) return right is null;
            return left.Equals(right);
        }

        public static bool operator !=(MonthYear left, MonthYear right)
        {
            return !(left == right);
        }

        public static bool operator <(MonthYear left, MonthYear right)
        {
            if (left is null) throw new ArgumentNullException(nameof(left));
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(MonthYear left, MonthYear right)
        {
            return right < left;
        }

        public static bool operator <=(MonthYear left, MonthYear right)
        {
            return left == right || left < right;
        }

        public static bool operator >=(MonthYear left, MonthYear right)
        {
            return left == right || left > right;
        }
        #endregion
    }
}
