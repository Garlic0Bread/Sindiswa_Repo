using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OWL
{
    public class WeaponSlotManager : MonoBehaviour
    {
        WeaponSlotHolder RightHandSlot;
        WeaponSlotHolder LeftHandSlot;

        DamageCollider leftHandDmgCollider;
        DamageCollider rightHandDmgCollider;

        private void Awake()
        {
            WeaponSlotHolder[] weaponSlotHolders = GetComponentsInChildren<WeaponSlotHolder>();
            foreach(WeaponSlotHolder weaponSlot in weaponSlotHolders)
            {
                if (weaponSlot.isLeftHandSlot)
                {
                    LeftHandSlot = weaponSlot;
                }
                else if(weaponSlot.isRightHandSlot)
                {
                    RightHandSlot = weaponSlot;
                }
            }
        }
        public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
        {
            if (isLeft)
            {
                LeftHandSlot.LoadWeaponModel(weaponItem);
                LoadLeftHandWeaponDmgCollider();
            }
            else
            {
                RightHandSlot.LoadWeaponModel(weaponItem);
                LoadRightHandWeaponDmgCollider();
            }
        }

        #region Handle Weapon's Damage Collider
        
        private void LoadLeftHandWeaponDmgCollider()
        {
            leftHandDmgCollider = LeftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }
        public void CloseLeftHandDmgCollider()
        {
            leftHandDmgCollider.DisableDamager();
        }
        public void OpenLeftHandDmgCollider()
        {
            leftHandDmgCollider.EnableDamager();
        }

        private void LoadRightHandWeaponDmgCollider()
        {
            rightHandDmgCollider = RightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }
        public void CloseRightHandDmgCollider()
        {
            rightHandDmgCollider.DisableDamager();
        }
        public void OpenRightHandDmgCollider()
        {
            rightHandDmgCollider.EnableDamager();
        }
        #endregion
    }
}

