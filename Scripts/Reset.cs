using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    int level;
    public GameObject slider;
    public void Click()
    {
        level = (int)slider.GetComponent<Slider>().value;
        this.gameObject.GetComponent<GeneratePanel>().Gen(level);
        GameObject.Find("MoveCount").GetComponent<Text>().text = "ˆÚ“®‰ñ”F0";
            GameObject.Find("Undo").GetComponent<Button>().interactable = false;
            GameObject.Find("Reset").GetComponent<Button>().interactable = false;
    }

}
