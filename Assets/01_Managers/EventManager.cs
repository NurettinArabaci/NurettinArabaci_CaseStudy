using System;

public static partial class EventManager
{
    public static event Action OnStartGame;
    public static void Fire_OnStartGame() { OnStartGame?.Invoke(); }

    public static event Action OnLevelCompleted;
    public static void Fire_OnLevelCompleted() { OnLevelCompleted?.Invoke(); }

    public static event Action OnCorrect;
    public static void Fire_OnCorrect() { OnCorrect?.Invoke(); }

    public static event Action OnWrong;
    public static void Fire_OnWrong() { OnWrong?.Invoke(); }
}
