using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.NM.Units
{
    public class UnitHandler : MonoBehaviour
    {
        public static UnitHandler instance;

        [SerializeField]
        private BasicUnit worker, warrior, healer;

        private void Start()
        {
            instance = this;
        }

        public (int cost, int attack, int atkRange, int health, int armor) GetBasicUnitStats(string type)
        {
            BasicUnit unit;

            switch (type)
            {
                case "worker":
                    unit = worker;
                    break;
                case "warrior":
                    unit = warrior;
                    break;
                case "healer":
                    unit = healer;
                    break;
                default:
                    Debug.Log($"Unit Type: {type} could not be found or does not exist!");
                    return (0, 0, 0, 0, 0);
            }
            return (unit.cost, unit.attack, unit.atkRange, unit.health, unit.armor);
        }

        public void SetBasicUnitStats(Transform type)
        {
            foreach (Transform child in type)
            {
                foreach (Transform unit in child)
                {
                    string unitName = child.name.Substring(0, child.name.Length - 1).ToLower();
                    var stats = GetBasicUnitStats(unitName);
                    Player.PlayerUnit pU;

                    if (type == NM.Player.PlayerManager.instance.playerUnits)
                    {
                        pU = unit.GetComponent<Player.PlayerUnit>();

                        pU.cost = stats.cost;
                        pU.attack = stats.attack;
                        pU.atkRange = stats.atkRange;
                        pU.health = stats.health;
                        pU.armor = stats.armor;
                    }
                    else if(type == NM.Player.PlayerManager.instance.enemyUnits)
                    {
                        // set enemy stats
                    }                    

                    // if upgrades add them to unit stats
                }
            }
        }
    }
}


