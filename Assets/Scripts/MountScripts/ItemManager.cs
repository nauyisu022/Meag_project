using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemManager: MonoBehaviour
{
    // ����ģʽ
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

    // ͨ��itemTagΨһ��ʾ��ӦObject��map
    public Dictionary<string, GameObject> objMap = new Dictionary<string, GameObject>();
    // �������Ķ�Ӧpanel
    public GameObject GoalGrid;
    public GameObject LoveGrid;
    // չʾ����
    public GameObject DisplayObject;
    // չʾ��ͼƬ
    public GameObject imagePanel;
    // չʾ����ͨ����
    public GameObject descriptionPanel;
    // չʾ��check����
    public GameObject checkText;
    public string curTag = null;

    // ����Ʒ��GameObjectʵ����������ƷGameObject��ͨ��tag�ŵ�objMap����׷��
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
    // ����չʾ�����洢����Ϣ��ͬʱ���ݱ���needDisplay�ж��Ƿ���Ҫ��ʾ��չʾ��
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
