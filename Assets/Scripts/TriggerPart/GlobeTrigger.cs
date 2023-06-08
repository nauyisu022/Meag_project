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
        _tag = "������";
        _name = "������";
        _description = "������";
        checkText1 = "��֪��ʲôʱ����ĵ����ǣ������е�ռ�ط��ˡ�";
        checkText2 = "Сʱ��������һ��������ս�������ģ����º��ؼ�ʵ�Ĵ��ԭ������һ����Բ��������ʶ����ĵ�һ�������������ģ����";
        image1 = Resources.Load<Sprite>("������");
        image2 = Resources.Load<Sprite>("������");
    }
    // Update is called once per frame
    void Update()
    {
        ChangeState();
    }
    public void ChangeState()
    {
        //��õ����ǣ�1-2
        if (ItemManager.Instance.objMap.ContainsKey("������"))
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
