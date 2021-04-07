using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisSet : MonoBehaviour
{
    public GameObject[] obj = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        obj[0].SetActive(true);
        for (int i = 1; i < 5; i++) {
            obj[i].SetActive(false);
        }
    }
    void Update()
    {

    }
}
