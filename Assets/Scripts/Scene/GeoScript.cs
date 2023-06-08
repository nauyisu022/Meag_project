using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GeoScript : SceneBaseItem
{
    // Start is called before the first frame update
    public List<GameObject> prefabList = new List<GameObject>();
    private GameObject prefab;
    // �Ƿ��������Ʒ������Ʒ
    public bool isGoalItem;
    // �ŵ�������ĺ���
    public void putIntoBag()
    {
        ItemManager itemManager = ItemManager.Instance;
        itemManager.putIntoBag(prefab, isGoalItem);
    }
    // ��Click����˳��
    public virtual void postHandle()
    {
        print("Not implemented");
    }
    public virtual void preHandle()
    {
        prefab = prefabList[0];
        putIntoBag();
        prefab = prefabList[1];
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
