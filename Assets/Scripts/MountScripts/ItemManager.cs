using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager: MonoBehaviour
{
    public GameObject GoalGrid;
    public GameObject LoveGrid;
    public GameObject DisplayObject;
    public GameObject imagePanel;
    public GameObject descriptionPanel;


    public Dictionary<string, int> itemStateMap=new Dictionary<string, int>();

    public void putIntoBag(GameObject prefab, bool isGoalItem)
    {
        if (isGoalItem)
        {
            GameObject obj = Instantiate(prefab, GoalGrid.transform);
            obj.GetComponent<BagBaseItem>().manager = gameObject;
        }
        else
        {
            Instantiate(prefab, LoveGrid.transform);
        }
    }

    public void showUI(GameObject item)
    {
        BagBaseItem bagBaseItem = item.GetComponent<BagBaseItem>();
        string itemName = bagBaseItem.itemName;
        string itemDescription = bagBaseItem.itemDescription;
        Sprite itemSprite = bagBaseItem.itemSprite;
        DisplayObject.SetActive(true);
        imagePanel.GetComponent<Image>().sprite = itemSprite;
        descriptionPanel.GetComponent<Text>().text= itemDescription;
    }
}
