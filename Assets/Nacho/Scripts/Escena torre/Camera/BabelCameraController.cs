using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class BabelCameraController : MonoBehaviour
{
    //AAAAAAAAAApublic CinemachineDollyCart Cdc;
    public PlayerController playerController;
    public GameObject torredeBabel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        torredeBabel.transform.LookAt(playerController.GetComponent<Transform>().position);
        //Cdc.m_Position = torredeBabel.transform.localPosition.z;
    }
}
