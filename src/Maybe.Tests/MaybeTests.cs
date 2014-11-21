using System;

namespace Hazzik.Maybe.Tests
{
    using Xunit;

    public class MaybeTests
    {
        [Fact]
        public void NullMaybe()
        {
            Maybe<Person> person = null;

            Assert.True(person == null);
        }

        [Fact]
        public void MaybeWithoutValueThrows()
        {
            Maybe<Person> person = null;

            Assert.False(person.HasValue);
            Assert.Throws<InvalidOperationException>(() => person.Value);
        }

        [Fact]
        public void Bind()
        {
            Maybe<Person> person = null;

            var name = person.Bind(p => p.Name)
                .Bind(x => x.Length);

            Assert.True(name == Maybe<int>.Nothing);
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }
}