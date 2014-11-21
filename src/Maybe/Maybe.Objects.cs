namespace Hazzik.Maybe
{
    using System;

    public static partial class Maybe
    {
        public static TResult With<T, TResult>(this T @self, Func<T, TResult> func)
            where T : class
        {
            if (func == null) throw new ArgumentNullException("func");
            if (@self != null)
                return func(self);
            return default(TResult);
        }
    }
}