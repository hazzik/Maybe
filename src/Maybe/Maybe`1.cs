namespace Hazzik.Maybe
{
    using System;
    using System.Collections.Generic;
    using JetBrains.Annotations;

    public struct Maybe<T> : IEquatable<Maybe<T>>
    {
        public static readonly Maybe<T> Nothing = new Maybe<T>();

        private readonly T _value;

        private readonly bool _hasValue;

        public bool HasValue
        {
            get { return _hasValue; }
        }

        public T Value
        {
            get
            {
                if (!_hasValue) throw new InvalidOperationException(typeof (Maybe<T>) + " does not have value");

                return _value;
            }
        }

        public Maybe([CanBeNull] T value)
        {
            _hasValue = !ReferenceEquals(value, null);
            _value = value;
        }

        public T GetValueOrDefault()
        {
            return _value;
        }

        public T GetValueOrDefault(T @default)
        {
            if (_hasValue) return _value;
            return @default;
        }

        public static implicit operator Maybe<T>(T value)
        {
            return new Maybe<T>(value);
        }

        public static explicit operator T(Maybe<T> maybe)
        {
            return maybe.Value;
        }

        public bool Equals(Maybe<T> other)
        {
            return other._hasValue
                ? _hasValue && EqualityComparer<T>.Default.Equals(_value, other._value)
                : _hasValue == false;
        }

        public override bool Equals(object @object)
        {
            if (ReferenceEquals(null, @object)) return false;
            return @object is Maybe<T> && Equals((Maybe<T>) @object);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_hasValue.GetHashCode()*397) ^ EqualityComparer<T>.Default.GetHashCode(_value);
            }
        }

        public static bool operator ==(Maybe<T> x, Maybe<T> y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Maybe<T> x, Maybe<T> y)
        {
            return !x.Equals(y);
        }

        public override string ToString()
        {
            return Bind(x => x.ToString().ToMaybe()).GetValueOrDefault("Nothing");
        }

        [Obsolete("Please use Select")]
        public Maybe<TResult> Bind<TResult>([NotNull] Func<T, TResult> func) 
        {
            return Bind(x => func(x).ToMaybe());
        }

        public Maybe<TResult> Bind<TResult>([NotNull] Func<T, Maybe<TResult>> func) 
        {
            if (_hasValue)
                return func(_value);

            return Maybe<TResult>.Nothing;
        }
    }
}