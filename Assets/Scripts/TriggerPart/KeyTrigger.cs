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
        _tag = "Կ�׿�";
        _name = "Կ�׿�";
        _description = "Կ�׿�";

        checkText1 = "�ǲ�����;��Կ�ס�������������Ū����Կ�׿��Ǹ�ƽƽ��������μ���Ʒ�������ƺ�д�����ڡ�";
        checkText2 = "Կ�ף����а༶����һ�ѵ�Կ�ף��������������ѧ��ʱ�����е���˽��Կ�׿ۣ��������죬�ҵ�һ�ζ����ʵ�XXɽ����������������������";
        image1 = Resources.Load<Sprite>("Կ�׿�ai");
        image2 = Resources.Load<Sprite>("Կ�׿�ai");
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
        //�������᣺1-2
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
