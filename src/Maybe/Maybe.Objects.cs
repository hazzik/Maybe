namespace Hazzik.Maybe
{
    using System;
    using JetBrains.Annotations;

    public static partial class Maybe
    {
        [CanBeNull, ContractAnnotation("self:null=>null")]
        public static TResult With<T, TResult>([CanBeNull] this T self, [NotNull] Func<T, TResult> func)
            where T : class
        {
            if (ReferenceEquals(func, null)) throw new ArgumentNullException("func");
            if (ReferenceEquals(self, null)) return default(TResult);
            return func(self);
        }
    }
}