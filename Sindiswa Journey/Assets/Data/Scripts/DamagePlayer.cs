using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OWL
{
    public class DamagePlayer : MonoBehaviour, IInteractable
    {
        [SerializeField] private int damage;

        public void Interact()
        {
            print("this works");
            PlayerStats plyrStats = GameObject.FindObjectOfType<PlayerStats>();
            if (plyrStats != null)
            {
                plyrStats.TakeDamage(damage);
            }
        }
    }
}

