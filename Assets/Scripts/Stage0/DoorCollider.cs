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

        //这把钥匙似乎正好…（成功打开柜子）
        if (ItemManager.Instance.objMap.ContainsKey("钥匙扣"))
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = "这把钥匙似乎正好…（成功打开柜子）";
            Invoke("CloseText", 1.5f);
            Invoke("TurnStage", 2.0f);
        }

        //带钥匙孔的铁制储物柜。无数个一模一样的柜子之一，上面的冰箱贴让它看起来特殊了一点。柜子被牢牢锁住了，还是不要强行破开它吧。
        else
        {
            text.SetActive(true);
            text.GetComponent<Text>().text = "带钥匙孔的铁制储物柜。无数个一模一样的柜子之一，上面的冰箱贴让它看起来特殊了一点。柜子被牢牢锁住了，还是不要强行破开它吧。";
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
            CameraManager.Instance.switchCamera("教室柜子Camera");
            firstTime = false;
        }
            
    }
    void CloseText()
    {
        text.SetActive(false);
    }
}
