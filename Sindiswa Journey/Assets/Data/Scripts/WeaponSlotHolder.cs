using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OWL
{
    public class WeaponSlotHolder : MonoBehaviour
    {
        public Transform parrentOverride;
        public bool is_ShieldHand_Slot;
        public bool is_MeleeHand_Slot;

        public GameObject currentWeaponModel;

        public void UnloadWeapon()
        {
            if(currentWeaponModel != null)
            {
                currentWeaponModel.SetActive(false);
            }
        }
        public void UnloadWeapon_And_Destroy()
        {
            if(currentWeaponModel != null)
            {
                Destroy(currentWeaponModel);
            }
        }
        public void LoadWeaponModel(WeaponItem Model)
        {
            UnloadWeapon_And_Destroy();
            if (Model == null)
            {
                UnloadWeapon();
                return;
            }

            GameObject model = Instantiate(Model.weaponPrefab) as GameObject;
            if(model != null )
            {
                if(parrentOverride != null)
                {
                    model.transform.parent = parrentOverride;
                }

                else
                {
                    model.transform.parent = transform;
                }

                currentWeaponModel = model;
            }
        }
    }
}







