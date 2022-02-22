// Decompiled with JetBrains decompiler
// Type: Respect.Core.MathUtil
// Assembly: Respect.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30817935-28C5-4679-B52F-F98B1A987C96
// Assembly location: C:\Users\admin\.nuget\packages\respect.core\1.0.0\lib\net5.0\Respect.Core.dll

using System;

namespace Framework.Core
{
    public class MathUtil
    {
        public static bool FloatEqualTo(float left, float right, float epsilon)
        {
            return (double)Math.Abs(left - right) <= (double)epsilon;
        }

        public static bool FloatGreaterThan(float left, float right, float epsilon)
        {
            return MathUtil.FloatGreaterThan(left, right, epsilon, false);
        }

        public static bool FloatGreaterThanOrEqualTo(float left, float right, float epsilon)
        {
            return MathUtil.FloatGreaterThan(left, right, epsilon, true);
        }

        private static bool FloatGreaterThan(float left, float right, float epsilon, bool orEqualTo)
        {
            return MathUtil.FloatEqualTo(left, right, epsilon) ? orEqualTo : (double)left > (double)right;
        }

        public static bool FloatLessThan(float left, float right, float epsilon)
        {
            return MathUtil.FloatLessThan(left, right, epsilon, false);
        }

        public static bool FloatLessThanOrEqualTo(float left, float right, float epsilon)
        {
            return MathUtil.FloatLessThan(left, right, epsilon, true);
        }

        private static bool FloatLessThan(float left, float right, float epsilon, bool orEqualTo)
        {
            return MathUtil.FloatEqualTo(left, right, epsilon) ? orEqualTo : (double)left < (double)right;
        }

        public static bool DoubleEqualTo(double left, double right, double epsilon)
        {
            return Math.Abs(left - right) <= epsilon;
        }

        public static bool DoubleGreaterThan(double left, double right, double epsilon)
        {
            return MathUtil.DoubleGreaterThan(left, right, epsilon, false);
        }

        public static bool DoubleGreaterThanOrEqualTo(double left, double right, double epsilon)
        {
            return MathUtil.DoubleGreaterThan(left, right, epsilon, true);
        }

        private static bool DoubleGreaterThan(
          double left,
          double right,
          double epsilon,
          bool orEqualTo)
        {
            return MathUtil.DoubleEqualTo(left, right, epsilon) ? orEqualTo : left > right;
        }

        public static bool DoubleLessThan(double left, double right, double epsilon)
        {
            return MathUtil.DoubleLessThan(left, right, epsilon, false);
        }

        public static bool DoubleLessThanOrEqualTo(double left, double right, double epsilon)
        {
            return MathUtil.DoubleLessThan(left, right, epsilon, true);
        }

        private static bool DoubleLessThan(double left, double right, double epsilon, bool orEqualTo)
        {
            return MathUtil.DoubleEqualTo(left, right, epsilon) ? orEqualTo : left < right;
        }
    }
}
