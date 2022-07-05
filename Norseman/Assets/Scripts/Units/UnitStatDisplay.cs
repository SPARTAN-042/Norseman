using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.NM.Units.Player
{
    public class UnitStatDisplay : MonoBehaviour
    {

        public float maxHealth, armor,  currentHealth;

        [SerializeField] private Image healthBarAmount;

        private bool isPlayerUnit = false;

        void Start()
        {
            try
            {
                maxHealth = gameObject.GetComponentInParent<Player.PlayerUnit>().baseStats.health;
                armor = gameObject.GetComponentInParent<Player.PlayerUnit>().baseStats.armor;
                isPlayerUnit = true;
            }
            catch(Exception)
            {
                Debug.Log("No player Unit. Trying Enemy Unit...");
                try
                {
                maxHealth = gameObject.GetComponentInParent<Enemy.EnemyUnit>().baseStats.health;
                armor = gameObject.GetComponentInParent<Enemy.EnemyUnit>().baseStats.armor;
                isPlayerUnit = false;
                }
                catch(Exception)
                {
                    Debug.Log("No Unit Scripts found!");
                }
            }
            
            currentHealth = maxHealth;
        }

        void Update()
        {
            HandleHealth();
        }

        public void TakeDamage(float damage)
        {
            float totalDamage = damage - baseStats.armor;
            currentHealth -= totalDamage;
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


