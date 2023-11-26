using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{

    //float fov;
    //public float desiredVision;
    //public float fovTransicionSpeed;

    public CinemachineVirtualCamera cam;
    public GameObject CamaraFovLejos;
    public GameObject CamaraFovCerca;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fov"))
        {
            CamaraFovCerca.SetActive(true);
            CamaraFovLejos.SetActive(false);
            Debug.Log("Player entra");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("fov"))
        {
            CamaraFovLejos.SetActive(true);
            CamaraFovCerca.SetActive(false);
            Debug.Log("Player sale");
        }
    }


}
