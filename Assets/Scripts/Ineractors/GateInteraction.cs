using flat_land.gameManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace flat_land.interaction
{
    public class GateInteraction : AbstractInteractor<GameState>
    {
        [SerializeField] GameState gameState;
        [SerializeField] public string WorldName;
        public override GameState Interact()
        {
            Debug.Log(gameState.ToString());    
            return gameState;
        }
    }
}

