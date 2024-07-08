using OWL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OWL
{
    public class EnemyStat : MonoBehaviour
    {
        [SerializeField] private int healthLvl = 10;
        [SerializeField] private int currentHealth;
        [SerializeField] private int maxHealth;
        Animator animator;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }
        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
        }

        private int SetMaxHealthFromHealthLevel()//research about Dark Soul's vigor to understand more. A formula that calculates total health points depending on the player's health level
        {
            maxHealth = healthLvl * 10;
            return maxHealth;
        }
        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;
            animator.Play("Enemy_DmgHit_1");
            if(currentHealth <= 0)
            {
                print("dead");

                currentHealth = 0;
                animator.Play("Enemy_Death_1");
            }
        }
    }
}
