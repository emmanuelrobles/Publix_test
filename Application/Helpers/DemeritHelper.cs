namespace Application.Helpers;

public static class DemeritHelper
{
    public static uint GetDemerit(uint speedOverLimit, uint speedDelta, uint points)
        => speedOverLimit / speedDelta * points;
}
