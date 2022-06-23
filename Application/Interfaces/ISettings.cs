namespace Application.Interfaces;

public interface ISettings
{
    /// <summary>
    /// Speed delta on which it will assign points
    /// </summary>
    public uint SpeedDelta { get;}
    
    /// <summary>
    /// Points to be assign per range delta
    /// </summary>
    public uint DemeritPoints { get;}
}
