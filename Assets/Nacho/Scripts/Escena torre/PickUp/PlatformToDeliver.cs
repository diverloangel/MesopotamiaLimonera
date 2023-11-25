using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformToDeliver : MonoBehaviour
{
    public GameObject objeto;
    public bool entregado;
    [Range(0,3)]
    public int ObjectType;

    public GameObject quest;
    public GameObject dialogue;

    public GameObject Off;
    public GameObject On;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (PickUp.instance.carryingObject == true && PickUp.instance.tipo == ObjectType)
            {
                PickUp.instance.carryingObject = false;
                PickUp.instance.TurnOffAllObjectsInCharacter();
                objeto.SetActive(true);
                dialogue.SetActive(true);

                Off.SetActive(false); On.SetActive(true);
                entregado = true;
                quest.SetActive(false);
            }
            if (entregado == false)
            {
                quest.SetActive(true);
            }
        }
    }
}
