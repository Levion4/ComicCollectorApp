using ComicCollectorApp.Model.Services;

namespace ComicCollectorApp.Tests
{
    public class ValueValidatorTests
    {
        [Fact]
        public void AssertStringOnLength_ShouldReturnNull_WhenStringLengthIsValid()
        {
            var result = ValueValidator.AssertStringOnLength("Test", 10, "TestProperty");
            Assert.Null(result);
        }

        [Fact]
        public void AssertStringOnLength_ShouldReturnError_WhenStringLengthExceedsMax()
        {
            var result = ValueValidator.AssertStringOnLength("TooLongString", 5, "TestProperty");
            Assert.Equal("The TestProperty must be no longer than 5 characters, but was 13.", result);
        }

        [Fact]
        public void AssertOnPositiveValue_ShouldReturnNull_WhenValueIsPositive()
        {
            var result = ValueValidator.AssertOnPositiveValue(5, "TestProperty");
            Assert.Null(result);
        }

        [Fact]
        public void AssertOnPositiveValue_ShouldReturnError_WhenValueIsZero()
        {
            var result = ValueValidator.AssertOnPositiveValue(0, "TestProperty");
            Assert.Equal("The TestProperty cannot be negative or equal to zero, but was 0.", result);
        }

        [Fact]
        public void AssertStringContainsOnlyLetters_ShouldReturnNull_WhenStringContainsOnlyLetters()
        {
            var result = ValueValidator.AssertStringContainsOnlyLetters("Test", "TestProperty");
            Assert.Null(result);
        }

        [Fact]
        public void AssertStringContainsOnlyLetters_ShouldReturnError_WhenStringContainsNonLetterCharacters()
        {
            var result = ValueValidator.AssertStringContainsOnlyLetters("Test123", "TestProperty");
            Assert.Equal("TestProperty must contains letters only.", result);
        }

        [Fact]
        public void AssertValueInRange_ShouldReturnNull_WhenValueIsWithinRange()
        {
            var result = ValueValidator.AssertValueInRange(5, 1, 10, "TestProperty");
            Assert.Null(result);
        }

        [Fact]
        public void AssertValueInRange_ShouldReturnError_WhenValueIsOutOfRange()
        {
            var result = ValueValidator.AssertValueInRange(15, 1, 10, "TestProperty");
            Assert.Equal("The TestProperty should be in the range from 1 to 10, but was 15.", result);
        }
    }
}