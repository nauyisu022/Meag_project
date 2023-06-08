using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BagBaseItem : MonoBehaviour, IPointerClickHandler
{

    public string itemTag=null;
    public string itemName=null;
    [TextArea]
    public string itemDescription = null;
    [TextArea]
    public string itemCheckText = null;
    public Sprite itemSprite = null;
    public bool needScaleUp=false;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!SceneManager.Instance.in8Stage)
        {
            preHandle();
            openItemUI();
            postHandle();
        }
        else
        {

        }
        
    }
    // 传递当前背包item的信息到展示栏中并打开展示栏
    public void openItemUI()
    {
        ItemManager itemManager = ItemManager.Instance;
        itemManager.updateItemUI(gameObject, true, needScaleUp);
    }

    // 更改当前背包item信息，如果正在展示当前item，那么同步更改展示栏内容
    public void updateItemInfo(string tag = null, string name=null, string description=null, string checkText=null, Sprite sprite=null, bool firstTime = false)
    {
        if (tag != null)
        {
            itemTag = tag;
        }
        if (name != null)
        {
            itemName = name;
        }
        if (description != null)
        {
            itemDescription = description;
        }
        if (checkText != null)
        {
            itemCheckText = checkText;
        }
        if (sprite != null)
        {
            itemSprite = sprite;
        }
        ItemManager itemManager = ItemManager.Instance;
        if (firstTime) itemManager.updateItemUI(gameObject, true, needScaleUp);
        else itemManager.updateItemUI(gameObject, false, needScaleUp);
        
    }

    public virtual void destroy()
    {
        print("Not implemented");
    }

    public virtual void preHandle() {
        print("Not implemented");
    }
    public virtual void postHandle() {
        print("Not implemented");
    }
}
