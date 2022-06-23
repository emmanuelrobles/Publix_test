using Application.Helpers;
using Xunit;

namespace ApplicationUnitTest;

public class DemeritHelperTests
{
    [Theory]
    [InlineData(10, 5, 1 , 2)]
    [InlineData(10, 5, 2 , 4)]
    [InlineData(9, 5, 1 , 1)]
    [InlineData(9, 5, 2 , 2)]
    [InlineData(0, 5, 1 , 0)]
    [InlineData(0, 5, 2 , 0)]
    // TODO: What to do in these 2 cases
    [InlineData(4, 5, 1 , 0)]
    [InlineData(4, 5, 2 , 0)]
    public void DemeritTests_valid(uint speedOverLimit, uint speedDelta, uint points, uint expectedDemeritPoints)
    {
        Assert.Equal(expectedDemeritPoints,DemeritHelper.GetDemerit(speedOverLimit,speedDelta,points));
    }
}
