using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneBagItem : SceneBaseItem
{
    // ��Ҫ��ǰ����Ԥ�Ƽ�����ֵ����������Ʒ��prefab����
    public GameObject prefab;
    // �Ƿ��������Ʒ������Ʒ
    public bool isGoalItem;
    // �ŵ�������ĺ���
    public void putIntoBag()
    {
        ItemManager itemManager = ItemManager.Instance;
        itemManager.putIntoBag(prefab, isGoalItem);
    }
    // ��Click����˳��
    public virtual void postHandle() {
        print("Not implemented");
    }
    public virtual void preHandle()
    {
        print("Not implemented");
    }
    public virtual void destroy()
    {
        Destroy(gameObject);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        preHandle();
        putIntoBag();
        postHandle();
        destroy();
    }
}
