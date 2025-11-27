using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : SingletonManager<ScreenManager>
{
    [ SerializeField ] private Image fadeImg;

    Coroutine nowFadeRoutine;

    private void Update()
    {

    }

    public void StartFadeIn( float duration = 1.0f )
    {
        if ( nowFadeRoutine != null )
            StopCoroutine( nowFadeRoutine );
        nowFadeRoutine = StartCoroutine( FadeInRoutine( duration ) );
    }

    public void StartFadeOut( float duration = 1.0f )
    {
        if ( nowFadeRoutine != null )
            StopCoroutine( nowFadeRoutine );
        nowFadeRoutine = StartCoroutine( FadeOutRoutine( duration ) );
    }

    public void StartFadeInOut( float duration = 1.0f, Action callback = null, float delay = 1.0f )
    {
        if ( nowFadeRoutine != null )
            StopCoroutine( nowFadeRoutine );
        nowFadeRoutine = StartCoroutine( FadeInOutRoutine( duration, callback ,delay) );
    }

    IEnumerator FadeInRoutine( float duration = 1.0f )
    {
        fadeImg.gameObject.SetActive( true );
        fadeImg.color = new Color( 0, 0, 0, 1f );
        while ( fadeImg.color.a > 0f )
        {
            float a = fadeImg.color.a - ( Time.deltaTime / duration );
            fadeImg.color = new Color( 0, 0, 0, a );
            yield return null;
        }
        
        fadeImg.gameObject.SetActive( false );
        nowFadeRoutine = null;
    }

    IEnumerator FadeOutRoutine( float duration = 1.0f )
    {
        fadeImg.gameObject.SetActive( true );
        fadeImg.color = new Color( 0, 0, 0, 0f );
        while ( fadeImg.color.a < 1f )
        {
            float a = fadeImg.color.a + ( Time.deltaTime / duration );
            fadeImg.color = new Color( 0, 0, 0, a );
            yield return null;
        }

        nowFadeRoutine = null;
    }

    IEnumerator FadeInOutRoutine( float duration = 1.0f, Action callback = null, float delay = 1.0f )
    {
        yield return FadeOutRoutine( duration );

        callback?.Invoke();
        yield return new WaitForSeconds( delay );

        yield return FadeInRoutine( duration );

        nowFadeRoutine = null;
    }
}