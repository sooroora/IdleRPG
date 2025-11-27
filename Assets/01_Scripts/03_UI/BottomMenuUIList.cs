using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomMenuUIList : MonoBehaviour
{
    [SerializeField] List<BottomMenuUI> menuList = new List<BottomMenuUI>();

    private void Start()
    {
        for (int i = 0; i < menuList.Count; i++)
        {
            int ii = i;
            for (int j = 0; j < menuList.Count; j++)
            {
                if (i != j)
                {
                    int jj = j;
                    menuList[ii].OnOpenAction += () =>
                    {

                        menuList[jj].ForceClose();
                    };
                }
            }

            menuList[ii].OnOpenAction += () =>
            {
                CameraManager.Instance.SetBottomUIAim();
            };

            menuList[ii].OnCloseAction += () =>
            {
                CameraManager.Instance.SetDefaultAim();
            };
        }
    }
    
    

}
