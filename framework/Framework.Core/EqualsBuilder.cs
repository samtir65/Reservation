// Decompiled with JetBrains decompiler
// Type: Respect.Core.EqualsBuilder
// Assembly: Respect.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30817935-28C5-4679-B52F-F98B1A987C96
// Assembly location: C:\Users\admin\.nuget\packages\respect.core\1.0.0\lib\net5.0\Respect.Core.dll

using System;
using System.Collections;
using System.Reflection;

namespace Framework.Core
{
    public class EqualsBuilder
    {
        private bool isEqual;

        public EqualsBuilder()
        {
            this.isEqual = true;
        }

        public static bool ReflectionEquals(object lhs, object rhs)
        {
            return EqualsBuilder.ReflectionEquals(lhs, rhs, false, (Type)null);
        }

        public static bool ReflectionEquals(object lhs, object rhs, bool testTransients)
        {
            return EqualsBuilder.ReflectionEquals(lhs, rhs, testTransients, (Type)null);
        }

        public static bool ReflectionEquals(
          object lhs,
          object rhs,
          bool testTransients,
          Type reflectUpToClass)
        {
            if (lhs == rhs)
                return true;
            if (lhs == null || rhs == null)
                return false;
            Type type1 = lhs.GetType();
            Type type2 = rhs.GetType();
            Type clazz;
            if (type1.IsInstanceOfType(rhs))
            {
                clazz = type1;
                if (!type2.IsInstanceOfType(lhs))
                    clazz = type2;
            }
            else
            {
                if (!type2.IsInstanceOfType(lhs))
                    return false;
                clazz = type2;
                if (!type1.IsInstanceOfType(rhs))
                    clazz = type1;
            }
            EqualsBuilder builder = new EqualsBuilder();
            try
            {
                EqualsBuilder.ReflectionAppend(lhs, rhs, clazz, builder, testTransients);
                while (clazz.BaseType != (Type)null && clazz != reflectUpToClass)
                {
                    clazz = clazz.BaseType;
                    EqualsBuilder.ReflectionAppend(lhs, rhs, clazz, builder, testTransients);
                }
            }
            catch (ArgumentException ex)
            {
                return false;
            }
            return builder.IsEquals();
        }

        private static void ReflectionAppend(
          object lhs,
          object rhs,
          Type clazz,
          EqualsBuilder builder,
          bool useTransients)
        {
            FieldInfo[] fields = clazz.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            for (int index = 0; index < fields.Length && builder.isEqual; ++index)
            {
                FieldInfo fieldInfo = fields[index];
                if (fieldInfo.Name.IndexOf('$') == -1 && (useTransients || !EqualsBuilder.isTransient(fieldInfo)) && !fieldInfo.IsStatic)
                {
                    try
                    {
                        builder.Append(fieldInfo.GetValue(lhs), fieldInfo.GetValue(rhs));
                    }
                    catch (TargetException ex)
                    {
                        throw new Exception("Unexpected TargetException", (Exception)ex);
                    }
                    catch (NotSupportedException ex)
                    {
                    }
                }
            }
        }

        public EqualsBuilder AppendSuper(bool superEquals)
        {
            if (!this.isEqual)
                return this;
            this.isEqual = superEquals;
            return this;
        }

        public EqualsBuilder Append(object lhs, object rhs)
        {
            if (!this.isEqual || lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                this.isEqual = false;
                return this;
            }
            if (!lhs.GetType().IsArray)
            {
                this.isEqual = lhs.Equals(rhs);
            }
            else
            {
                this.EnsureArraysSameDemention(lhs, rhs);
                if (!this.isEqual)
                    return this;
                switch (lhs)
                {
                    case long[] _:
                        this.Append((long[])lhs, rhs as long[]);
                        break;
                    case int[] _:
                        this.Append((int[])lhs, rhs as int[]);
                        break;
                    case short[] _:
                        this.Append((short[])lhs, rhs as short[]);
                        break;
                    case char[] _:
                        this.Append((char[])lhs, rhs as char[]);
                        break;
                    case byte[] _:
                        this.Append((byte[])lhs, rhs as byte[]);
                        break;
                    case double[] _:
                        this.Append((double[])lhs, rhs as double[]);
                        break;
                    case float[] _:
                        this.Append((float[])lhs, rhs as float[]);
                        break;
                    case bool[] _:
                        this.Append((bool[])lhs, rhs as bool[]);
                        break;
                    case object[] _:
                        this.Append((object[])lhs, rhs as object[]);
                        break;
                }
                this.CompareArrays(lhs, rhs, 0, 0);
            }
            return this;
        }

        private void EnsureArraysSameDemention(object lhs, object rhs)
        {
            if (lhs is Array != rhs is Array)
            {
                this.isEqual = false;
            }
            else
            {
                Array array1 = (Array)lhs;
                Array array2 = (Array)lhs;
                if (array1.Rank != array2.Rank)
                    this.isEqual = false;
                if (array1.Length == array2.Length)
                    return;
                this.isEqual = false;
            }
        }

        private void CompareArrays(object parray1, object parray2, int prank, int pindex)
        {
            if (!this.isEqual || parray1 == parray2)
                return;
            if (parray1 == null || parray2 == null)
            {
                this.isEqual = false;
            }
            else
            {
                Array array1 = (Array)parray1;
                Array array2 = (Array)parray2;
                int rank1 = array1.Rank;
                int rank2 = array2.Rank;
                if (rank1 != rank2)
                {
                    this.isEqual = false;
                }
                else
                {
                    int length1 = array1.GetLength(prank);
                    int length2 = array2.GetLength(prank);
                    if (length1 != length2)
                        this.isEqual = false;
                    else if (prank == rank1 - 1)
                    {
                        int num1 = 0;
                        int num2 = pindex;
                        int num3 = num2 + length1;
                        IEnumerator enumerator1 = array1.GetEnumerator();
                        IEnumerator enumerator2 = array2.GetEnumerator();
                        while (enumerator1.MoveNext() && this.isEqual)
                        {
                            enumerator2.MoveNext();
                            if (num1 >= num2 && num1 < num3)
                            {
                                object current1 = enumerator1.Current;
                                object current2 = enumerator2.Current;
                                bool flag1 = current1 is Array;
                                bool flag2 = current2 is Array;
                                if (flag1 != flag2)
                                {
                                    this.isEqual = false;
                                    break;
                                }
                                if (flag1)
                                    this.CompareArrays(current1, current2, 0, 0);
                                else
                                    this.Append(current1, current2);
                            }
                            ++num1;
                        }
                    }
                    else
                    {
                        int num = 1;
                        int dimension = rank1 - 1;
                        do
                        {
                            int length3 = array1.GetLength(dimension);
                            int length4 = array2.GetLength(dimension);
                            if (length3 != length4)
                            {
                                this.isEqual = false;
                                return;
                            }
                            num *= length3;
                            --dimension;
                        }
                        while (dimension > prank);
                        for (int index = 0; index < length1; ++index)
                        {
                            Console.Write("{ ");
                            this.CompareArrays(parray1, parray2, prank + 1, pindex + index * num);
                            Console.Write("} ");
                        }
                    }
                }
            }
        }

        public EqualsBuilder Append(long lhs, long rhs)
        {
            if (!this.isEqual)
                return this;
            this.isEqual = lhs == rhs;
            return this;
        }

        public EqualsBuilder Append(int lhs, int rhs)
        {
            if (!this.isEqual)
                return this;
            this.isEqual = lhs == rhs;
            return this;
        }

        public EqualsBuilder Append(short lhs, short rhs)
        {
            if (!this.isEqual)
                return this;
            this.isEqual = (int)lhs == (int)rhs;
            return this;
        }

        public EqualsBuilder Append(char lhs, char rhs)
        {
            if (!this.isEqual)
                return this;
            this.isEqual = (int)lhs == (int)rhs;
            return this;
        }

        public EqualsBuilder Append(byte lhs, byte rhs)
        {
            if (!this.isEqual)
                return this;
            this.isEqual = (int)lhs == (int)rhs;
            return this;
        }

        public EqualsBuilder Append(double lhs, double rhs)
        {
            return !this.isEqual ? this : this.Append(BitConverter.DoubleToInt64Bits(lhs), BitConverter.DoubleToInt64Bits(rhs));
        }

        public EqualsBuilder Append(double lhs, double rhs, double epsilon)
        {
            if (!this.isEqual)
                return this;
            this.isEqual = MathUtil.DoubleEqualTo(lhs, rhs, epsilon);
            return this;
        }

        public EqualsBuilder Append(float lhs, float rhs)
        {
            return !this.isEqual ? this : this.Append(BitConverterUtil.SingleToInt32Bits(lhs), BitConverterUtil.SingleToInt32Bits(rhs));
        }

        public EqualsBuilder Append(float lhs, float rhs, float epsilon)
        {
            if (!this.isEqual)
                return this;
            this.isEqual = MathUtil.FloatEqualTo(lhs, rhs, epsilon);
            return this;
        }

        public EqualsBuilder Append(bool lhs, bool rhs)
        {
            if (!this.isEqual)
                return this;
            this.isEqual = lhs == rhs;
            return this;
        }

        public EqualsBuilder Append(object[] lhs, object[] rhs)
        {
            if (!this.isEqual || lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                this.isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                this.isEqual = false;
                return this;
            }
            for (int index = 0; index < lhs.Length && this.isEqual; ++index)
            {
                if (lhs[index] != null && !lhs[index].GetType().IsInstanceOfType(rhs[index]))
                {
                    this.isEqual = false;
                    break;
                }
                this.Append(lhs[index], rhs[index]);
            }
            return this;
        }

        public EqualsBuilder Append(long[] lhs, long[] rhs)
        {
            if (!this.isEqual || lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                this.isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                this.isEqual = false;
                return this;
            }
            for (int index = 0; index < lhs.Length && this.isEqual; ++index)
                this.Append(lhs[index], rhs[index]);
            return this;
        }

        public EqualsBuilder Append(int[] lhs, int[] rhs)
        {
            if (!this.isEqual || lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                this.isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                this.isEqual = false;
                return this;
            }
            for (int index = 0; index < lhs.Length && this.isEqual; ++index)
                this.Append(lhs[index], rhs[index]);
            return this;
        }

        public EqualsBuilder Append(short[] lhs, short[] rhs)
        {
            if (!this.isEqual || lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                this.isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                this.isEqual = false;
                return this;
            }
            for (int index = 0; index < lhs.Length && this.isEqual; ++index)
                this.Append(lhs[index], rhs[index]);
            return this;
        }

        public EqualsBuilder Append(char[] lhs, char[] rhs)
        {
            if (!this.isEqual || lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                this.isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                this.isEqual = false;
                return this;
            }
            for (int index = 0; index < lhs.Length && this.isEqual; ++index)
                this.Append(lhs[index], rhs[index]);
            return this;
        }

        public EqualsBuilder Append(byte[] lhs, byte[] rhs)
        {
            if (!this.isEqual || lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                this.isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                this.isEqual = false;
                return this;
            }
            for (int index = 0; index < lhs.Length && this.isEqual; ++index)
                this.Append(lhs[index], rhs[index]);
            return this;
        }

        public EqualsBuilder Append(double[] lhs, double[] rhs)
        {
            if (!this.isEqual || lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                this.isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                this.isEqual = false;
                return this;
            }
            for (int index = 0; index < lhs.Length && this.isEqual; ++index)
                this.Append(lhs[index], rhs[index]);
            return this;
        }

        public EqualsBuilder Append(float[] lhs, float[] rhs)
        {
            if (!this.isEqual || lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                this.isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                this.isEqual = false;
                return this;
            }
            for (int index = 0; index < lhs.Length && this.isEqual; ++index)
                this.Append(lhs[index], rhs[index]);
            return this;
        }

        public EqualsBuilder Append(bool[] lhs, bool[] rhs)
        {
            if (!this.isEqual || lhs == rhs)
                return this;
            if (lhs == null || rhs == null)
            {
                this.isEqual = false;
                return this;
            }
            if (lhs.Length != rhs.Length)
            {
                this.isEqual = false;
                return this;
            }
            for (int index = 0; index < lhs.Length && this.isEqual; ++index)
                this.Append(lhs[index], rhs[index]);
            return this;
        }

        public bool IsEquals()
        {
            return this.isEqual;
        }

        private static bool isTransient(FieldInfo fieldInfo)
        {
            return (fieldInfo.Attributes & FieldAttributes.NotSerialized) == FieldAttributes.NotSerialized;
        }
    }
}
