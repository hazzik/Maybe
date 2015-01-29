using System;

namespace Hazzik.Maybe.Tests
{
    using Xunit;

    public class MaybeTests
    {
        [Fact]
        public void NullMaybeOpEquality()
        {
            Maybe<Person> person = null;

            Assert.True(person == null);
        }

        [Fact]
        public void NullMaybeEquals()
        {
            Maybe<Person> person = null;

            Assert.True(person.Equals(null));
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

            var name = person.Select(p => p.Name)
                .Select(x => x.Length);

            Assert.True(name == Maybe<int>.Nothing);
        }

        [Fact]
        public void SelectManyPerson1()
        {
            Maybe<Person> person = null;

            var name = from p in person
                from n in p.Name
                select n.Length;

            Assert.True(name == Maybe<int>.Nothing);
        }

        [Fact]
        public void SelectManyPerson2()
        {
            Maybe<Person> person = null;

            var name = from p in person
                select p.Name
                into n
                from a in n
                select a.Length;

            Assert.True(name == Maybe<int>.Nothing);
        }

        [Fact]
        public void Select()
        {
            Maybe<int> i = 5;
            var maybe = from mi in i
                select mi.ToString();

            Assert.Equal("5", maybe.GetValueOrDefault());
        }

        [Fact]
        public void SelectMany()
        {
            Maybe<int> x = 5;
            Maybe<int> y = 4;
            var maybe = from mx in x
                from my in y
                select mx * my;

            Assert.Equal(20, maybe.GetValueOrDefault());
        }

        [Fact]
        public void GetHashCodeOfNothing()
        {
            Maybe<Person> person = null;

            Assert.DoesNotThrow(() => person.GetHashCode());
        }

        [Fact]
        public void ToMaybe()
        {
            var maybe = 5.ToMaybe();

            Assert.True(maybe.HasValue);
            Assert.Equal(5, maybe.GetValueOrDefault());
        }

        [Fact]
        public void SomeToString()
        {
            var maybe = 5.ToMaybe();

            Assert.Equal("5", maybe.ToString());
        }
       
        [Fact]
        public void NothingToString()
        {
            var maybe = Maybe<int>.Nothing;

            Assert.Equal("Nothing", maybe.ToString());
        }
    }

    public class Person
    {
        public string Name { get; set; }
    }
}