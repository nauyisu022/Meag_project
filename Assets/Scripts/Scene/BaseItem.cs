using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneBaseItem : MonoBehaviour, IPointerClickHandler
{
    public bool isBagItem=false;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (isBagItem)
        {
            putIntoBag();
            Destroy(gameObject);
        }
        else
        {
            clickEvent();
        }
    }

    public void putIntoBag()
    {

    }

    public void clickEvent()
    {

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
