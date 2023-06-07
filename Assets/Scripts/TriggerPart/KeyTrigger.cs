using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : BagBaseItem
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
        _tag = "钥匙扣";
        _name = "钥匙扣";
        _description = "钥匙扣";

        checkText1 = "记不清用途的钥匙。看起来很容易弄丢。钥匙扣是个平平无奇的旅游纪念品，上面似乎写有日期。";
        checkText2 = "钥匙：高中班级人手一把的钥匙，独立的置物柜是学生时代少有的隐私。钥匙扣：那年夏天，我第一次独自攀登XX山，看到的美景永生难忘。";
        image1 = Resources.Load<Sprite>("钥匙扣ai");
        image2 = Resources.Load<Sprite>("钥匙扣ai");
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
        //返回宿舍：1-2
        if (SceneManager.Instance.jumpToClassroom == true)
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
