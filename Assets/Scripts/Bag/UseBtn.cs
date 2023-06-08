using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseBtn : MonoBehaviour
{
    public string itemTag;
    public GameObject obj;
    public void useFn()
    {
        ItemManager.Instance.closeDisplay();
        BaGuaController.Instance.itemClickFunc(itemTag, obj);
    }
}
