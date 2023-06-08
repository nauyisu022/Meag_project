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
            text.GetComponent<Text>().text = "û�е��Ӳ�Ʒ�ĸ������Ż�ʹ�õ��ռǱ���ʮ��ǰ��С��������������Ŀ�ʽ�ˣ��򵥵����������ż򵥵����¡�";
            Invoke("CloseText", 1.5f);
        }
        else if (ItemManager.Instance.objMap.ContainsKey("������") && ItemManager.Instance.objMap.ContainsKey("������") && ItemManager.Instance.objMap.ContainsKey("���ҵ�����־") && ItemManager.Instance.objMap.ContainsKey("������"))
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = "Ҳ�����Ѿ�֪���˴���ʲô�� ";
            password = Instantiate(passwordBox);
            Invoke("CloseText", 1.5f);
        }
        else
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = "�������ڻ����ǳ��Ե�ʱ��";
            Invoke("CloseText", 1.5f);
        }
        count++;
        if(text.GetComponent<Text>().text == "Ҳ�����Ѿ�֪���˴���ʲô�� " && SceneManager.Instance.passwordIsCorrect == true)
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = "�����Ѿ�û��ʲô���Ի�����ˡ�";
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
