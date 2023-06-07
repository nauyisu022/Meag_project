using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorCollider : SceneBaseItem
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        CameraManager.Instance.switchCamera("½ÌÊÒ¹ñ×ÓCamera");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
