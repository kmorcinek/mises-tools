using Xunit;
using Xunit.Should;

namespace KMorcinek.MisesTools.Tests
{
    public class MutualLinkerTests
    {
        private readonly MutualLinker mutualLinker = new MutualLinker();
        
        [Fact]
        public void Test1()
        {
            var text = "text[1] text, [1]blabla";
            string result = mutualLinker.ChangeOneOccurrence(1, text);

            result.ShouldBe("text<a id=\"_ednref1\" href=\"#_end1\">[1]</a> text, <a id=\"_end1\" href=\"#_ednref1\">[1]</a>blabla");
        }

        [Fact]
        public void Test2()
        {
            var text = "text[2] text, [2]blabla";
            string result = mutualLinker.ChangeOneOccurrence(2, text);

            result.ShouldBe("text<a id=\"_ednref2\" href=\"#_end2\">[2]</a> text, <a id=\"_end2\" href=\"#_ednref2\">[2]</a>blabla");
        }

        [Fact]
        public void WhenIndexExistsInTwoPlaces_Then_IsIndex_returnsTrue()
        {
            var text = "text[22] text, [22]blabla";
            bool isIndex = mutualLinker.IsIndex(text, 22);

            isIndex.ShouldBeTrue();
        }

        [Fact]
        public void WhenIndexExistsInOnePlaces_Then_IsIndex_returnsFalse()
        {
            var text = "text[22] text, [12]blabla";
            bool isIndex = mutualLinker.IsIndex(text, 22);

            isIndex.ShouldBeFalse();
        }
    }
}