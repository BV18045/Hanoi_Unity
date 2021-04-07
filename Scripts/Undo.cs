using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Undo : MonoBehaviour
{
    internal int movecount; //�ړ���
    internal int counttmp0;
    internal int counttmp1;
    int counttmptmp;

    internal Vector3 picked;                   //�h���b�O����Ă���p�l���̌����������W
    internal Vector3 before;                   //�h���b�O���ē��������O�̃p�l���̍��W
    internal Vector3 after;                   //�h���b�O���ē������ꂽ��̃p�l���̍��W
    Vector3 tmp;

    internal GameObject moved;                  //�������ꂽ�p�l��

    internal Transform lefttop;
    internal Transform centertop;
    internal Transform righttop;

    internal bool clear;  //�ŏ��ƃN���A�ゾ���͎g���Ȃ�

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
            GameObject.Find("MoveCount").GetComponent<Text>().text = "�ړ��񐔁F" + movecount;
            //Debug.Log(movecount);
    }

    public Transform Tale(string name)//�q�I�u�W�F�N�g�̓��A���������o�����\�b�h
    {
        Transform tf = GameObject.Find(name).transform;
        int num = tf.transform.childCount;
        return tf.GetChild(num - 1);
    }
}
