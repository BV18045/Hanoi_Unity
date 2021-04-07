using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Level_Select : MonoBehaviour
{
    GameObject target;
    GameObject Basis;

    internal float level;
    //internal float newlevel;
    //internal float currentlevel;
    float r;
    float h;
    float p;

    // Start is called before the first frame update

    public void Start()
    {
        Basis = GameObject.Find("Left_Basis");
        level = GetComponent<Slider>().value;//生成時の初期値は５
        GameObject.Find("Level").GetComponent<Text>().text = level.ToString();//GUI上の数字を初期値に設定する
    }

    public void Level()//（スライダーを激しく動かすと値が飛び飛びになることに注意）
    {
        level = GetComponent<Slider>().value; //変化後の値
                
        GameObject.Find("Level").GetComponent<Text>().text = level.ToString();  //GUI上の数字を変更する
        //GameObject.Find("Gen").GetComponent<Panel_Gen>().level = (int)this.level;//生成時の初期値に設定する

        //元あるパネルを一掃して１から積みなおすタイプの処理↓--------
        this.gameObject.GetComponent<GeneratePanel>().Gen((int)level);
        //------------------------------------------------------------

        /*
        //↓元々あるパネルに追加したり、減らしたりするタイプの処理↓（冗長なため未実装）

        if (newlevel > currentlevel) //レベル変更後 ＞ 変更前 (レベルを上げたとき)のときの処理
        {
            for (int j = 1; j <= newlevel - currentlevel; j++)
            {
                for (int i = 1; i <= currentlevel - 1 + j; i++) 
                {
                    Basis.transform.GetChild(i).localPosition += Vector3.up * 0.2f;//元々存在していたパネルをせり上げる
                }

                r = 3.0f + 2.0f * (float)(currentlevel + j);
                h = 0.1f;
                Instantiate((GameObject)Resources.Load("Panel")).name = "Panel" + (int)(currentlevel + j);        //Panelの名前を変えて生成
                target = GameObject.Find("Panel" + (int)(currentlevel + j));
                target.transform.parent = GameObject.Find("Left_Basis").transform;
                target.transform.localScale = new Vector3(r, h, r);                 //追加されたパネルの半径を調整
                target.transform.localPosition = Vector3.up * 0.1f;                 //追加されたパネルの位置を調整
                target.GetComponent<Renderer>().material.color = Color.HSVToRGB(0.1f * (float)((currentlevel + j) - 1), 1.0f, 0.8f);   //色を変える
                target.transform.SetSiblingIndex(1);                                //第１子オブジェクトに割り込ませる
            }
        }

        else if (newlevel < currentlevel) //レベル変更後 ＜ 変更前 (レベルを下げたとき)のときの処理
        {
            for (int i = 1; i <= currentlevel - newlevel; i++)
            {
                Destroy(GameObject.Find(Basis.transform.GetChild(i).name));
            }

            for (int i = 1; i <= currentlevel; i++)
            {
                Basis.transform.GetChild(i).localPosition += Vector3.down * 0.2f * (currentlevel - newlevel);
            }
        }
        currentlevel = newlevel; //新しく設定したレベルを「現在のレベル」として引き継ぐ*/
    }
}
