using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace flat_land.UI
{
    public class Hub : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<Hub, Hub.UxmlTraits>
        {

        }

        VisualElement root;
        VisualElement popUp;
        Label popUpText;

        public void Show(string txt)
        {
            popUp.style.display = DisplayStyle.Flex;
            popUpText.text = txt; 
        }

        public void Hide()
        {
            popUp.style.display = DisplayStyle.None;
        }

        internal void Init(VisualElement currentRoot)
        {
            root = currentRoot;
            popUp = currentRoot.Q<VisualElement>("popup");
            popUpText = currentRoot.Q<Label>("popup_txt");
        }
    }
}

