using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupTrigger : BagBaseItem
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
        _tag = "杯子";
        _name = "杯子";
        _description = "杯子";

        checkText1 = "傻乎乎的情侣款马克杯，只有热恋中的人才会喜欢这种风格吧。杯底有一串意义不明的数字。";
        checkText2 = "如今只剩下一只的情侣款杯子。杯底当然是某人的生日。";
        image1 = Resources.Load<Sprite>("杯子");
        image2 = Resources.Load<Sprite>("杯子");
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
        //解开拼图：1-2
        if (SceneManager.Instance.puzzleIsCorrect == true)
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
