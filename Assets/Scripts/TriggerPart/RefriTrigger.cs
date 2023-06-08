using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefriTrigger : BagBaseItem
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
        _tag = "冰箱贴";
        _name = "冰箱贴";
        _description = "冰箱贴";
        checkText1 = "印着自然风光的冰箱贴。磁力减退了，很容易就能揭下来；照片模糊不堪，只能隐约看见一行文字。显然已经上了年头。";
        checkText2 = "坎（水），雅鲁藏布江，流动的水；“你心之所向”，向往；旅行纪念品。“即使冰箱贴上的文字和照片不再清晰，那一次旅行依然清楚地刻印在我的记忆里——雅鲁藏布江大峡谷，涌动的江水和壮美的峭壁，“你心之所向，皆为风景。”";
        image1 = Resources.Load<Sprite>("冰箱贴");
        image2 = Resources.Load<Sprite>("冰箱贴");
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
