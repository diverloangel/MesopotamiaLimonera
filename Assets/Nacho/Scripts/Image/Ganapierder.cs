using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ganapierder : MonoBehaviour
{
    public static bool win;

    public GameObject objectWin;
    public GameObject objectLose;

    private void Start()
    {
        if (win)
        {
            objectWin.SetActive(true);
        }
        else
        {
            objectLose.SetActive(true);
        }
    }
}
