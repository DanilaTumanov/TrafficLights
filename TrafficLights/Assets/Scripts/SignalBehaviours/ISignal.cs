namespace SignalBehaviours
{
    
    /// <summary>
    /// Сигнал, являющийся функцией от времени
    /// </summary>
    public interface ISignal
    {

        float GetValue(float time);

    }
}
