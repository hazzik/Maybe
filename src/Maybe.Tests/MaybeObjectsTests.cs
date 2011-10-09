namespace Hazzik.Maybe.Tests
{
    using Xunit;

    public class MaybeObjectsTests
    {
        [Fact]
        public void ReturnsPropertyIfObjectIsNotNull()
        {
            var target = new Target();
            var result = target.With(x => x.ObjectProperty);
            Assert.Equal(target.ObjectProperty, result);
        }
        
        [Fact]
        public void ReturnsNullIfObjectIsNull()
        {
            Target target = null;
            var result = target.With(x => x.ObjectProperty);
            Assert.Null(result);
        }
        
        [Fact]
        public void ReturnsDefaultIfObjectIsNull()
        {
            Target target = null;
            var result = target.With(x => x.IntProperty);
            Assert.Equal(0, result);
        }

        [Fact]
        public void ReturnsValuePropertyIfObjecIsNotNull()
        {
            var target = new Target();
            var result = target.With(x => x.IntProperty);
            Assert.Equal(100, result);
        }

        #region Nested type: Target

        public class Target
        {
            public Target()
            {
                ObjectProperty = new object();
                IntProperty = 100;
            }

            public object ObjectProperty { get; set; }
            public int IntProperty { get; set; }
        }

        #endregion
    }
}