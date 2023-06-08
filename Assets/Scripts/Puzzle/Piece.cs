using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    // ƴͼ��Ƭ��
    public Vector3 initPosition; // ��¼ƴͼ�ĳ�ʼλ��
    public Vector3 correctPosition; // ��¼ƴͼ����ȷλ��
    public Vector3 currentPosition; // ��¼ƴͼ�ĵ�ǰλ��

    // ����һ����ֵ
    float threshold = 0.3f;

    public bool IsCorrect()
    {
        // ������ȷλ�ú͵�ǰλ��֮��ľ���
        float distance = Vector3.Distance(correctPosition, currentPosition);
        // �������С�ڻ������ֵ������true�����򷵻�false
        return distance <= threshold;
    }
}
