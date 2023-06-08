using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GeoScript : SceneBaseItem
{
    // Start is called before the first frame update
    public List<GameObject> prefabList = new List<GameObject>();
    private GameObject prefab;
    // 是否是左边物品栏的物品
    public bool isGoalItem;
    // 放到背包里的函数
    public void putIntoBag()
    {
        ItemManager itemManager = ItemManager.Instance;
        itemManager.putIntoBag(prefab, isGoalItem);
    }
    // 见Click调用顺序
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
