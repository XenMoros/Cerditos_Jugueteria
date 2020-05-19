using UnityEngine;

public static class StaticComponent
{
    public static float currentSpeed;

    public static float GetCurrentSpeed()
    {
        return currentSpeed;
    }

    public static void SetCurrentSpeed(float speed)
    {
        currentSpeed = speed;
    }
}