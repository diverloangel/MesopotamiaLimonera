using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CiudadanoManager : MonoBehaviour
{
    public bool realizarAccion;
    public Transform centrodeEscenario;
    public float rotationSpeed;
    public float moveSpeed;
    public bool move;
    public float timeToScaleDown;
    public bool scaleDown;

    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        //anim.SetBool("idle", true);
    }
    private void Update()
    {
        if (realizarAccion) 
        {
            realizarAccion = false;
            anim.SetBool("run", true);

            //Quaternion nextRotation = Quaternion.Lerp(transform.localRotation, centrodeEscenario.transform.position, Time.deltaTime);
            StartCoroutine(nameof(Rotate));
            StartCoroutine(nameof(waitToMove));
        }

        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, centrodeEscenario.position, moveSpeed * Time.deltaTime);
        }
        if (scaleDown)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0, 0, 0), timeToScaleDown * Time.deltaTime);

        }
        if (transform.localScale.x <= 0.03f)
        {
            Destroy(this.gameObject);
        }

    }
    IEnumerator Rotate()
    {
        Quaternion targetRotation = Quaternion.identity;
        do
        {
            Debug.Log("do rotation");
            Vector3 targetDirection = (centrodeEscenario.position - transform.position).normalized;
            targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;

        } while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f);
    }

    IEnumerator waitToMove()
    {
        yield return new WaitForSeconds(1f);
        move = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("torre"))
        {
            scaleDown = true;
        }
    }

}
