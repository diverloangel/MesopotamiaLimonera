using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniPlatformDelivery : MonoBehaviour
{
    public GameObject objeto;
    public bool entregado;
    public int ObjectType = 4;

    //public GameObject dialogue;

    public GameObject Off;
    public GameObject On;

    private void Start()
    {
        ObjectType = 4;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (PickUp.instance.carryingObject == true && PickUp.instance.tipo == ObjectType)
            {
                PickUp.instance.carryingObject = false;
                PickUp.instance.TurnOffAllObjectsInCharacter();
                objeto.SetActive(true);
                //dialogue.SetActive(true);

                Off.SetActive(false); On.SetActive(true);
                entregado = true;
                CheckMiniPlatformWin.instance.ComprobarVictoria();
            }
            if (entregado == false)
            {

            }
        }
    }
}
