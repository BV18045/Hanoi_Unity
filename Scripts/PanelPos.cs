using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class PanelPos : MonoBehaviour
{
    GameObject pointer;
    GameObject BackStake;
    GameObject ParentStake;

    GameObject ls;
    GameObject cs;
    GameObject rs;

    Vector3 pointing;
    Vector3 backpos;
    Vector3 movepos;

    Transform compared;

    Transform lefttop;
    Transform centertop;
    Transform righttop;

    Undo Undo;

    int ObjCount;
    int pile;

    float picked_r;
    float compared_r;

    bool clear;
    bool execute;

    // Start is called before the first frame update
    void Start()
    {
        execute = true;
        pointer = GameObject.Find("Pointer");
        ls = GameObject.Find("Left_Stake");
        cs = GameObject.Find("Center_Stake");
        rs = GameObject.Find("Right_Stake");
        pointing = pointer.transform.position;
        movepos =ls.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        clear = GameObject.Find("EventSystem").GetComponent<ClearEvent>().clear;
        if (Input.GetMouseButton(0))
            pointing = pointer.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        ObjCount = other.transform.GetChild(0).childCount - 1;        //パネルの数

        if (this.tag == "picked")
        {
            compared = other.transform.GetChild(0).GetChild(ObjCount);  //掴んでいるパネルの大きさ比較の対象

            picked_r = this.transform.localScale.x;
            compared_r = compared.transform.localScale.x;

            //Debug.Log(picked_r +","+ compared_r+","+ ParentStake+","+BackStake);

            other.GetComponent<Renderer>().material.color = new Color(1.0f, (120f / 255f), (160f / 255f), 1.0f);//赤

            //移動先の座標を検索（移動できないときは戻される）
            if (picked_r < compared_r)
            {
                movepos = compared.transform.localPosition + Vector3.up* compared.transform.localScale.y*2;
                ParentStake = GameObject.Find(GameObject.Find(other.name).transform.GetChild(0).name);
                //Debug.Log("置けます");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        other.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        ParentStake = BackStake;
        movepos = backpos;

        //Debug.Log(picked_r + "," + compared_r + "," + ParentStake + "," + BackStake);

    }

    //ポイント時に1回だけコールされる(ドラッグによって激しく動かすとポイントが外されたとみなされるので注意)
    public void PointerEnter()
    {
        if (execute)
        {
            Undo = GameObject.Find("Undo").GetComponent<Undo>();//ゲーム開始時に当該オブジェクトが存在しないため、ここでUndoを登録
            execute = false;
        }
        //if (this.tag != "picked")
        {
            pile = this.transform.parent.childCount - 1;
            if (this.transform.GetSiblingIndex() == pile && clear == false) 
            {
                this.GetComponent<Renderer>().material.color -= new Color(0, 0, 0, 0.5f);
            }
        }
    }

    //ポイント解除時に1回だけコールされる
    public void PointerExit()
    {
        //if (this.tag != "picked")
        {
            pile = this.transform.parent.childCount - 1;
            if (this.transform.GetSiblingIndex() == pile && clear == false)
            {
                this.GetComponent<Renderer>().material.color += new Color(0, 0, 0, 0.5f);
            }
        }
    }

    //ドラッグ開始時にコールされる（一度止めた後のドラッグ再開時にはコールされない）
    public void BeginDrag()
    {
        if (this.transform.GetSiblingIndex() == pile && clear == false)
        {
            Undo.picked = this.transform.position;//ドラッグされているパネルを登録（条件でmovedに代入）

            this.GetComponent<Rigidbody>().isKinematic = true;

            BackStake = this.transform.parent.gameObject;
            backpos = this.transform.localPosition;

            this.tag = "picked";
        }
    }

    //ドラッグしている間はコールされ続ける
    public void Drag()
    {
        if (this.transform.GetSiblingIndex() == pile && clear == false)
        {
            this.transform.position = pointing;
            this.transform.parent = GameObject.Find("Pointer").transform;
        }
    }

    //ドロップした時にコールされる
    public void Drop()
    {
        this.GetComponent<Rigidbody>().isKinematic = false;

        this.transform.parent = ParentStake.transform;
        this.transform.localPosition = movepos;
        this.tag = "Untagged";

        ls.GetComponent<Renderer>().sharedMaterial.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        cs.GetComponent<Renderer>().sharedMaterial.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        rs.GetComponent<Renderer>().sharedMaterial.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        //Debug.Log(Undo.picked);//変化後のポジションが返される
        //Debug.Log(this.transform.position);//変化後のポジションが返される

        if (Undo.picked != this.transform.position)
        {
            Undo.moved = this.gameObject;
            Undo.before = Undo.picked;
            Undo.after = this.transform.position;
            Undo.movecount++;
            Undo.counttmp0 = Undo.movecount;
            Undo.counttmp1 = Undo.movecount-1;
            GameObject.Find("MoveCount").GetComponent<Text>().text = "移動回数：" + Undo.movecount;
            if (GameObject.Find("Undo").GetComponent<Button>().interactable == false) 
            GameObject.Find("Undo").GetComponent<Button>().interactable = true;
            if (GameObject.Find("Reset").GetComponent<Button>().interactable == false)
                GameObject.Find("Reset").GetComponent<Button>().interactable = true;
            //Debug.Log("移動回数：" + Undo.movecount + "回");
        }

        //クリア時の処理をここに書く
        GameObject.Find("EventSystem").GetComponent<ClearEvent>().Clear();

    }
}
