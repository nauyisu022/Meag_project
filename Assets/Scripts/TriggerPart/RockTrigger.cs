using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrigger : BagBaseItem
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
        updateItemInfo(_tag, _name, _description, checkText1, image1, false);
    }
    void Init()
    {
        _tag = "花岗岩";
        _name = "花岗岩";
        _description = "花岗岩";
        checkText1 = "一块普通的石头，颜色怪怪的，看不出有什么特别之处。";
        checkText2 = "火山爆发后，沸腾的岩浆凝结而成的多孔形石材。一动不动的石头竟有着滚烫的过去。";
        image1 = Resources.Load<Sprite>("花岗岩ai 1");
        image2 = Resources.Load<Sprite>("花岗岩ai 1");
    }
    // Update is called once per frame
    void Update()
    {
        ChangeState();
    }
    public void ChangeState()
    {
        //获得地球仪：1-2
        if(ItemManager.Instance.objMap.ContainsKey("地球仪"))
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
