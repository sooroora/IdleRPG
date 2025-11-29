using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageButton : MonoBehaviour
{
    public Button Button => button;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI stageNameText;

    private int stageNum;
    public void Init(int _stageNumber, StageData _stageData)
    {
        stageNameText.text = _stageData.name;
        stageNum = _stageNumber;
        
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectStage);
    }

    void SelectStage()
    {
        GameManager.Instance.StartStage(stageNum);
    }
     
    
}
