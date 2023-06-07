using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Show8 : SceneBaseItem
{
    //int count = 0;
    public GameObject text;
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (SceneManager.Instance.jumpToClassroom == false && SceneManager.Instance.play8Stage == false)
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = "������ͷ�Ķ�������������������ٳ��Ը��á�";
            Invoke("CloseText", 1.5f);
        }
        else if(SceneManager.Instance.play8Stage == false)
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = "էȻ���ֵġ��޴�ķ����������������Ĺ����Ѳ�ͬѰ�����������Ѿ�����������Ʒ��Ҳ������������ʽʱ��������������鷢����";
            Invoke("CloseText", 1.5f);
        }
        //count++;
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
    void CloseText()
    {
        text.SetActive(false);
    }
}
