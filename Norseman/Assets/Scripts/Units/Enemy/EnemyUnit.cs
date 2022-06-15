using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.NM.Units.Enemy
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
	public class EnemyUnit : MonoBehaviour
    {
        private UnityEngine.AI.NavMeshAgent navAgent;

        public UnitStatTypes.Base baseStats;

        private Collider[] rangeColliders;

        private Transform aggroTarget;

        private bool hasAggro = false;

        private float distance;

        private void Start()
        {
            navAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        }

        private void Update()
        {
            if (!hasAggro)
            {
                checkForEnemyTargets();
            }
            else
            {
                MoveToAggroTarget();
            }
        }


        private void checkForEnemyTargets()
        {
            rangeColliders = Physics.OverlapSphere(transform.position, baseStats.aggroRange);

            for (int i = 0; i < rangeColliders.Length; i++)
            {
                if (rangeColliders[i].gameObject.layer == UnitHandler.instance.pUnitLayer)
                {
                    aggroTarget = rangeColliders[i].gameObject.transform;
                    hasAggro = true;
                    break;
                }
            }
        }

        private void MoveToAggroTarget()
        {
            distance = Vector3.Distance(aggroTarget.position, transform.position);
            navAgent.stoppingDistance = (baseStats.atkRange + 1);

            if (distance <= baseStats.aggroRange)
            {
                navAgent.SetDestination(aggroTarget.position);
            }
        }
    }
}
