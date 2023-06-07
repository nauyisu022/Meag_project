using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineTrigger : BagBaseItem
{
    bool stage1to2 = false;
    string _tag = null;
    string _name = null;
    string _description = null;
    string checkText1 = null;
    string checkText2 = null;
    Sprite image1 = null;
    Sprite image2 = null;
    int curState = 1;
    // Start is called before the first frame update
    void Awake()
    {
        Init();
        updateItemInfo(_tag,_name, _description, checkText1, image1, false);
    }
    void Init()
    {
        _tag = "国家地理杂志";
        _name = "国家地理杂志";
        _description = "国家地理杂志";

        checkText1 = "一本保存良好的杂志。纸张边缘因老旧而泛黄。";
        checkText2 = "震（雷），因其象征激动和启示。“令人印象深刻的一期国家地理，介绍了雷电现象的起源和成因，读来仿佛有雷声在心中轰鸣。将这一期特地收藏，以纪念曾经那闪电般耀眼的理想。";
        image1 = Resources.Load<Sprite>("国家地理杂志");
        image2 = Resources.Load<Sprite>("国家地理杂志");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeState();
    }
    public void ChangeState()
    {
        //获得地球仪和火山岩：1-2
        if (ItemManager.Instance.objMap.ContainsKey("地球仪") && ItemManager.Instance.objMap.ContainsKey("花岗岩"))
        {
            curState = 2;
            if (stage1to2 == false)
            {
                updateItemInfo(_tag, _name, _description, checkText2, image2, false);
                stage1to2 = true;
            }

        }

    }
}
