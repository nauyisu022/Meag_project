using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterTrigger : BagBaseItem
{
    string _tag = null;
    string _name = null;
    string _description = null;
    string checkText1 = null;
    string checkText2 = null;
    Sprite image1 = null;
    Sprite image2 = null;
    void Awake()
    {
        Init();
        updateItemInfo(_tag, _name, _description, checkText1, image1, false);   // �����ǲ���Ҫ���µ�UI�Ǳߵģ���Ϊ��û����UI��ʾ
    }
    void Init()
    {
        _tag = "��д��";
        _name = "��д��";
        _description = "��д��";

        checkText1 = "һ���ƾɵ��ţ��ƺ��Ѿ������������µĳ���֮�С�";
        checkText2 = "Ŷ�����������շ��ֺ�д���ҵ�����ף���ţ���������һ��ף��������һ������ֱǰ��ŵ�ԣ�һ�����Ǹ���Ϊս��׷������δ������������������һ�ִ���İ���һ�ּ�ʹ���ǲ�����һ�𣬵�����Ȼϣ�����ܱ����Ȱ���������ң��������δ�����ܵİ������еĻ���ӿ����ͷ......";
        image1 = Resources.Load<Sprite>("��д��");
        image2 = Resources.Load<Sprite>("��д��");
        needScaleUp= true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
