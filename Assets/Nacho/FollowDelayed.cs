using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowDelayed : MonoBehaviour
{
    public float secondsToNextPoint;
    public List<Vector3> points = new List<Vector3>();
    public float speedToMove;
    public float toRemoveMultiply;

    //public void Start()
    //{
    //    StartCoroutine(nameof(GetNextPoint));
    //    StartCoroutine(nameof(RemovePoint));
    //}
    //IEnumerator GetNextPoint()
    //{
    //    yield return new WaitForSeconds(secondsToNextPoint);
    //    points.Add(PlayerController.instance.transform.position);
    //    StartCoroutine(nameof(GetNextPoint));

    //}
    //IEnumerator RemovePoint()
    //{
    //    yield return new WaitForSeconds(secondsToNextPoint * toRemoveMultiply);
    //    //Vector3 a = points[0];
    //    points.Remove(points[0]);
    //    StartCoroutine(nameof(RemovePoint));
    //}
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, PlayerController.instance.transform.position, speedToMove * Time.deltaTime);
    }
}
