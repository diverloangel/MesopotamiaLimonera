using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public bool carryingObject;
    public int tipo;

    public GameObject[] tipoObject;

    public static PickUp instance;
    private void Awake()
    {
        instance = this;
        TurnOffAllObjectsInCharacter();
    }


    private void OnTriggerEnter(Collider other)
    {
        //if (!carryingObject)
        //{
        //    if (other.tag == "ObjectToPick")
        //    {
        //        tipo = other.GetComponent<Types>().tipo;
        //        carryingObject = true;
        //        Destroy(gameObject);
        //        PutObjectInCharacter();
        //    }
        //}
        //if (carryingObject)
        //{
        //    if (other.tag == "PlatformToDeliver")
        //    {
        //        TurnOffAllObjectsInCharacter();
        //        carryingObject = false;
        //        //llamar a la plataforma que haga algo
        //    }
        //}

    }

    public void PutObjectInCharacter()
    {
        tipoObject[tipo].SetActive(true);
        MusicManager.instance.SonidoCogerObjetoPlay();
    }
    public void TurnOffAllObjectsInCharacter()
    {
        for (int i = 0; i < tipoObject.Length; i++)
        {
            tipoObject[i].SetActive(false);
        }
        MusicManager.instance.SonidoCogerObjetoPlay();
    }
}
