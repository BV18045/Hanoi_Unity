using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Gen : MonoBehaviour
{
    GameObject target;

    //�p�l���̐�
    internal int level;
    float r;
    float h;
    float p;

    void Start()
    {
        level = (int)GameObject.Find("Slider").GetComponent<Slider>().value;//�������̏����l�T��ݒ�
        this.gameObject.GetComponent<GeneratePanel>().Gen(level);       //�T���̃p�l����ςݏグ��
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
            r = 3.0f + 2.0f * (float)i;//�p�l���̔��a
            h = 0.1f;//�p�l���̌���
            p = 0.1f + (h * 2.0f) * (float)(level - i);//�p�l����ςފ(Basis)����̑��΍��W

            Instantiate((GameObject)Resources.Load("Panel")).name = "newPanel" + i;        //Panel�̖��O��ݒ肵�Đ���
            target = GameObject.Find("newPanel" + i);                                      //���������p�l����target�ɂ���
            target.transform.parent = GameObject.Find("Left_Basis").transform;          //target��"Left_Basis"�̎q�ɂ���
            target.transform.localScale = new Vector3(r, h, r);                         //�ǉ����ꂽ�p�l���̔��a�𒲐�
            target.transform.localPosition = new Vector3(0, p, 0);                      //�ǉ����ꂽ�p�l���̈ʒu�𒲐�
            target.GetComponent<Renderer>().material.color = Color.HSVToRGB(0.1f * (float)(i - 1), 1.0f, 0.8f);   //�F��ς���
            target.name = ("Panel" + i);//���O��ς���
        }

        r = 3.0f + 2.0f * (float)(level + 1);

        GameObject.Find("Left_Infty").transform.localScale = new Vector3(r, 0.1f, r);
        GameObject.Find("Center_Infty").transform.localScale = new Vector3(r, 0.1f, r);
        GameObject.Find("Right_Infty").transform.localScale = new Vector3(r, 0.1f, r);
    }*/
}