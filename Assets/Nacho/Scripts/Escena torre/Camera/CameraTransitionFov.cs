using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransitionFov : MonoBehaviour
{
	public GameObject cameraToActivateATENETER;
	public GameObject cameraToActivateATEXIT;

	//private void OnTriggerStay(Collider other)
	//{
	//       if (other.CompareTag("fov"))
	//       {
	//		if (cameraToActivate.activeSelf == false)
	//		{
	//			CameraTransition.instance.ApagarCamarasVirtuales();
	//			cameraToActivate.SetActive(true);
	//		}
	//	}
	//   }
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("fov"))
		{
			Debug.Log("Player sale");
			if (cameraToActivateATEXIT !=null)
			{
				CameraTransition.instance.ApagarCamarasVirtuales();
				cameraToActivateATEXIT.SetActive(true);
			}
		}
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("fov"))
		{
			if (cameraToActivateATENETER != null)
			{
				Debug.Log("Player entra");
				CameraTransition.instance.ApagarCamarasVirtuales();
				cameraToActivateATENETER.SetActive(true);
			}
		}
	}
}
