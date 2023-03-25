using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flat_land.dialogue
{
    [CreateAssetMenu(menuName = "dialogueStep")]
    public class DialogueStep : ScriptableObject
    {
        public DialogueCell npc;
        public List<DialogueCell> Answers = new List<DialogueCell>();

        [Serializable]
        public class DialogueCell
        {
            public DialogueType type;
            public bool isGoodAnswer;
            public Sprite dialogueSprite;
        }
    }
    public enum DialogueType { Answerable, Solo}
}

