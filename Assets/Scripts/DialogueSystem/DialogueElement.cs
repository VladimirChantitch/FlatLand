using flat_land.dialogue;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace flat_land.UI
{
    public class DialogueElement : VisualElement
    {
        public new class UxmlFactory : UxmlFactory<DialogueElement, DialogueElement.UxmlTraits>
        {

        }

        List<CustomButton> buttons = new List<CustomButton>();  
        VisualElement root = null;

        public event Action onTrueAnswer;
        public event Action onFalseAnswer;

        public void Init(VisualElement root)
        {
            this.root = root;

            Children().ToList().ForEach(child =>
            {
                if (child is CustomButton button)
                {
                    buttons.Add(button);
                        button.onSlected += (b) =>
                        {
                            if (b)
                            {
                                onTrueAnswer?.Invoke();
                            }
                            else
                            {
                                onFalseAnswer?.Invoke();
                            }
                        };
                }
            });
        }

        public void InitNewDialogue(DialogueStep step)
        {
            if (step.Answers.Count > 0)
            {
                for ( int i = 1; i< step.Answers.Count; i++)
                {
                    StyleBackground sstyle = new StyleBackground(step.Answers[i].dialogueSprite);
                    buttons[i].style.backgroundImage = sstyle;
                    buttons[i].isTrue = step.Answers[i].isGoodAnswer;
                }
            }

            StyleBackground style = new StyleBackground(step.npc.dialogueSprite);
            buttons[0].style.backgroundImage = style;            
        }
    }
}

