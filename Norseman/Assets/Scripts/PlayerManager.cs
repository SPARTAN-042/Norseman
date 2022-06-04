using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MG.NM.InputManager;

namespace MG.NM.Player
{
    public class PlayerManager : MonoBehaviour
    {
        public static PlayerManager instance;

        public Transform playerUnits;

        void Start()
        {
            instance = this;
        }

        void Update()
        {
            InputHandler.instance.HandleUnitMovement();
        }
    }
}


