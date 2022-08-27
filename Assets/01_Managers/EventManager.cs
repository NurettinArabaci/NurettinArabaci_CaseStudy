using System;

public static partial class EventManager
{
    public static event Action OnLevelStart;
    public static void Fire_OnLevelStart() { OnLevelStart?.Invoke(); }

    public static event Action OnLevelCompleted;
    public static void Fire_OnLevelCompleted() { OnLevelCompleted?.Invoke(); }
}
