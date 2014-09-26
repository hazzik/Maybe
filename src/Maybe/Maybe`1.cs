using System;
using System.Collections.Generic;

namespace Hazzik.Maybe
{
    public struct Maybe<T> : IEquatable<Maybe<T>>
        // where T: class 
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

        public Maybe(T value)
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

        public override bool Equals(object @object)
        {
            if (ReferenceEquals(null, @object)) return false;
            return @object is Maybe<T> && Equals((Maybe<T>) @object);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (HasValue.GetHashCode()*397) ^ EqualityComparer<T>.Default.GetHashCode(Value);
            }
        }

        public bool Equals(Maybe<T> other)
        {
            return other._hasValue
                ? _hasValue && EqualityComparer<T>.Default.Equals(_value, other._value)
                : _hasValue == false;
        }

        public static bool operator ==(Maybe<T> x, Maybe<T> y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Maybe<T> x, Maybe<T> y)
        {
            return !x.Equals(y);
        }

        public Maybe<TResult> Bind<TResult>(Func<T, TResult> func) 
        {
            if (_hasValue)
                return func(_value);

            return new Maybe<TResult>();
        }
    }
}