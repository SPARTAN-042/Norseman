using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MG.NM.Player;

namespace MG.NM.Units
{
    public class UnitHandler : MonoBehaviour
    {
        public static UnitHandler instance;

        [SerializeField]
        private BasicUnit worker, warrior, healer;

        public LayerMask pUnitLayer, eUnitLayer;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            pUnitLayer = LayerMask.NameToLayer("PlayerUnits");
            eUnitLayer = LayerMask.NameToLayer("EnemyUints");
        }

        public (float cost, float aggroRange, float attack, float atkRange, float health, float armor) GetBasicUnitStats(string type)
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
                    return (0, 0, 0, 0, 0, 0);
            }
            return (unit.baseStats.cost, unit.baseStats.aggroRange, unit.baseStats.attack, unit.baseStats.atkRange, unit.baseStats.health, unit.baseStats.armor);
        }

        public void SetBasicUnitStats(Transform type)
        {
            Transform pUnits = PlayerManager.instance.playerUnits;
            Transform eUnits = PlayerManager.instance.enemyUnits;
            foreach (Transform child in type)
            {
                foreach (Transform unit in child)
                {
                    string unitName = child.name.Substring(0, child.name.Length - 1).ToLower();
                    var stats = GetBasicUnitStats(unitName);
                    

                    if (type == pUnits)
                    {
                        Player.PlayerUnit pU = unit.GetComponent<Player.PlayerUnit>();

                        pU.baseStats.cost = stats.cost;
                        pU.baseStats.aggroRange = stats.aggroRange;
                        pU.baseStats.attack = stats.attack;
                        pU.baseStats.atkRange = stats.atkRange;
                        pU.baseStats.health = stats.health;
                        pU.baseStats.armor = stats.armor;
                    }
                    else if(type == eUnits)
                    {
                        // set enemy stats
                        Enemy.EnemyUnit eU = unit.GetComponent<Enemy.EnemyUnit>();

                        eU.baseStats.cost = stats.cost;
                        eU.baseStats.aggroRange = stats.aggroRange;
                        eU.baseStats.attack = stats.attack;
                        eU.baseStats.atkRange = stats.atkRange;
                        eU.baseStats.health = stats.health;
                        eU.baseStats.armor = stats.armor;
                    }                    

                    // if upgrades add them to unit stats
                }
            }
        }
    }
}


