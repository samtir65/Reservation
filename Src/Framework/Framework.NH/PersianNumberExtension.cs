// Decompiled with JetBrains decompiler
// Type: Respect.Core.Utilities.PersianNumberExtension
// Assembly: Respect.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 30817935-28C5-4679-B52F-F98B1A987C96
// Assembly location: C:\Users\admin\.nuget\packages\respect.core\1.0.0\lib\net5.0\Respect.Core.dll

using System;
using System.Collections.Generic;

namespace Framework.NH
{
    public static class PersianNumberExtension
    {
        public static string ConvertNumbersToEnglish(this string persianString)
        {
            try
            {
                return PersianNumberExtension.ConvertToEnglishNumber(persianString);
            }
            catch (Exception ex)
            {
                return persianString;
            }
        }

        private static string ConvertToEnglishNumber(string persianString)
        {
            foreach (KeyValuePair<char, char> keyValuePair in new Dictionary<char, char>()
            {
                ['۰'] = '0',
                ['۱'] = '1',
                ['۲'] = '2',
                ['۳'] = '3',
                ['۴'] = '4',
                ['۵'] = '5',
                ['۶'] = '6',
                ['۷'] = '7',
                ['۸'] = '8',
                ['۹'] = '9'
            })
                persianString = persianString.Replace(keyValuePair.Key, keyValuePair.Value);
            return persianString;
        }
    }
}