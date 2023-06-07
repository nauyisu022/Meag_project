using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemManager: MonoBehaviour
{
    // 单例模式
    public static ItemManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 通过itemTag唯一表示对应Object的map
    public Dictionary<string, GameObject> objMap = new Dictionary<string, GameObject>();
    // 背包栏的对应panel
    public GameObject GoalGrid;
    public GameObject LoveGrid;
    // 展示框框架
    public GameObject DisplayObject;
    // 展示框图片
    public GameObject imagePanel;
    // 展示框普通表述
    public GameObject descriptionPanel;
    // 展示框check描述
    public GameObject checkText;
    public string curTag = null;

    // 以物品栏GameObject实例化背包物品GameObject并通过tag放到objMap进行追踪
    public void putIntoBag(GameObject prefab, bool isGoalItem)
    {
        GameObject obj = null;
        if (isGoalItem)
        {
            obj = Instantiate(prefab, GoalGrid.transform);
        }
        else
        {
            obj = Instantiate(prefab, LoveGrid.transform);
        }
        objMap.Add(prefab.GetComponent<BagBaseItem>().itemTag, obj);
    }
    // 更新展示栏所存储的信息，同时根据变量needDisplay判断是否需要显示出展示栏
    public void updateItemUI(GameObject item, bool needDisplay)
    {
        BagBaseItem bagBaseItem = item.GetComponent<BagBaseItem>();
        string itemTag = bagBaseItem.itemTag;
        if(needDisplay)
        {
            DisplayObject.SetActive(true);
        }
        else
        {
            if (curTag != null && itemTag != curTag)
            {
                return;
            }

        }
        curTag = itemTag;
        string itemName = bagBaseItem.itemName;
        string itemDescription = bagBaseItem.itemDescription;
        string itemCheckText = bagBaseItem.itemCheckText;
        Sprite itemSprite = bagBaseItem.itemSprite;
        imagePanel.GetComponent<Image>().sprite = itemSprite;
        descriptionPanel.GetComponent<Text>().text = itemDescription;
        checkText.GetComponent<Text>().text = itemCheckText;
    }

}
