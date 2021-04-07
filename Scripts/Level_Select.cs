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
        level = GetComponent<Slider>().value;//�������̏����l�͂T
        GameObject.Find("Level").GetComponent<Text>().text = level.ToString();//GUI��̐����������l�ɐݒ肷��
    }

    public void Level()//�i�X���C�_�[���������������ƒl����є�тɂȂ邱�Ƃɒ��Ӂj
    {
        level = GetComponent<Slider>().value; //�ω���̒l
                
        GameObject.Find("Level").GetComponent<Text>().text = level.ToString();  //GUI��̐�����ύX����
        //GameObject.Find("Gen").GetComponent<Panel_Gen>().level = (int)this.level;//�������̏����l�ɐݒ肷��

        //������p�l������|���ĂP����ς݂Ȃ����^�C�v�̏�����--------
        this.gameObject.GetComponent<GeneratePanel>().Gen((int)level);
        //------------------------------------------------------------

        /*
        //�����X����p�l���ɒǉ�������A���炵���肷��^�C�v�̏������i�璷�Ȃ��ߖ������j

        if (newlevel > currentlevel) //���x���ύX�� �� �ύX�O (���x�����グ���Ƃ�)�̂Ƃ��̏���
        {
            for (int j = 1; j <= newlevel - currentlevel; j++)
            {
                for (int i = 1; i <= currentlevel - 1 + j; i++) 
                {
                    Basis.transform.GetChild(i).localPosition += Vector3.up * 0.2f;//���X���݂��Ă����p�l��������グ��
                }

                r = 3.0f + 2.0f * (float)(currentlevel + j);
                h = 0.1f;
                Instantiate((GameObject)Resources.Load("Panel")).name = "Panel" + (int)(currentlevel + j);        //Panel�̖��O��ς��Đ���
                target = GameObject.Find("Panel" + (int)(currentlevel + j));
                target.transform.parent = GameObject.Find("Left_Basis").transform;
                target.transform.localScale = new Vector3(r, h, r);                 //�ǉ����ꂽ�p�l���̔��a�𒲐�
                target.transform.localPosition = Vector3.up * 0.1f;                 //�ǉ����ꂽ�p�l���̈ʒu�𒲐�
                target.GetComponent<Renderer>().material.color = Color.HSVToRGB(0.1f * (float)((currentlevel + j) - 1), 1.0f, 0.8f);   //�F��ς���
                target.transform.SetSiblingIndex(1);                                //��P�q�I�u�W�F�N�g�Ɋ��荞�܂���
            }
        }

        else if (newlevel < currentlevel) //���x���ύX�� �� �ύX�O (���x�����������Ƃ�)�̂Ƃ��̏���
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
        currentlevel = newlevel; //�V�����ݒ肵�����x�����u���݂̃��x���v�Ƃ��Ĉ����p��*/
    }
}
