using UnityEngine;
using UnityEngine.EventSystems;

public class UIPassClick : MonoBehaviour, IPointerClickHandler
{
    //ʵ��IPointerClickHandler�ӿڵķ����������UIʱ����
    public void OnPointerClick(PointerEventData eventData)
    {
        //�ж��Ƿ���Ҫ��͸��������Ը����Լ����߼��޸�
        //if (NeedPassThrough(eventData))
        //{
        print("in test");
        //��ȡ���λ�õ�UIԪ��
        GameObject uiObject = eventData.pointerCurrentRaycast.gameObject;
        //���¼����ݸ���һ��UI
        ExecuteEvents.ExecuteHierarchy(uiObject, eventData, ExecuteEvents.pointerClickHandler);
        //}
    }

    ////�ж��Ƿ���Ҫ��͸�ķ�����������Ը����Լ����߼��޸�
    //private bool NeedPassThrough(PointerEventData eventData)
    //{
    //    //��ȡ���λ���Ƿ��ڵ�һ��UI��
    //    bool isOverFirstUI = EventSystem.current.IsPointerOverGameObject();
    //    //������ڵ�һ��UI�ϣ�����Ҫ��͸
    //    if (isOverFirstUI)
    //    {
    //        return true;
    //    }
    //    return false;
    //}
}
