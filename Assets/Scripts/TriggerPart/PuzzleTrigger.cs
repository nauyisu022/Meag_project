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
        _tag = "ƴͼ";
        _name = "ƴͼ";
        _description = "ƴͼ";

        checkText1 = "����Ѿ����ټ�����ʽƴͼ����֪�����������Ĺ��¡�";
        checkText2 = "Ϊ����ף�������ǵļ����գ����ⶨ�Ƶ�ƴͼ��ר��ȥӰ¥������Ƭ��һ������ѡ�˺þá����滭�����ǵĹ��¡�";
        image1 = Resources.Load<Sprite>("����+ƴͼ");
        image2 = Resources.Load<Sprite>("ƴͼ��Ƭ/����ƴͼ");
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
        //�⿪ƴͼ��1-2
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
