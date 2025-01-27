﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Michsky.UI.FieldCompleteMainMenu
{
    public class FriendsPanelManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        private Animator panelAnimator;
        private CanvasGroup cg;
        private bool isOpen = false;
        public bool isMobile;
        public bool blurEnabled = true;

        BlurManager bManager;

        void Start()
        {
            panelAnimator = gameObject.GetComponent<Animator>();
            cg = gameObject.GetComponent<CanvasGroup>();
            bManager = gameObject.GetComponent<BlurManager>();
            bManager.BlurOutAnim();

            if(isMobile == true)
            {
                cg.interactable = false;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            panelAnimator.Play("Friends Panel In");
            bManager.BlurInAnim();
        }

         public void OnPointerClick(PointerEventData eventData)
        {            
            if(isOpen == true)
            {
                panelAnimator.Play("Friends Panel Out");
                bManager.BlurOutAnim();
                isOpen = false;
            }

            else
            {
                panelAnimator.Play("Friends Panel In");
                bManager.BlurInAnim();
                isOpen = true;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            panelAnimator.Play("Friends Panel Out");
            bManager.BlurOutAnim();
        }
    }
}