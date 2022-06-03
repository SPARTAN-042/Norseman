using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MG.NM.Units
{
    [CreateAssetMenu(fileName = "New Unit", menuName= "New Unit/Basic")]
    public class BasicUnit : ScriptableObject
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

        public GameObject friendlyPrefab;
        public GameObject enemyPrefab;

        public int cost;
        public int attack;
        public int health;
        public int armor;



    }

}


