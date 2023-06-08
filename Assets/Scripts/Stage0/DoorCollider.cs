using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DoorCollider : SceneBaseItem
{
    public GameObject text;
    bool firstTime = true;
    public override void OnPointerClick(PointerEventData eventData)
    {

        //���Կ���ƺ����á����ɹ��򿪹��ӣ�
        if (ItemManager.Instance.objMap.ContainsKey("Կ�׿�"))
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = "���Կ���ƺ����á����ɹ��򿪹��ӣ�";
            Invoke("CloseText", 1.5f);
            Invoke("TurnStage", 2.0f);
        }

        //��Կ�׿׵����ƴ����������һģһ���Ĺ���֮һ������ı���������������������һ�㡣���ӱ�������ס�ˣ����ǲ�Ҫǿ���ƿ����ɡ�
        else
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = "��Կ�׿׵����ƴ����������һģһ���Ĺ���֮һ������ı���������������������һ�㡣���ӱ�������ס�ˣ����ǲ�Ҫǿ���ƿ����ɡ�";
            Invoke("CloseText", 1.5f);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TurnStage()
    {
        if(firstTime == true)
        {
            CameraManager.Instance.switchCamera("���ҹ���Camera");
            firstTime = false;
        }
            
    }
    void CloseText()
    {
        text.SetActive(false);
    }
}
