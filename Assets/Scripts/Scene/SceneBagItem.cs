using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneBagItem : SceneBaseItem
{
    public GameObject prefab;
    public bool isGoalItem;

    public void putIntoBag()
    {
        ItemManager itemManager = ItemManager.Instance;
        itemManager.putIntoBag(prefab, isGoalItem);
    }

    public virtual void postHandle() {
        print("Not implemented");
    }
    public virtual void preHandle()
    {
        print("Not implemented");
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        preHandle();
        putIntoBag();
        postHandle();
        Destroy(gameObject);
    }
}
