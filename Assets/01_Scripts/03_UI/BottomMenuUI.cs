using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomMenuUI : MonoBehaviour
{
   [SerializeField] Button openButton;
   [SerializeField] RectTransform panel;
   //[SerializeField] 
   
   private void Awake()
   {
      //openButton.onClick.AddListener();
   }

   public void Open()
   {
      
   }

   public void Close()
   {
      
   }

   IEnumerator OpenRoutine()
   {
      while (true)
      {
         yield return new WaitForSeconds( 1.0f );         
      }
   }
}
