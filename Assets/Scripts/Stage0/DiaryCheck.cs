using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DiaryCheck : SceneBaseItem
{
    int count = 0;
    public GameObject passwordBox;
    GameObject password;
    public GameObject text;
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (count == 0)
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = "没有电子产品的高中生才会使用的日记本，十年前的小卖部里就有这样的款式了，简单的密码锁藏着简单的心事。";
            Invoke("CloseText", 1.5f);
        }
        else if (ItemManager.Instance.objMap.ContainsKey("花岗岩") && ItemManager.Instance.objMap.ContainsKey("地球仪") && ItemManager.Instance.objMap.ContainsKey("国家地理杂志") && ItemManager.Instance.objMap.ContainsKey("冰箱贴"))
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = "也许我已经知道了答案是什么… ";
            password = Instantiate(passwordBox);
            Invoke("CloseText", 1.5f);
        }
        else
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = "不，现在还不是尝试的时候。";
            Invoke("CloseText", 1.5f);
        }
        count++;
        if(text.GetComponent<Text>().text == "也许我已经知道了答案是什么… " && SceneManager.Instance.passwordIsCorrect == true)
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = "这里已经没有什么可以回忆的了。";
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
    void CloseText()
    {
        text.SetActive(false);
    }
    
}
