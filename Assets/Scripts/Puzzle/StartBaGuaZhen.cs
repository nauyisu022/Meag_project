using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBaGuaZhen : MonoBehaviour
{
    //PositionLoader���������
    public GameObject positionLoader;
    //������������
    public GameObject[] children;
    //ƴͼ��Ƭ��������
    public GameObject[] pieces;

    //��Ϸ�Ƿ�ɹ�
    public bool isSuccess;
    //��ǰѡ�е�ƴͼ��Ƭ����
    public GameObject selectedPiece;

    void Start()
    {
        Debug.Log("Start...");

        //��ʼ����Ϸ�Ƿ�ɹ�Ϊfalse
        isSuccess = false;
        //��ʼ����ǰѡ�е�ƴͼ��Ƭ����Ϊnull
        selectedPiece = null;

        //��ȡPositionLoader������������������
        positionLoader = GameObject.Find("������λ��ָʾ");
        //��ȡPositionLoader�����RectTransform���
        RectTransform rectTransform = positionLoader.GetComponent<RectTransform>();
        foreach (Transform child in positionLoader.transform)
        {
            Debug.Log(child.gameObject.name);
        }
        /*
        children = new GameObject[positionLoader.transform.childCount];
        Vector3 firstPosition = positionLoader.transform.GetChild(0).gameObject.transform.position; // ��ȡ��һ���������λ��
        for (int i = 0; i < children.Length; i++)
        {
            children[i] = positionLoader.transform.GetChild(i).gameObject;
            Vector3 currentPosition = children[i].transform.position; // ��ȡ��ǰ�������λ��
            if (!Vector3.Equals(currentPosition, firstPosition)) // �Ƚϵ�ǰλ�ú͵�һ��λ���Ƿ���ͬ
            {
                Debug.Log("Different position found: " + children[i].name); // �����ͬ�������ʾ��Ϣ
            }
        }*/
        Debug.Log(children.Length);
        //��ӡpositionLoader�����Ƿ�Ϊ��
        Debug.Log("positionLoader is null: " + (positionLoader == null));


        //��������ƴͼ��Ƭ�������������
        for (int i = 0; i < 9; i++)
        {
            //��ȡPiece�ű�
            Piece piece = pieces[i].GetComponent<Piece>();
            //����ƴͼ��Ƭ�����ڳ����е�λ�ã����õ�ǰλ������
            piece.currentPosition = pieces[i].transform.position;
            piece.initPosition = pieces[i].transform.position;

            //ͨ��positionLoader�����transform��������ȡ���ĵ�i���������λ��
            /*GameObject child = positionLoader.transform.GetChild(i).gameObject;
            //��ӡ�������Ƿ�Ϊ��
            Debug.Log("child is null: " + (child == null));*/
            /*Vector3 child_Position = positionLoader.transform.GetChild(i).transform.position;
            //����ê������ĵ��ƫ����
            child_Position -= new Vector3(rectTransform.rect.width * rectTransform.pivot.x, rectTransform.rect.height * rectTransform.pivot.y, 0);
            //��ӡ�������λ��
            Debug.Log(child_Position);*/

            //������ȷλ������
            piece.correctPosition = children[i].GetComponent<GridPosition>().targetPosition;

            //��ӡƴͼ��Ƭ�����ڳ����е�λ��
            Debug.Log("Current position of " + pieces[i].name + ": " + piece.currentPosition);
            //��ӡ��Ӧ������λ��
            Debug.Log("Correct position of " + pieces[i].name + ": " + piece.correctPosition);
        }

    }

    void Update()
    {
        //��������ƴͼ��Ƭ���壬������ǵ�Piece�ű��еĵ�ǰλ���Ƿ����ȷλ����ͬ���������ͬ�����ʾ��Ϸ�ɹ�����isSuccess��������Ϊtrue������ʾ��Ӧ����ʾ��Ϣ��
        CheckSuccess();

        //�����Ϸû�гɹ��������û��������¼���ʹ��Raycast��������������������û�������ĸ�ƴͼ��Ƭ���壬Ȼ����ѡ�в�������ʾ���ٴε��ʱ������û�������ĸ�����λ�ã�Ȼ��ѡ�е�ƴͼ��Ƭ�����ƶ�����λ�ã���������Piece�ű��еĵ�ǰλ����Ϣ������û�û�е���κ���Ч��λ�ã���ȡ��ѡ�в��ָ�ԭ����
        if (!isSuccess)
        {
            HandleInput();

        }
    }

    //�����Ϸ�Ƿ�ɹ��ķ���
    void CheckSuccess()
    {
        //��������ƴͼ��Ƭ����
        for (int i = 0; i < pieces.Length; i++)
        {
            //��ȡPiece�ű�
            Piece piece = pieces[i].GetComponent<Piece>();

            //�����һ��ƴͼ��Ƭ����ĵ�ǰλ�ú���ȷλ�ò�ͬ���򷵻�
            if (!piece.IsCorrect())
            {
                return;
            }
        }
        //�������ƴͼ��Ƭ����ĵ�ǰλ�ú���ȷλ�ö���ͬ�����ʾ��Ϸ�ɹ�
        isSuccess = true;
        SceneManager.Instance.puzzleIsCorrect = true;
        //��ʾ��ʾ��Ϣ
        Debug.Log("You win!");
    }

    //�����û������¼��ķ���
    void HandleInput()
    {
        //����û������������
        if (Input.GetMouseButtonDown(0))
        {
            //����һ�����ߣ�����������䵽���������Ļλ��
            Ray ray = GameObject.Find("ƴͼCamera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //��������������κ�����
            if (Physics.Raycast(ray, out hit))
            {
                //��ȡ��ײ����ı�ǩ
                string tag = hit.collider.gameObject.tag;
                //�����ײ������ƴͼ��Ƭ
                if (tag == "Piece")
                {
                    //�����ǰû��ѡ���κ�ƴͼ��Ƭ���壬����ײ������Ϊѡ�У���������ʾ
                    if (selectedPiece == null)
                    {
                        selectedPiece = hit.collider.gameObject;
                        selectedPiece.GetComponent<SpriteRenderer>().color = Color.yellow;
                    }
                    //���������ǰ�Ѿ�ѡ����һ��ƴͼ��Ƭ���壬����������ײ���岻��ͬһ������ȡ��ѡ�У����ָ�ԭ��
                    else if (selectedPiece != hit.collider.gameObject)
                    {
                        selectedPiece.GetComponent<SpriteRenderer>().color = Color.white;
                        selectedPiece = null;
                    }
                }
                //���������ײ����������λ��
                else if (tag == "Grid")
                {
                    //�����ǰ�Ѿ�ѡ����һ��ƴͼ��Ƭ���壬�����ƶ�����ײ�����λ�ã���������Piece�ű��еĵ�ǰλ����Ϣ��Ȼ��ȡ��ѡ�У����ָ�ԭ��
                    if (selectedPiece != null)
                    {
                        //��ȡ��ײ�����λ��
                        Vector3 gridPosition = hit.collider.gameObject.transform.position;
                        //��ѡ�е�ƴͼ��Ƭ��������z���ƶ�-0.1
                        gridPosition -= new Vector3(0, 0, 0.2f);
                        //�ƶ�ѡ�е�ƴͼ��Ƭ���嵽�µ�λ�� 
                        selectedPiece.transform.position = gridPosition;
                        selectedPiece.GetComponent<Piece>().currentPosition = selectedPiece.transform.position;
                        //��¼��ȷ��Ŀ��λ��
                        Vector3 ccPosition = selectedPiece.GetComponent<Piece>().currentPosition;
                        Debug.Log(ccPosition);
                        selectedPiece.GetComponent<SpriteRenderer>().color = Color.white;
                        selectedPiece = null;
                        //Debug.Log("��ײ��Current position of " + pieces[i].name + ": " + piece.currentPosition);
                    }
                }
            }
            //�����������û�������κ�����
            else
            {
                //�����ǰ�Ѿ�ѡ����һ��ƴͼ��Ƭ���壬��ȡ��ѡ�У����ָ�ԭ��
                if (selectedPiece != null)
                {
                    selectedPiece.GetComponent<SpriteRenderer>().color = Color.white;
                    selectedPiece = null;
                }
            }
        }
        CheckError();
    }

    //���ƴͼ�Ƿ����ķ���
    bool CheckError()
    {
        //��������ƴͼ��Ƭ����
        for (int i = 0; i < pieces.Length; i++)
        {
            //��ȡPiece�ű�
            Piece piece = pieces[i].GetComponent<Piece>();

            //�����һ��ƴͼ��Ƭ����ĵ�ǰλ�ú���ȷλ�ò�ͬ����������
            if (!piece.IsCorrect())
            {
                //����һ������������������¼�Ƿ�����ƴͼ��Ƭ���嶼�Ѿ����ƶ���������
                bool allOnGrid = true;
                //��������ƴͼ��Ƭ����
                for (int j = 0; j < pieces.Length; j++)
                {
                    //��ȡPiece�ű�
                    Piece piece2 = pieces[j].GetComponent<Piece>();
                    //�����һ��ƴͼ��Ƭ����ĵ�ǰλ�úͳ�ʼλ����ͬ�����ʾ����û�б��ƶ��������ϣ�������������Ϊfalse��������ѭ��
                    if (piece2.currentPosition == piece2.initPosition)
                    {
                        allOnGrid = false;
                        break;
                    }
                }
                //�������ƴͼ��Ƭ���嶼�Ѿ����ƶ��������ϣ����ʾƴͼ���������ʾ��Ϣ����������ƴͼ��Ƭ���廹ԭ����ʼλ�ã�����false
                if (allOnGrid)
                {
                    Debug.Log("ƴͼ����������ƴͼ��");
                    for (int k = 0; k < pieces.Length; k++)
                    {
                        //��ȡPiece�ű�
                        Piece piece3 = pieces[k].GetComponent<Piece>();
                        //��ƴͼ��Ƭ�����ƶ�����ʼλ�ã���������Piece�ű��еĵ�ǰλ����Ϣ
                        pieces[k].transform.position = piece3.initPosition;
                        piece3.currentPosition = piece3.initPosition;
                    }
                    return false;
                }
                //���򣬱�ʾƴͼ��û����ɣ�����false
                else
                {
                    return false;
                }
            }
        }
        //�������ƴͼ��Ƭ����ĵ�ǰλ�ú���ȷλ�ö���ͬ�����ʾƴͼ��ȷ������true
        return true;
    }
}
