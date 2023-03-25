using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace flat_land.UI
{
    public class CustomButton : Button
    {
        public new class UxmlFactory : UxmlFactory<CustomButton, CustomButton.UxmlTraits>
        {

        }

        public event Action<bool> onSlected;
        public bool isTrue;
    }
}

