using flat_land.gameManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flat_land.dialogue
{
    [CreateAssetMenu(menuName = "dialogueReader")]
    public class DialogueReader : ScriptableObject
    {
        [SerializeField] List<DialogueStep> dialogueSteps = new List<DialogueStep>();
        [SerializeField] DialogueStep win;
        [SerializeField] DialogueStep loose;

        public int currentDialogue = 0;

        public event Action<DialogueStep> onDialogueSelected;
        
        public void GetNextDialogue(GameState state)
        {
            switch (state)
            {
                case GameState.start:
                    break;
                case GameState.zeroD:
                    GetNextDialogue();
                    break;
                case GameState.unD:
                    GetNextDialogue();
                    break;
                case GameState.deuxD:
                    GetNextDialogue();
                    break;
                case GameState.troisD:
                    switch (DmensionalGod.GetSuccessCounter())
                    {
                        case 0:
                            onDialogueSelected?.Invoke(dialogueSteps[0]);
                            break;
                        case 1:
                            onDialogueSelected?.Invoke(dialogueSteps[1]);
                            break;
                        case 2:
                            onDialogueSelected?.Invoke(dialogueSteps[2]);
                            break;
                        case 3:
                            onDialogueSelected?.Invoke(dialogueSteps[3]);
                            break;
                    }
                    break;
            }
        }

        public void GetNextDialogue()
        {
            if (dialogueSteps.Count < currentDialogue) GetWinDialogue();
            onDialogueSelected?.Invoke(dialogueSteps[currentDialogue]);
            currentDialogue += 1;
        }

        public void GetWinDialogue()
        {
            onDialogueSelected?.Invoke(win);
        }

        public void GetLooseDialogue()
        {
            onDialogueSelected?.Invoke(loose);
        }
    }
}

