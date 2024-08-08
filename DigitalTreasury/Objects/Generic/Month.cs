namespace DigitalTreasury.Objects.Generic
{
    //public class Month : IComparable<Month>, IEquatable<Month>
    //{
    //    private readonly int value;
    //    private readonly string[] names = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

    //    private Month(int value)
    //    {
    //        this.value = value;
    //    }

    //    public string Name
    //    {
    //        get
    //        {
    //            return names[value + 1];
    //        }
    //    }

    //    #region "Static Properties"
    //    public static Month January
    //    {
    //        get
    //        {
    //            return new Month(1);
    //        }
    //    }

    //    public static Month February
    //    {
    //        get
    //        {
    //            return new Month(2);
    //        }
    //    }

    //    public static Month March
    //    {
    //        get
    //        {
    //            return new Month(3);
    //        }
    //    }

    //    public static Month April
    //    {
    //        get
    //        {
    //            return new Month(4);
    //        }
    //    }

    //    public static Month May
    //    {
    //        get
    //        {
    //            return new Month(5);
    //        }
    //    }

    //    public static Month June
    //    {
    //        get
    //        {
    //            return new Month(6);
    //        }
    //    }

    //    public static Month July
    //    {
    //        get
    //        {
    //            return new Month(7);
    //        }
    //    }

    //    public static Month August
    //    {
    //        get
    //        {
    //            return new Month(8);
    //        }
    //    }

    //    public static Month September
    //    {
    //        get
    //        {
    //            return new Month(9);
    //        }
    //    }

    //    public static Month October
    //    {
    //        get
    //        {
    //            return new Month(10);
    //        }
    //    }

    //    public static Month November
    //    {
    //        get
    //        {
    //            return new Month(11);
    //        }
    //    }

    //    public static Month December
    //    {
    //        get
    //        {
    //            return new Month(12);
    //        }
    //    }
    //    #endregion

    //    #region "Override Methods"
    //    public override string ToString()
    //    {
    //        return this.Name;
    //    }

    //    public override bool Equals(object? obj)
    //    {
    //        if (obj is Month other)
    //        {
    //            return Equals(other);
    //        }
    //        return false;
    //    }
    //    public bool Equals(Month? other)
    //    {
    //        if (other is null) return false;
    //        return this.value == other.value;
    //    }

    //    public int CompareTo(Month? other)
    //    {
    //        if (other is null) return 1;
    //        return this.value - other.value;
    //    }

    //    public override int GetHashCode()
    //    {
    //        return base.GetHashCode();
    //    }
    //    #endregion

    //    #region "Operators"
    //    public static bool operator ==(Month a, Month b)
    //    {
    //        return a.value == b.value;
    //    }
    //    public static bool operator !=(Month a, Month b)
    //    {
    //        return a.value != b.value;
    //    }

    //    public static bool operator <(Month a, Month b)
    //    {
    //        return a.value < b.value;
    //    }
    //    public static bool operator >(Month a, Month b)
    //    {
    //        return a.value > b.value;
    //    }
    //    #endregion
    //}
    public enum Month
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }
}
