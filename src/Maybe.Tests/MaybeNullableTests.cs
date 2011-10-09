namespace Hazzik.Maybe.Tests
{
    using Xunit;

    public class MaybeNullableTests
    {
        [Fact]
        public void ReturnsValueIfObjectIsNotNull()
        {
            int? i = 100500;
            string result = i.With((int x) => x.ToString());
            Assert.Equal("100500", result);
        }

        [Fact]
        public void ReturnsDefaultIfObjectIsNull()
        {
            int? i = null;
            string result = i.With((int x) => x.ToString());
            Assert.Null(result);
        }
    }
}