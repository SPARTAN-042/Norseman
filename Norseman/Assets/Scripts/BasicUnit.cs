using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MG.NM.Units
{
    [CreateAssetMenu(fileName = "New Unit", menuName= "New Unit")]
    public class Unit : ScriptableObject
    {
        public enum unitType
        {
            Worker,
            Warrior,
            Healer
        };

        public bool isPlayerUnit;

        public unitType type;

        public new string unitName;

        public GameObject unitPrefab;

        public int cost;
        public int attack;
        public int health;
        public int armor;



    }

}


