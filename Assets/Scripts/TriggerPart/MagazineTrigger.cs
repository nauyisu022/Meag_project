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
        _tag = "���ҵ�����־";
        _name = "���ҵ�����־";
        _description = "���ҵ�����־";

        checkText1 = "һ���������õ���־��ֽ�ű�Ե���Ͼɶ����ơ�";
        checkText2 = "���ף�������������������ʾ��������ӡ����̵�һ�ڹ��ҵ����������׵��������Դ�ͳ��򣬶����·������������к���������һ���ص��ղأ��Լ��������������ҫ�۵����롣";
        image1 = Resources.Load<Sprite>("���ҵ�����־");
        image2 = Resources.Load<Sprite>("���ҵ�����־");
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
        //��õ����Ǻͻ�ɽ�ң�1-2
        if (ItemManager.Instance.objMap.ContainsKey("������") && ItemManager.Instance.objMap.ContainsKey("������"))
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
