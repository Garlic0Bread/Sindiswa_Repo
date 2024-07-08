using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OWL
{
    public class DamagePlayer : MonoBehaviour
    {
        [SerializeField] private int damage;

        private void OnTriggerEnter(Collider other)
        {
            PlayerStats plyrStats = other.GetComponent<PlayerStats>();
            if(plyrStats != null)
            {
                plyrStats.TakeDamage(damage);
            }
        }
    }
}

