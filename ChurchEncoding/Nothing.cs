using System;

namespace Ploeh.Samples.ChurchEncoding
{
    public class Nothing<T> : IMaybe<T>
    {
        public TResult Match<TResult>(TResult nothing, Func<T, TResult> just)
        {
            return nothing;
        }
    }
}