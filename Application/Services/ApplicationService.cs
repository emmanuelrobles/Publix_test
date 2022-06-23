using Application.Exceptions;
using Application.Interfaces;

namespace Application.Services;

/// <summary>
/// Service that does what the test needs me to do :)
/// </summary>
public class ApplicationService
{
    /// <summary>
    /// Settings to configure behaviour
    /// </summary>
    private readonly ISettings _settings;

    public ApplicationService(ISettings settings)
    {
        _settings = settings ?? throw new ArgumentNullException(nameof(settings));
    }

    /// <summary>
    /// Gets the Demerit based on 
    /// </summary>
    /// <param name="driverSpeed"></param>
    /// <param name="speedLimit"></param>
    /// <returns></returns>
    /// <exception cref="InvalidDriverSpeedException">If the drivers speed is not withing range this exception is thrown</exception>
    /// <exception cref="InvalidSpeedLimitException">If the Speed limit is not within range this exception is thrown</exception>
    public uint GetDemerit(int driverSpeed, int speedLimit)
    {
        // Check for driver speed
        if (driverSpeed <= 0)
        {
            throw new InvalidDriverSpeedException("Invalid Driver speed, it needs to be > 0");
        }
        
        // check for speed limit
        if (speedLimit <= 0)
        {
            throw new InvalidSpeedLimitException("Invalid speed limit, it needs to be > 0");
        }
        
        // if the driver is not speeding just return 0,Demerit could be more expensive to compute in the future, so  we are just short-circuiting, else calculate the Demerit points 
        return driverSpeed < speedLimit ? 0 : Helpers.DemeritHelper.GetDemerit((uint)(driverSpeed-speedLimit),_settings.SpeedDelta,_settings.DemeritPoints);
    }
}
