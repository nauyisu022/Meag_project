using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    // ƴͼ��Ƭ��
    public Vector3 correctPosition; // ��¼ƴͼ����ȷλ��
    public Vector3 currentPosition; // ��¼ƴͼ�ĵ�ǰλ��

    public bool IsCorrect()
    {
        return correctPosition == currentPosition;
    }
}
