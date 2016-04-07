using System;

namespace Demo.EntityFramework.Common
{
    public static class ConvertExtesions
    {
        public static Int32 ParseInt32(this object objectval)
        {
            if (objectval.IsNull())
            {
                return 0;
            }

            Int32 v;
            int.TryParse(objectval.ToString(), out v);
            return v;
        }
    }
}
