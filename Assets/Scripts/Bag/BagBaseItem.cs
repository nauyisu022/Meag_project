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
    // ���ݵ�ǰ����item����Ϣ��չʾ���в���չʾ��
    public void openItemUI()
    {
        ItemManager itemManager = ItemManager.Instance;
        itemManager.updateItemUI(gameObject, true, needScaleUp);
    }

    // ���ĵ�ǰ����item��Ϣ���������չʾ��ǰitem����ôͬ������չʾ������
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
