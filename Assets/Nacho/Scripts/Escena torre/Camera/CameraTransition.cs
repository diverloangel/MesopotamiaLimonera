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
    public GameObject CamaraFovMidLejos;
    public GameObject CamaraFovMid;
    public GameObject CamaraFovCerca;


    public List<GameObject> cameras = new List<GameObject>();
    public static CameraTransition instance;
	private void Awake()
	{
        cameras.Add(CamaraFovLejos);
        cameras.Add(CamaraFovMid);
        cameras.Add(CamaraFovCerca);

        instance = this;
	}

    public void ApagarCamarasVirtuales()
	{
		for (int i = 0; i < cameras.Count; i++)
		{
			cameras[i].SetActive(false);
		}
	}

	//private void OnTriggerEnter(Collider other)
	//   {
	//       if (other.CompareTag("fov"))
	//       {
	//           CamaraFovCerca.SetActive(true);
	//           CamaraFovLejos.SetActive(false);
	//           Debug.Log("Player entra");
	//       }
	//   }
	//   private void OnTriggerExit(Collider other)
	//   {
	//       if (other.CompareTag("fov"))
	//       {
	//           CamaraFovLejos.SetActive(true);
	//           CamaraFovCerca.SetActive(false);
	//           Debug.Log("Player sale");
	//       }
	//   }


}
