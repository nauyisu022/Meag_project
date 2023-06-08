using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeTrigger : BagBaseItem
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
        _tag = "地球仪";
        _name = "地球仪";
        _description = "地球仪";
        checkText1 = "不知道什么时候买的地球仪，多少有点占地方了。";
        checkText2 = "小时候在听完一场地理科普讲座后买的，脚下厚重坚实的大地原来竟是一个滚圆的星球。认识世界的第一步，梦想最初的模样。";
        image1 = Resources.Load<Sprite>("地球仪");
        image2 = Resources.Load<Sprite>("地球仪");
    }
    // Update is called once per frame
    void Update()
    {
        ChangeState();
    }
    public void ChangeState()
    {
        //获得地球仪：1-2
        if (ItemManager.Instance.objMap.ContainsKey("花岗岩"))
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
