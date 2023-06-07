using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BagBaseItem : MonoBehaviour, IPointerClickHandler
{

    public string itemTag=null;
    public string itemName=null;
    [TextArea]
    public string itemDescription = null;
    public Sprite itemSprite = null;
    public GameObject manager = null;
    public void OnPointerClick(PointerEventData eventData)
    {
        invokeUI();

    }

    public void invokeUI()
    {
        ItemManager itemManager = manager.GetComponent<ItemManager>();
        itemManager.showUI(gameObject);
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
