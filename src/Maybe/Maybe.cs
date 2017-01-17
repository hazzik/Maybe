namespace Hazzik.Maybe
{
    using System;

    public static partial class Maybe
    {
        public static Maybe<U> Select<T, U>(this Maybe<T> maybe, Func<T, U> func)
        {
            return maybe.Bind(x => func(x).ToMaybe());
        }

        public static Maybe<V> SelectMany<T, U, V>(this Maybe<T> maybe, Func<T, Maybe<U>> func, Func<T, U, V> select)
        {
            return maybe.Bind(outer => func(outer).Bind(inner => select(outer, inner).ToMaybe()));
        }

        public static Maybe<V> SelectMany<T, U, V>(this Maybe<T> maybe, Func<T, U> func, Func<T, U, V> select)
        {
            return maybe.SelectMany(outer => func(outer).ToMaybe(), select);
        }

		public static Maybe<TSource> Where<TSource>(this Maybe<TSource> maybe, Func<TSource, bool> func)
		{
			return maybe.HasValue && func(maybe.Value) ? maybe : Maybe<TSource>.Nothing;
		}

        public static Maybe<T> ToMaybe<T>(this T o)
        {
            return new Maybe<T>(o);
        } 

        public static Maybe<string> ToNullOrEmptyMaybe(this string o)
		{
			return string.IsNullOrEmpty(o) ? Maybe<string>.Nothing : new Maybe<string>(o);
		}

        public static Maybe<string> ToNullOrWhiteSpaceMaybe(this string o)
		{
			return string.IsNullOrWhiteSpace(o) ? Maybe<string>.Nothing : new Maybe<string>(o);
		}
	}
}