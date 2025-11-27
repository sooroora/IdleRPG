using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [ SerializeField ] private TextMeshProUGUI goldText;
    [ SerializeField ] private Image expBar;
    [ SerializeField ] private TextMeshProUGUI stageText;

    private Coroutine increaseExpRoutine;
    private float increaseExpSpeed = 2.5f;
    
    private Coroutine increaseGoldRoutine;
    private float increaseGoldSpeed = 2.5f;
    
    public void SetLevelText( int level )
    {
        levelText.text = level.ToString();
    }

    public void SetExpBar( float nowExp, float requiredExp )
    {
        float nowScale = nowExp / requiredExp;
        expBar.rectTransform.localScale = new Vector3(nowScale, 1, 1);
    }

    public void SetGoldText( float nowGold )
    {
        displayGold = nowGold;
        goldText.text = displayGold.ToString();
    }
    
    public void StartSetExpBarRoutine( int nowExp, int requiredExp )
    {
        if(increaseExpRoutine != null)
            StopCoroutine(increaseExpRoutine);
        increaseExpRoutine = StartCoroutine(IncreaseExpRoutine(nowExp, requiredExp));
    }

    public void StartSetGoldTextRoutine( int nowGold)
    {
        if(increaseGoldRoutine != null)
            StopCoroutine(increaseGoldRoutine);
        increaseGoldRoutine = StartCoroutine(IncreaseGoldRoutine( nowGold));
    }

    public void SetStageText( string stageName )
    {
        stageText.text = stageName;
    }

    IEnumerator IncreaseExpRoutine( float targetExp, float requireExp )
    {
        float a = 0f;

        float startScale = expBar.rectTransform.localScale.x;
        float targetScale = Mathf.Clamp(targetExp / requireExp,0f,1f);
        
        while ( a < 1 )
        {
            a += increaseExpSpeed * Time.deltaTime;
            float nowScale = Mathf.Lerp( startScale, targetScale, a );
            expBar.rectTransform.localScale = new Vector3(nowScale, 1, 1);
            yield return null;
        }
        increaseExpRoutine = null;

        if ( targetScale >= 1.0f )
        {
            increaseExpRoutine = StartCoroutine( ResetExpBarRoutine() );
        }
    }

    IEnumerator ResetExpBarRoutine()
    {
        float a = 0f;
        float startScale = expBar.rectTransform.localScale.x;
        float targetScale = 0;
        
        while ( a < 1 )
        {
            a += increaseExpSpeed * Time.deltaTime * 2.0f;
            float nowScale = Mathf.Lerp( startScale, targetScale, a );
            expBar.rectTransform.localScale = new Vector3(nowScale, 1, 1);
            yield return null;
        }
        
        increaseExpRoutine = null;
    }

    private float displayGold;
    IEnumerator IncreaseGoldRoutine(  float targetGold )
    {
        float a = 0;
        float startGold = displayGold;
        while ( a < 1 )
        {
            a += increaseGoldSpeed * Time.deltaTime;
            float nowDeisplayGold =  Mathf.Lerp( startGold, targetGold, a );
            displayGold = nowDeisplayGold;
            goldText.text = displayGold.ToString("F0");
            yield return null;
        }
        increaseGoldRoutine = null;
    }


}
