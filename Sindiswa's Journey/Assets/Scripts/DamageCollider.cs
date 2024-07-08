using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OWL
{
    public class DamageCollider : MonoBehaviour
    {
        public BoxCollider damageCollider;
        [SerializeField] private int currentWeaponDamage = 25;

        private void Awake()
        {
            damageCollider = GetComponent<BoxCollider>();
            damageCollider.gameObject.SetActive(true);
            damageCollider.isTrigger = true;
            damageCollider.enabled = false;
        }

        public void EnableDamager()
        {
            damageCollider.enabled = true;
        }
        public void DisableDamager()
        {
            damageCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider collider)
        {
            print("hit");
            if (collider.tag == "Player")
            {
                PlayerStats playerStats = collider.GetComponent<PlayerStats>();
                if (playerStats != null)
                {
                    playerStats.TakeDamage(currentWeaponDamage);
                }
            }

            if (collider.CompareTag("Enemy"))
            {
                EnemyStat enemyStats = collider.GetComponent<EnemyStat>();
                if (enemyStats != null)
                {
                    enemyStats.TakeDamage(currentWeaponDamage);
                }
            }
        }
    }
}

