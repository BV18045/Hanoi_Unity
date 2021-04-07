using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToTitle : MonoBehaviour
{
    GameObject target;
    public GameObject slider;
    int level;

    //ƒpƒlƒ‹‚Ì”
    float r;
    float h;
    float p;

    // Start is called before the first frame update
    public void Click()
    {
        level = (int)slider.GetComponent<Slider>().value;
        GameObject.Find("Gen").GetComponent<GeneratePanel>().Gen(level);

        GameObject.Find("Pause_Button").GetComponent<Button>().interactable = true;
    }
}
