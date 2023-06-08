using UnityEngine;
using UnityEngine.EventSystems;

public class UIPassClick : MonoBehaviour, IPointerClickHandler
{
    //实现IPointerClickHandler接口的方法，当点击UI时触发
    public void OnPointerClick(PointerEventData eventData)
    {
        //判断是否需要穿透，这里可以根据自己的逻辑修改
        //if (NeedPassThrough(eventData))
        //{
        print("in test");
        //获取点击位置的UI元素
        GameObject uiObject = eventData.pointerCurrentRaycast.gameObject;
        //将事件传递给下一层UI
        ExecuteEvents.ExecuteHierarchy(uiObject, eventData, ExecuteEvents.pointerClickHandler);
        //}
    }

    ////判断是否需要穿透的方法，这里可以根据自己的逻辑修改
    //private bool NeedPassThrough(PointerEventData eventData)
    //{
    //    //获取点击位置是否在第一层UI上
    //    bool isOverFirstUI = EventSystem.current.IsPointerOverGameObject();
    //    //如果是在第一层UI上，则需要穿透
    //    if (isOverFirstUI)
    //    {
    //        return true;
    //    }
    //    return false;
    //}
}
