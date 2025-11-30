using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomMenuUIList : MonoBehaviour
{
    [SerializeField] List<BottomMenuUI> menuList = new List<BottomMenuUI>();
    [ SerializeField ] private Transform playerStatusUI;

    private void Start()
    {
        foreach (BottomMenuUI menu in menuList)
        {
            foreach (BottomMenuUI other in menuList)
            {
                if (menu != other)
                {
                    menu.OnOpenAction += () =>
                    {
                        other.ForceClose();
                    };
                }
            }

            menu.OnOpenAction += () =>
            {
                CameraManager.Instance.SetBottomUIAim();
                playerStatusUI.SetParent(menu.transform);
                playerStatusUI.localPosition = new Vector3( 0, menu.RectTransform.rect.height + 85, 0 ); 
            };

            menu.OnCloseAction += () =>
            {
                CameraManager.Instance.SetDefaultAim();
            };

        }
        
    }

}
