// Decompiled with JetBrains decompiler
// Type: Respect.Core.HashCodeBuilder
// Assembly: Respect.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30817935-28C5-4679-B52F-F98B1A987C96
// Assembly location: C:\Users\admin\.nuget\packages\respect.core\1.0.0\lib\net5.0\Respect.Core.dll

using System;
using System.Reflection;

namespace Framework.Core
{
    public class HashCodeBuilder
    {
        private readonly int iConstant;
        private int iTotal;

        public HashCodeBuilder()
        {
            this.iConstant = 37;
            this.iTotal = 17;
        }

        public HashCodeBuilder(int initialNonZeroOddNumber, int multiplierNonZeroOddNumber)
        {
            if (initialNonZeroOddNumber == 0)
                throw new ArgumentException("HashCodeBuilder requires a non zero initial value");
            if (initialNonZeroOddNumber % 2 == 0)
                throw new ArgumentException("HashCodeBuilder requires an odd initial value");
            if (multiplierNonZeroOddNumber == 0)
                throw new ArgumentException("HashCodeBuilder requires a non zero multiplier");
            if (multiplierNonZeroOddNumber % 2 == 0)
                throw new ArgumentException("HashCodeBuilder requires an odd multiplier");
            this.iConstant = multiplierNonZeroOddNumber;
            this.iTotal = initialNonZeroOddNumber;
        }

        public static int ReflectionHashCode(object obj)
        {
            return HashCodeBuilder.ReflectionHashCode(17, 37, obj, false, (Type)null);
        }

        public static int ReflectionHashCode(object obj, bool testTransients)
        {
            return HashCodeBuilder.ReflectionHashCode(17, 37, obj, testTransients, (Type)null);
        }

        public static int ReflectionHashCode(
          int initialNonZeroOddNumber,
          int multiplierNonZeroOddNumber,
          object obj)
        {
            return HashCodeBuilder.ReflectionHashCode(initialNonZeroOddNumber, multiplierNonZeroOddNumber, obj, false, (Type)null);
        }

        public static int ReflectionHashCode(
          int initialNonZeroOddNumber,
          int multiplierNonZeroOddNumber,
          object obj,
          bool testTransients)
        {
            return HashCodeBuilder.ReflectionHashCode(initialNonZeroOddNumber, multiplierNonZeroOddNumber, obj, testTransients, (Type)null);
        }

        public static int ReflectionHashCode(
          int initialNonZeroOddNumber,
          int multiplierNonZeroOddNumber,
          object obj,
          bool testTransients,
          Type reflectUpToClass)
        {
            if (obj == null)
                throw new ArgumentException("The object to build a hash code for must not be null");
            HashCodeBuilder builder = new HashCodeBuilder(initialNonZeroOddNumber, multiplierNonZeroOddNumber);
            Type clazz = obj.GetType();
            HashCodeBuilder.reflectionAppend(obj, clazz, builder, testTransients);
            while (clazz.BaseType != (Type)null && clazz != reflectUpToClass)
            {
                clazz = clazz.BaseType;
                HashCodeBuilder.reflectionAppend(obj, clazz, builder, testTransients);
            }
            return builder.ToHashCode();
        }

        private static void reflectionAppend(
          object obj,
          Type clazz,
          HashCodeBuilder builder,
          bool useTransients)
        {
            foreach (FieldInfo field in clazz.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.GetField))
            {
                if (field.Name.IndexOf('$') == -1 && (useTransients || !HashCodeBuilder.isTransient(field)) && !field.IsStatic)
                {
                    try
                    {
                        builder.Append(field.GetValue(obj));
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Unexpected IllegalAccessException");
                    }
                }
            }
        }

        public HashCodeBuilder AppendSuper(int superHashCode)
        {
            this.iTotal = this.iTotal * this.iConstant + superHashCode;
            return this;
        }

        public HashCodeBuilder Append(object obj)
        {
            if (obj == null)
                this.iTotal *= this.iConstant;
            else if (!obj.GetType().IsArray)
            {
                this.iTotal = this.iTotal * this.iConstant + obj.GetHashCode();
            }
            else
            {
                switch (obj)
                {
                    case long[] _:
                        this.Append((long[])obj);
                        break;
                    case int[] _:
                        this.Append((int[])obj);
                        break;
                    case short[] _:
                        this.Append((short[])obj);
                        break;
                    case char[] _:
                        this.Append((char[])obj);
                        break;
                    case byte[] _:
                        this.Append((byte[])obj);
                        break;
                    case double[] _:
                        this.Append((double[])obj);
                        break;
                    case float[] _:
                        this.Append((float[])obj);
                        break;
                    case bool[] _:
                        this.Append((bool[])obj);
                        break;
                    default:
                        this.Append((object[])obj);
                        break;
                }
            }
            return this;
        }

        public HashCodeBuilder Append(long value)
        {
            this.iTotal = this.iTotal * this.iConstant + (int)(value ^ value >> 32);
            return this;
        }

        public HashCodeBuilder Append(int value)
        {
            this.iTotal = this.iTotal * this.iConstant + value;
            return this;
        }

        public HashCodeBuilder Append(short value)
        {
            this.iTotal = this.iTotal * this.iConstant + (int)value;
            return this;
        }

        public HashCodeBuilder Append(char value)
        {
            this.iTotal = this.iTotal * this.iConstant + (int)value;
            return this;
        }

        public HashCodeBuilder Append(byte value)
        {
            this.iTotal = this.iTotal * this.iConstant + (int)value;
            return this;
        }

        public HashCodeBuilder Append(double value)
        {
            return this.Append(Convert.ToInt64(value));
        }

        public HashCodeBuilder Append(float value)
        {
            this.iTotal = this.iTotal * this.iConstant + Convert.ToInt32(value);
            return this;
        }

        public HashCodeBuilder Append(bool value)
        {
            this.iTotal = this.iTotal * this.iConstant + (value ? 0 : 1);
            return this;
        }

        public HashCodeBuilder Append(object[] array)
        {
            if (array == null)
            {
                this.iTotal *= this.iConstant;
            }
            else
            {
                for (int index = 0; index < array.Length; ++index)
                    this.Append(array[index]);
            }
            return this;
        }

        public HashCodeBuilder Append(long[] array)
        {
            if (array == null)
            {
                this.iTotal *= this.iConstant;
            }
            else
            {
                for (int index = 0; index < array.Length; ++index)
                    this.Append(array[index]);
            }
            return this;
        }

        public HashCodeBuilder Append(int[] array)
        {
            if (array == null)
            {
                this.iTotal *= this.iConstant;
            }
            else
            {
                for (int index = 0; index < array.Length; ++index)
                    this.Append(array[index]);
            }
            return this;
        }

        public HashCodeBuilder Append(short[] array)
        {
            if (array == null)
            {
                this.iTotal *= this.iConstant;
            }
            else
            {
                for (int index = 0; index < array.Length; ++index)
                    this.Append(array[index]);
            }
            return this;
        }

        public HashCodeBuilder Append(char[] array)
        {
            if (array == null)
            {
                this.iTotal *= this.iConstant;
            }
            else
            {
                for (int index = 0; index < array.Length; ++index)
                    this.Append(array[index]);
            }
            return this;
        }

        public HashCodeBuilder Append(byte[] array)
        {
            if (array == null)
            {
                this.iTotal *= this.iConstant;
            }
            else
            {
                for (int index = 0; index < array.Length; ++index)
                    this.Append(array[index]);
            }
            return this;
        }

        public HashCodeBuilder Append(double[] array)
        {
            if (array == null)
            {
                this.iTotal *= this.iConstant;
            }
            else
            {
                for (int index = 0; index < array.Length; ++index)
                    this.Append(array[index]);
            }
            return this;
        }

        public HashCodeBuilder Append(float[] array)
        {
            if (array == null)
            {
                this.iTotal *= this.iConstant;
            }
            else
            {
                for (int index = 0; index < array.Length; ++index)
                    this.Append(array[index]);
            }
            return this;
        }

        public HashCodeBuilder Append(bool[] array)
        {
            if (array == null)
            {
                this.iTotal *= this.iConstant;
            }
            else
            {
                for (int index = 0; index < array.Length; ++index)
                    this.Append(array[index]);
            }
            return this;
        }

        public int ToHashCode()
        {
            return this.iTotal;
        }

        private static bool isTransient(FieldInfo fieldInfo)
        {
            return (fieldInfo.Attributes & FieldAttributes.NotSerialized) == FieldAttributes.NotSerialized;
        }
    }
}
