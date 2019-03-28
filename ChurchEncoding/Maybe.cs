using System;

namespace Ploeh.Samples.ChurchEncoding
{
    public static class Maybe
    {
        public static IMaybe<TResult> Select<T, TResult>(this IMaybe<T> source, Func<T, TResult> selector) =>
            source.Match<IMaybe<TResult>>(
                nothing: new Nothing<TResult>(), 
                just: x => new Just<TResult>(selector(x)));
    }
}
