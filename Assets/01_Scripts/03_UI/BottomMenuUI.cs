using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomMenuUI : MonoBehaviour
{
   [SerializeField] Button openButton;
   private RectTransform rectTransform;
   
   bool isOpen = false;
   Coroutine slotToggleCoroutine;

   private float openSpeed = 2.0f;

   public event Action OnOpenAction;
   public event Action OnCloseAction;
   
   private void Awake()
   {
      rectTransform = GetComponent<RectTransform>();
      rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -rectTransform.rect.height);

      openButton.onClick.AddListener(Toggle);
      isOpen = false;
      
      Init();
      
   }
   
   /// <summary>
   /// Awake 에 작동
   /// </summary>
   public virtual void Init()
   {
      
   }

   public void Toggle()
   {
      if(isOpen)
         Close();
      else
         Open();
   }
   
   public void Open()
   {
      if(slotToggleCoroutine != null)
         StopCoroutine(slotToggleCoroutine);
      
      transform.SetSiblingIndex(0);
      slotToggleCoroutine = StartCoroutine(SlotToggleCoroutine(true));
      OnOpenAction?.Invoke();
   }

   public void Close()
   {
      if(slotToggleCoroutine != null)
         StopCoroutine(slotToggleCoroutine);
      slotToggleCoroutine = StartCoroutine(SlotToggleCoroutine(false));
      OnCloseAction?.Invoke();
   }

   IEnumerator SlotToggleCoroutine(bool _isOpen)
   {
      float a = 0;
      float startPos = rectTransform.anchoredPosition.y;
      float targePos = _isOpen ? 0 : -rectTransform.rect.height;
      while (a<1)
      {
         a += Time.deltaTime * openSpeed;
         
         float nowY = Mathf.Lerp(startPos, targePos, a);
         
         rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x,nowY);
         yield return null;
      }
      slotToggleCoroutine = null;
      isOpen = _isOpen;
   }

   public void ForceClose()
   {
      rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x,-rectTransform.rect.height);
      isOpen = false;
   }
   
}
