using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MG.NM.Units
{
    [CreateAssetMenu(fileName = "New Unit", menuName= "New Unit")]
    public class BasicUnit : ScriptableObject
    {
        public enum unitType
        {
            Worker,
            Warrior,
            Healer
        };

        [Space(15)]
        [Header("Unit Settings")]
        [Space(15)]
        public unitType type;

        public new string unitName;

        public GameObject unitPrefab;

        [Space(40)]
        [Header("Unit Base Stats")]
        [Space(15)]
        public int cost;
        public int attack;
        public int atkRange;
        public int health;
        public int armor;



    }

}


