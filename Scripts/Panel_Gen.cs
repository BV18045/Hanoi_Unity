using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Gen : MonoBehaviour
{
    GameObject target;

    //パネルの数
    internal int level;
    float r;
    float h;
    float p;

    void Start()
    {
        level = (int)GameObject.Find("Slider").GetComponent<Slider>().value;//生成時の初期値５を設定
        this.gameObject.GetComponent<GeneratePanel>().Gen(level);       //５枚のパネルを積み上げる
    }
    /*
    public void Gen(int level)
    {
        for (int i = 1; i <= 10; i++)
        {
                Destroy(GameObject.Find("Panel" + i));
        }
        //level = (int)GameObject.Find("Slider").GetComponent<Slider>().value;
        for (int i = level; i > 0; i--)
        {
            r = 3.0f + 2.0f * (float)i;//パネルの半径
            h = 0.1f;//パネルの厚み
            p = 0.1f + (h * 2.0f) * (float)(level - i);//パネルを積む基準(Basis)からの相対座標

            Instantiate((GameObject)Resources.Load("Panel")).name = "newPanel" + i;        //Panelの名前を設定して生成
            target = GameObject.Find("newPanel" + i);                                      //生成したパネルをtargetにする
            target.transform.parent = GameObject.Find("Left_Basis").transform;          //targetを"Left_Basis"の子にする
            target.transform.localScale = new Vector3(r, h, r);                         //追加されたパネルの半径を調整
            target.transform.localPosition = new Vector3(0, p, 0);                      //追加されたパネルの位置を調整
            target.GetComponent<Renderer>().material.color = Color.HSVToRGB(0.1f * (float)(i - 1), 1.0f, 0.8f);   //色を変える
            target.name = ("Panel" + i);//名前を変える
        }

        r = 3.0f + 2.0f * (float)(level + 1);

        GameObject.Find("Left_Infty").transform.localScale = new Vector3(r, 0.1f, r);
        GameObject.Find("Center_Infty").transform.localScale = new Vector3(r, 0.1f, r);
        GameObject.Find("Right_Infty").transform.localScale = new Vector3(r, 0.1f, r);
    }*/
}