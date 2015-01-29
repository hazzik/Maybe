namespace Hazzik.Maybe
{
    using System;
    using JetBrains.Annotations;

    public partial class Maybe
    {
        [CanBeNull, ContractAnnotation("self:null=>null")]
        public static TResult With<T, TResult>([CanBeNull] this T? self, [NotNull] Func<T, TResult> func)
            where T : struct
        {
            if (func == null) throw new ArgumentNullException("func");
            if (!self.HasValue) return default(TResult);
            return func(self.GetValueOrDefault());
        }
    }
}