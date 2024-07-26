using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OWL
{
    public class PlayerInventory : MonoBehaviour
    {


        /*
        WeaponSlotManager weaponSlotManager;

        public WeaponItem current_MeleeWeapon;
        public WeaponItem current_ShieldType;
        public WeaponItem Unarmed;

        public WeaponItem[] MeleeWeapons_InHand = new WeaponItem[1];
        public WeaponItem[] Shields_InHand = new WeaponItem[1];
        [SerializeField] private int current_MeleeWeapon_Index = -1;
        [SerializeField] private int current_ShieldType_Index = -1;


        
        private void Awake()
        {
            weaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        }
        
        private void Start()
        {
            current_MeleeWeapon = MeleeWeapons_InHand[current_MeleeWeapon_Index];
            current_ShieldType = Shields_InHand[current_ShieldType_Index];

            weaponSlotManager.LoadWeaponOnSlot(current_MeleeWeapon, false);
            weaponSlotManager.LoadWeaponOnSlot(current_ShieldType, true);
        }
        public void Change_MeleeWeapon()
        {
            current_MeleeWeapon_Index++;
            if (current_MeleeWeapon_Index > MeleeWeapons_InHand.Length - 1)
            {
                current_MeleeWeapon_Index = -1;
                current_MeleeWeapon = Unarmed;
                weaponSlotManager.LoadWeaponOnSlot(Unarmed, false);
            }
            else if (MeleeWeapons_InHand[current_MeleeWeapon_Index] != null)
            {
                current_MeleeWeapon = MeleeWeapons_InHand[current_MeleeWeapon_Index];
                weaponSlotManager.LoadWeaponOnSlot(MeleeWeapons_InHand[current_MeleeWeapon_Index], false);
            }
            else
            {
                current_MeleeWeapon_Index = current_MeleeWeapon_Index + 1;
            }
        }
        public void Change_ShieldType()
        {
            current_ShieldType_Index++;
            if (current_ShieldType_Index > Shields_InHand.Length - 1)
            {
                current_ShieldType_Index = -1;
                current_ShieldType = Unarmed;
                weaponSlotManager.LoadWeaponOnSlot(Unarmed, true);
            }
            else if (Shields_InHand[current_ShieldType_Index] != null)
            {
                current_ShieldType = Shields_InHand[current_ShieldType_Index];
                weaponSlotManager.LoadWeaponOnSlot(Shields_InHand[current_ShieldType_Index], true);
            }
            else
            {
                current_ShieldType_Index = current_ShieldType_Index + 1;
            }
        }*/

    }
}

