namespace KNBManagement.Web.Services.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using KNBManagement.Web.Services.Core;
    

    public class ListQuery<T>: Query<T> where T:new()
    {
        public ListQuery(IEnumerable<T> data)
            : base(new ListQueryProvider<T>(data))
        {
        }
    }

    internal class ListQueryProvider<T> : QueryProvider where T:new()
    {
        private IEnumerable<T> _data;
        public ListQueryProvider(IEnumerable<T> data)
        {
            this._data = data;
        }
        public override string GetQueryText(System.Linq.Expressions.Expression expression)
        {
            return string.Empty;
        }

        public override object Execute(System.Linq.Expressions.Expression expression)
        {
            return this._data;
        }
    }

}