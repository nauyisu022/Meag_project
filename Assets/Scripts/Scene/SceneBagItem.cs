using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBagItem : SceneBaseItem
{
    public string itemTag = null;
    public GameObject prefab;
    public bool isGoalItem;
    public GameObject manager = null;
        
    public override void putIntoBag()
    {
        ItemManager itemManager = manager.GetComponent<ItemManager>();
        itemManager.putIntoBag(prefab, true);
    }


    void Start()
    {
        isBagItem = true;
    }

    void Update()
    {
    }
}
