using System;
using System.Collections;
using UnityEngine;

public class CoroutineManager : SingletonManager<CoroutineManager>
{
    IEnumerator DelayActionRoutine(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }

    IEnumerator RealTimeDelayActionRoutine(Action action, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        action?.Invoke();
    }

    public Coroutine StartDelayAction(Action action, float delay)
    {
        return StartCoroutine(DelayActionRoutine(action, delay));
    }

    public Coroutine StartRealTimeDelayAction(Action action, float delay)
    {
        return StartCoroutine(RealTimeDelayActionRoutine(action, delay));
    }
}
