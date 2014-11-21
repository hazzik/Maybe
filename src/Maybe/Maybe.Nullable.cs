namespace Hazzik.Maybe
{
    using System;

    public partial class Maybe
    {
        public static TResult With<T, TResult>(this T? self, Func<T, TResult> func)
            where T : struct
        {
            if (func == null) throw new ArgumentNullException("func");
            if (self.HasValue == false)
                return default(TResult);
            return func(self.Value);
        }
    }
}