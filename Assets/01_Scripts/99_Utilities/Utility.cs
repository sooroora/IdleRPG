using UnityEngine;

public static class Utility
{
    public static Vector3 GetRandomDirection()
    {
        Vector3 newDir = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        return newDir.normalized;
    }
    
    public static Vector3 GetRandomForwardDirection(Vector3 forward, float angleRange = 90f)
    {
        float angle = Random.Range(-angleRange / 2f, angleRange / 2f);
        Vector3 newDir = Quaternion.Euler(0, angle, 0) * forward;
        return newDir.normalized;
    }
    
}
