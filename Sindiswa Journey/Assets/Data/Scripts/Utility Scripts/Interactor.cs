using OWL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable//an interface that store various types of 'things'/information and can be called by different types of 
{                      //objects without having to create different
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform interactorSource;
    public float interactionRange;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new(interactorSource.position, interactorSource.forward);//create a ray with the position and direction of the interactorSource
            Item_PickUp itemPickUp = gameObject.GetComponent<Item_PickUp>();

            if (Physics.Raycast(ray, out RaycastHit hitInfo, interactionRange))//find out what the created raycast hit within its range and put the informtaion in "hitInfo"
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {//if the information stored in the "hitInfo" is of a collider, find out if the object has an interaction-interface and if so, call the 'Interact' function
                    interactObj.Interact();
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamagePlayer damagePlayer = collision.gameObject.GetComponent<DamagePlayer>();
        if (collision.gameObject.TryGetComponent(out IInteractable obj) && damagePlayer != null)
        {
            obj.Interact();
        }
    }
}
