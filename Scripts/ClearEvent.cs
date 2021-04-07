using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ClearEvent : MonoBehaviour
{
    int panel;
    int level;
    public GameObject obj;
    public GameObject slider;
    internal bool clear;

    void Start() {
        clear = false;
    }
    public void Clear()
    {
        panel = GameObject.Find("Right_Basis").transform.childCount - 1;
        level = (int)slider.GetComponent<Slider>().value;
        Debug.Log(panel +","+ level);
        if (clear == false && panel == level)
        {
            GameObject.Find("Panel1").GetComponent<Renderer>().material.color += new Color(0, 0, 0, 0.5f);//”¼“§–¾‚Ì‚Ü‚ÜŒÅ‚Ü‚Á‚Ä‚µ‚Ü‚¤‚Ì‚Å•s“§–¾‚É‚·‚é
            obj.SetActive(true);
            clear = true;
            GameObject.Find("Reset").GetComponent<Button>().interactable = false;
            GameObject.Find("Undo").GetComponent<Button>().interactable = false;
            GameObject.Find("Pause_Button").GetComponent<Button>().interactable = false;
        }
    }
}