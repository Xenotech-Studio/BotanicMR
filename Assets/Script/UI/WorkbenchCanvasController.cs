using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class WorkbenchCanvasController : MonoBehaviour
    {
        public static WorkbenchCanvasController Instance;

        private CanvasGroup canvasGroup;
        private TMP_Text subtitle;

        private void Awake()
        {
            Instance = this;

            canvasGroup = GetComponent<CanvasGroup>();
            subtitle = transform.Find("Subtitle").GetComponent<TMP_Text>();
        }

        public static void CallUpSubtitle(string text)
        {
            if (Instance.canvasGroup.alpha == 0) Instance.canvasGroup.alpha = 1;
            
            Instance.subtitle.SetText(text);
            Instance.subtitle.CrossFadeAlpha(1f, 1f, true);
        }

        public static void HideSubtitle() => Instance.subtitle.CrossFadeAlpha(0f, 1f, true);
    }
}
