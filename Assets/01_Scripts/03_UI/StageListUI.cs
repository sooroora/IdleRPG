using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageListUI : BottomMenuUI
{
    [SerializeField] private StageButton buttonPrefab;
    [SerializeField] private Transform content;
    
    private void Start()
    {
        for (int i = 0; i < GameManager.Instance.StageData.Count; ++i)
        {
            StageButton spawnedButton = Instantiate(buttonPrefab, content);
            spawnedButton.Init(i,GameManager.Instance.StageData[i]);
            spawnedButton.Button.onClick.AddListener(ForceClose);
        }
    }
    
    
}
