// Decompiled with JetBrains decompiler
// Type: Respect.Core.DataFilter.PageResult`1
// Assembly: Respect.Core, Version=1.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8C733E-D4A0-4C42-95C0-31B55392E3C3
// Assembly location: C:\Users\admin\.nuget\packages\respect.core\1.0.1\lib\net5.0\Respect.Core.dll

using System.Collections.Generic;

namespace Framework.Core
{
    public class PageResult<T>
    {
        public List<T> Data { get; set; }

        public long Total { get; set; }

        public PageResult(List<T> data, long total)
        {
            this.Data = data;
            this.Total = total;
        }
    }
}