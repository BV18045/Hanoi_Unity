using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Undo : MonoBehaviour
{
    internal int movecount; //移動回数
    internal int counttmp0;
    internal int counttmp1;
    int counttmptmp;

    internal Vector3 picked;                   //ドラッグされているパネルの元あった座標
    internal Vector3 before;                   //ドラッグして動かされる前のパネルの座標
    internal Vector3 after;                   //ドラッグして動かされた後のパネルの座標
    Vector3 tmp;

    internal GameObject moved;                  //動かされたパネル

    internal Transform lefttop;
    internal Transform centertop;
    internal Transform righttop;

    internal bool clear;  //最初とクリア後だけは使えない

    void Start()
    {
        movecount = 0;
        counttmp0 = 0;
        counttmp1 = 0;
    }

    void Update()
    {
        if (clear != GameObject.Find("EventSystem").GetComponent<ClearEvent>().clear)
        clear = GameObject.Find("EventSystem").GetComponent<ClearEvent>().clear;
    }

    public void Click()
    {
            moved.transform.position = before;
            tmp = before;
            before = after;
            after = tmp;

            movecount = counttmp1;
            counttmptmp = counttmp0;
            counttmp0 = counttmp1;
            counttmp1 = counttmptmp;
            GameObject.Find("MoveCount").GetComponent<Text>().text = "移動回数：" + movecount;
            //Debug.Log(movecount);
    }

    public Transform Tale(string name)//子オブジェクトの内、末尾を取り出すメソッド
    {
        Transform tf = GameObject.Find(name).transform;
        int num = tf.transform.childCount;
        return tf.GetChild(num - 1);
    }
}
