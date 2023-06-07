using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorOp : SceneBaseItem
{
    public GameObject door;
    public override void OnPointerClick(PointerEventData eventData)
    {
        door.SetActive(true);
        Destroy(door.GetComponent<BoxCollider>());
    }
}
