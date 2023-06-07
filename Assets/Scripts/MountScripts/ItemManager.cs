using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemManager: MonoBehaviour
{

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

    public Dictionary<string, GameObject> objMap = new Dictionary<string, GameObject>();
    public GameObject GoalGrid;
    public GameObject LoveGrid;
    public GameObject DisplayObject;
    public GameObject imagePanel;
    public GameObject descriptionPanel;
    public GameObject checkText;

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
    public void updateItemUI(GameObject item, bool needDisplay)
    {
        DisplayObject.SetActive(true);
        BagBaseItem bagBaseItem = item.GetComponent<BagBaseItem>();
        string itemName = bagBaseItem.itemName;
        string itemDescription = bagBaseItem.itemDescription;
        string itemCheckText = bagBaseItem.itemCheckText;
        Sprite itemSprite = bagBaseItem.itemSprite;
        imagePanel.GetComponent<Image>().sprite = itemSprite;
        descriptionPanel.GetComponent<Text>().text = itemDescription;
        checkText.GetComponent<Text>().text = itemCheckText;
    }

}
