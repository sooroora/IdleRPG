using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI clearText;
    [ SerializeField ] private TextMeshProUGUI rewardText;
    [ SerializeField ] private Button replayButton;
    [ SerializeField ] private Button nextStageButton;
    
    public Button ReplayButton=> replayButton;
    public Button NextStageButton => nextStageButton;

    private void Awake()
    {   
        this.gameObject.SetActive(false);
        replayButton.onClick.AddListener( ClosePopup );
        nextStageButton.onClick.AddListener( ClosePopup );
    }

    public void OpenClearPopup(StageData reward)
    {
        clearText.text = "Clear";

        rewardText.text =
            "경험치 : " + reward.clearExp + "\n" +
            "골드 : " + reward.clearGold;
        
        rewardText.gameObject.SetActive( true );
        
        replayButton.gameObject.SetActive( true );
        nextStageButton.gameObject.SetActive( true );
        this.gameObject.SetActive( true );
    }

    public void OpenFailPopup()
    {
        clearText.text = "Fail";
        
        rewardText.gameObject.SetActive( false );
        
        replayButton.gameObject.SetActive( true );
        nextStageButton.gameObject.SetActive( false );
        this.gameObject.SetActive( true );
    }

    public void ClosePopup()
    {
        
        this.gameObject.SetActive( false );
    }
}
