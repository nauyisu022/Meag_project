using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneBagItem : SceneBaseItem
{
    // 需要提前制作预制件并赋值给场景中物品的prefab属性
    public GameObject prefab;
    // 是否是左边物品栏的物品
    public bool isGoalItem;
    // 放到背包里的函数
    public void putIntoBag()
    {
        ItemManager itemManager = ItemManager.Instance;
        itemManager.putIntoBag(prefab, isGoalItem);
    }
    // 见Click调用顺序
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
