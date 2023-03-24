using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace flat_land.UI
{
    public class StartMenu
    {
        Button btn_start = null;
        Button btn_credit = null;

        public event Action onStartGame; 

        private VisualElement currentRoot;

        public StartMenu(VisualElement currentRoot)
        {
            this.currentRoot = currentRoot;
            Init();
        }

        public void Init()
        {
            btn_start = currentRoot.Q<Button>("Start");

            btn_start.clicked += () => onStartGame.Invoke();
        }
    }
}

