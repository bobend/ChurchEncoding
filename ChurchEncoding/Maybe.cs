namespace Ploeh.Samples.ChurchEncoding
{
    public static class Maybe
    {
        public static IMaybe<T> ToMaybe<T>(this T item)
        {
            return item != null ? (IMaybe<T>) new Just<T>(item) : new Nothing<T>();
        }
    }
}