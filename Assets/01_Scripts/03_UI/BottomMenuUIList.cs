using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomMenuUIList : MonoBehaviour
{
    [SerializeField] List<BottomMenuUI> menuList = new List<BottomMenuUI>();

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
            };

            menu.OnCloseAction += () =>
            {
                CameraManager.Instance.SetDefaultAim();
            };

        }
        
    }

}
