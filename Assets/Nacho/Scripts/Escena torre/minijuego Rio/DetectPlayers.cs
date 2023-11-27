using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayers : MonoBehaviour
{
    public float velocityModif;

    public PlayerController controler;

    public bool stay;
    public bool exit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("COLLISION ENTER");
            PlayerController _temp = other.gameObject.GetComponent<PlayerController>();

            if (_temp != false)
            {
                controler = _temp;
                controler.beDragged = true;
                controler.directionXToBeDragged = velocityModif;

                MusicManager.instance.MusicaAguaPlay();
            }
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (controler != null)
    //    {
    //        Debug.Log("COLLISION STAY");
    //        //controler.transform.position.x + velocityModif;

    //        //controler.moveDirection = new Vector3(velocityModif, controler.moveDirection.y, controler.moveDirection.z);
    //        //controler.moveDirection.x = velocityModif;

    //        //stay = true;
    //    }
    //}


    private void OnTriggerExit(Collider other)
    {
        if (controler != null)
        {
            //stay = false;
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("COLLISION EXIT");
                controler.beDragged = false;

                //PlayerController _temp = other.gameObject.GetComponent<PlayerController>();

                //controler.moveDirection = new Vector3(0f, controler.moveDirection.y, controler.moveDirection.z);

                //controler = null;
                MusicManager.instance.MusicaAguaStop();

            }
        }
    }
}
