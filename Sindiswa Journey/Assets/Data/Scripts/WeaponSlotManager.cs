using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OWL
{
    public class WeaponSlotManager : MonoBehaviour
    {
        WeaponSlotHolder MeleeWeapon_Slot;//right hand
        WeaponSlotHolder Shield_Slot;//left hand

        DamageCollider leftHandDmgCollider;
        DamageCollider rightHandDmgCollider;

        private void Awake()
        {
            WeaponSlotHolder[] WeaponSlots = GetComponentsInChildren<WeaponSlotHolder>();
            foreach(WeaponSlotHolder weaponSlot in WeaponSlots)
            {
                if (weaponSlot.is_ShieldHand_Slot)
                {
                    Shield_Slot = weaponSlot;
                }
                else if(weaponSlot.is_MeleeHand_Slot)
                {
                    MeleeWeapon_Slot = weaponSlot;
                }
            }
        }
        public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isShield)
        {
            if (isShield)
            {
                Shield_Slot.LoadWeaponModel(weaponItem);
                LoadLeftHandWeaponDmgCollider();
            }
            else
            {
                MeleeWeapon_Slot.LoadWeaponModel(weaponItem);
                LoadRightHandWeaponDmgCollider();
            }
        }

        #region Handle Weapon's Damage Collider
        
        private void LoadLeftHandWeaponDmgCollider()
        {
            leftHandDmgCollider = Shield_Slot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
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
            rightHandDmgCollider = MeleeWeapon_Slot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
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

