using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Pointer : MonoBehaviour
{
    Vector3 scrpos;     //スクリーン上の座標を返す
    Vector3 worldpos;   //ゲーム内のワールド座標をを返す

    // Start is called before the first frame update
    void Start()
    {
        scrpos = Input.mousePosition;
        scrpos.z = -Camera.main.transform.position.z;
        worldpos = Camera.main.ScreenToWorldPoint(scrpos);
        worldpos.z = 0;

        this.transform.position = worldpos;
    }

    // Update is called once per frame
    void Update()
    {
        scrpos = Input.mousePosition;
        scrpos.z = -Camera.main.transform.position.z;
        worldpos = Camera.main.ScreenToWorldPoint(scrpos);
        worldpos.z = 0;

        this.transform.position = worldpos;

        /*
        if (Input.GetMouseButton(0))
        {
            Debug.Log(worldpos);
        }*/
    }
}
