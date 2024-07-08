using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OWL
{
    public class PlayerInventory : MonoBehaviour
    {
        WeaponSlotManager weaponSlotManager;

        public WeaponItem rightHandWeapon;
        public WeaponItem leftHandWeapon;

        private void Awake()
        {
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        }

        private void Start()
        {
            weaponSlotManager.LoadWeaponOnSlot(leftHandWeapon, false);
            weaponSlotManager.LoadWeaponOnSlot(rightHandWeapon, true);

        }
    }
}

