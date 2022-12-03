namespace NumbersInWords.Tests;

public class NumbersInWordsTest
{
    [Theory]
    [InlineData(1, "en")]
    [InlineData(123_456_789, "et hundre og tjuetre millioner fire hundre og femtiseks tusen syv hundre og åttini")]
    [InlineData(987_654_321, "ni hundre og åttisyv millioner seks hundre og femtifire tusen tre hundre og tjueen")]
    public void ShouldReturnEnForOne(int number, string expected)
    {
        Assert.Equal(expected, number.ToWords());
    }
}