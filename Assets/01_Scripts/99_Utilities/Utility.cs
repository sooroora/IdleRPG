using UnityEngine;

public static class Utility
{
    public static Vector3 GetRandomDirection()
    {
        Vector3 newDir = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        return newDir.normalized;
    }
    

}
