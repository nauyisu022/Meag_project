using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneBaseItem : MonoBehaviour, IPointerClickHandler
{
    public string itemTag = null;
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        print("Not implemented");
    }
}
