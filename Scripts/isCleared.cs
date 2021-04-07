using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isCleared : MonoBehaviour
{
    public void Click(bool tf)
    {
        GameObject.Find("EventSystem").GetComponent<ClearEvent>().clear = tf;
    }
}
