using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Types : MonoBehaviour
{
    [Range(0,3)]
    public int tipo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlatformToDeliver")
        {
            if (PickUp.instance.carryingObject == true)
            {
                PickUp.instance.carryingObject = false;
                PickUp.instance.TurnOffAllObjectsInCharacter();
                //llamar a la plataforma que haga algo
                //other.gameObject.GetComponent
            }

        }

        if (other.tag == "Player")
        {
            if (PickUp.instance.carryingObject == false)
            {
                PickUp.instance.tipo = tipo;
                PickUp.instance.carryingObject = true;
                Destroy(this.gameObject);
                PickUp.instance.PutObjectInCharacter();
            }
        }
    }
}
