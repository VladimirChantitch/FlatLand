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
        public event Action<DialogueStep, bool> onFinished;

        bool alredyCalled = false;
        
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
                    if (alredyCalled) return;
                    switch (DmensionalGod.GetSuccessCounter())
                    {
                        case 0:
                            if (DmensionalGod.introPlayed == false)
                            {                     
                                alredyCalled = true;
                                DmensionalGod.introPlayed = true;
                                onDialogueSelected?.Invoke(dialogueSteps[0]);
                                break;
                            }
                            break;
                        case 3:
                            break;
                    }
                    break;
            }
        }

        public void GetNextDialogue()
        {
            if (dialogueSteps.Count == 0) return;
            if (currentDialogue > dialogueSteps.Count - 1) return;
            if (dialogueSteps.Count < currentDialogue) GetWinDialogue();
            onDialogueSelected?.Invoke(dialogueSteps[currentDialogue]);
            currentDialogue += 1;
        }

        public void GetWinDialogue()
        {
            onFinished?.Invoke(win, true);
        }

        public void GetLooseDialogue()
        {
            onFinished?.Invoke(loose, false);
        }
    }
}

