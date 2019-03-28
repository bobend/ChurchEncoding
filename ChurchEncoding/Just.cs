using System;

namespace Ploeh.Samples.ChurchEncoding
{
    public class Just<T> : IMaybe<T>
    {
        private readonly T item;

        public Just(T item)
        {
            this.item = item;
        }
        public TResult Match<TResult>(TResult nothing, Func<T, TResult> just)
        {
            return just(item);
        }
    }
}