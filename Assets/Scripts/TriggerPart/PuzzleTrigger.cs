using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : BagBaseItem
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
        _tag = "拼图";
        _name = "拼图";
        _description = "拼图";

        checkText1 = "如今已经很少见的老式拼图，不知道画着怎样的故事。";
        checkText2 = "为了庆祝属于我们的纪念日，特意定制的拼图。专门去影楼拍了照片，一起精心挑选了好久。上面画着我们的故事。";
        image1 = Resources.Load<Sprite>("柜子+拼图");
        image2 = Resources.Load<Sprite>("拼图碎片/完整拼图");
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
