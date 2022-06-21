using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace MG.NM.Units.Enemy
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
	public class EnemyUnit : MonoBehaviour
    {
        private UnityEngine.AI.NavMeshAgent navAgent;

        public UnitStatTypes.Base baseStats;

        private Collider[] rangeColliders;

        private Transform aggroTarget;

        private Player.PlayerUnit aggroUnit;

        private bool hasAggro = false;

        private float distance;

        public GameObject unitStatDisplay;

        public Image healthBarAmount;

        public float currentHealth;

        private float atkCooldown;

        private void Start()
        {
            navAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
            currentHealth = baseStats.health;
        }

        private void Update()
        {
            atkCooldown -= Time.deltaTime;

            if (!hasAggro)
            {
                checkForEnemyTargets();
            }
            else
            {
                Attack();
                MoveToAggroTarget();
            }
        }

        private void LateUpdate()
        {
            HandleHealth();
        }


        private void checkForEnemyTargets()
        {
            rangeColliders = Physics.OverlapSphere(transform.position, baseStats.aggroRange);

            for (int i = 0; i < rangeColliders.Length; i++)
            {
                if (rangeColliders[i].gameObject.layer == UnitHandler.instance.pUnitLayer)
                {
                    aggroTarget = rangeColliders[i].gameObject.transform;
                    aggroUnit = aggroTarget.gameObject.GetComponent<Player.PlayerUnit>();
                    hasAggro = true;
                    break;
                }
            }
        }

        private void Attack()
        {
            if (atkCooldown <= 0 && distance <= baseStats.atkRange + 1)
            {
                aggroUnit.TakeDamage(baseStats.attack);
                atkCooldown = baseStats.atkSpeed;
            }
        }

        public void TakeDamage(float damage)
        {
            float totalDamage = damage - baseStats.armor;
            currentHealth -= totalDamage;
        }

        private void MoveToAggroTarget()
        {
            if (aggroTarget == null)
            {
                navAgent.SetDestination(transform.position);
                hasAggro = false;
            }
            else
            {
                distance = Vector3.Distance(aggroTarget.position, transform.position);
                navAgent.stoppingDistance = (baseStats.atkRange + 1);

                if (distance <= baseStats.aggroRange)
                {
                    navAgent.SetDestination(aggroTarget.position);
                }
            }
        }

        private void HandleHealth()
        {
            Camera camera = Camera.main;
            unitStatDisplay.transform.LookAt(unitStatDisplay.transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);

            healthBarAmount.fillAmount = currentHealth / baseStats.health;

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
