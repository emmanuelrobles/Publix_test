using Application.Exceptions;
using Application.Interfaces;
using Application.Services;
using Xunit;

namespace ApplicationUnitTest;

public class ApplicationServiceTest
{
    [Theory]
    [InlineData(-5)]
    [InlineData(0)]
    public void GetDemerit_InvalidSpeedLimit(int speedLimit)
    {
        // arrange
        var service = new ApplicationService(new Settings { SpeedDelta = 5, DemeritPoints = 1 });
        
        // act
        var action = () => { service.GetDemerit(5, speedLimit);};
        
        // assert
        Assert.Throws<InvalidSpeedLimitException>(action);
    }
    
    [Theory]
    [InlineData(-5)]
    [InlineData(0)]
    public void GetDemerit_InvalidDriverSpeed(int driverSpeed)
    {
        // arrange
        var service = new ApplicationService(new Settings { SpeedDelta = 5, DemeritPoints = 1 });
        
        // act
        var action = () => { service.GetDemerit(driverSpeed, 5);};
        
        // assert
        Assert.Throws<InvalidDriverSpeedException>(action);
    }
    
    [Theory]
    [InlineData(10,5,1)]
    [InlineData(5,5,0)]
    [InlineData(4,5,0)]
    public void GetDemerit_Success(int driverSpeed, int speedLimit, uint expected)
    {
        // arrange
        // TODO: we can pass an object to assign the settings
        var service = new ApplicationService(new Settings { SpeedDelta = 5, DemeritPoints = 1 });
        
        // act
        var demerit = service.GetDemerit(driverSpeed, speedLimit);
        
        // assert
        Assert.Equal(expected,demerit);
    }

    class Settings : ISettings
    {
        public uint SpeedDelta { get; init; }
        public uint DemeritPoints { get; init; }
    }
}
