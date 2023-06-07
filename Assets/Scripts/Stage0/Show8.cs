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
            text.GetComponent<Text>().text = "现在手头的东西还不够，或许等下再尝试更好。";
            Invoke("CloseText", 1.5f);
        }
        else if(SceneManager.Instance.play8Stage == false)
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = "乍然出现的、巨大的法阵，提醒我这个世界的规则已不同寻常。法阵上已经摆了三个物品。也许当我完成这个仪式时，会有奇妙的事情发生…";
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
