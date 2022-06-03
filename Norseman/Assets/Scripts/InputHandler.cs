using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.NM.InputManager
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler instance;
        void Start()
        {
            instance = this;
        }

        void Update()
        {
        
        }

        public void HandleUnitMovement()
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Create a ray
                //Check if unit is hit
            }
        }
    }
}


