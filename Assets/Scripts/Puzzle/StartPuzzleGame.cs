using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPuzzleGame : MonoBehaviour
{
    //ƴͼ��Ƭ�����Ԥ�����ģ��
    public GameObject piecePrefab;
    //ƴͼͼƬ�ز�
    public Texture2D[] puzzleTexture;
    //ƴͼ�ɹ�ʱ����ʾ��Ϣ
    public string successMessage = "You win!";
    //ƴͼ�ɹ�ʱ�Ƿ���ʾԭͼ
    public bool showOriginal = false;

    //PuzzleManager���������
    private GameObject puzzleManager;
    //Grid Lay Out���������
    private GridLayoutGroup gridLayoutGroup;
    //�����С
    private int gridSize;
    //������
    private Vector2 gridSpacing;
    //����ԭ��λ��
    private Vector2 gridOrigin;
    //ƴͼ��Ƭ��������
    public GameObject[] pieces;
    //ƴͼ��Ƭ����Ĵ�С
    private Vector2 pieceSize;
    //ƴͼ��Ƭ�����ƽ��
    private Plane piecePlane;
    //��ǰѡ�е�ƴͼ��Ƭ����
    private GameObject selectedPiece;
    //��ǰѡ�е�ƴͼ��Ƭ�����ԭʼ��ɫ
    private Color selectedPieceColor;
    //ѡ��ƴͼ��Ƭ����ʱ�ĸ�����ɫ
    public Color highlightColor = Color.yellow;
    //��Ϸ�Ƿ�ɹ��ı�־
    private bool isSuccess = false;


    void Start()
    {
        //��ȡPuzzleManager��������ã�����ȡ��Grid Lay Out��������������Ϣ�����������С�������λ�õȡ�
        puzzleManager = GameObject.Find("PuzzleManager");
        gridLayoutGroup = puzzleManager.GetComponent<GridLayoutGroup>();
        gridSize = gridLayoutGroup.transform.childCount;
        gridSpacing = gridLayoutGroup.spacing;
        gridOrigin = gridLayoutGroup.transform.GetChild(0).position;

        //��ȡ�Ѿ����ڵ�9��ƴͼ��Ƭ����
        pieces = new GameObject[9];
        for (int i = 0; i < 9; i++)
        {
            pieces[i] = transform.GetChild(i).gameObject;
        }
    
/*
    //ʹ��Instantiate������GameObject.CreatePrimitive��������PuzzleManager�����ͬһƽ���ڴ����Ÿ�ƽ�����壬��Ϊƴͼ��Ƭ��Ϊÿ���������Mesh Renderer����������������Ϊ���Լ���ͼƬ�زġ�Ϊÿ���������Box Collider��������������С�������С��ͬ��Ϊÿ���������һ���Զ����Piece�ű��������洢����ȷ��λ�ú͵�ǰ��λ�á�
    pieces = new GameObject[gridSize];
    pieceSize = new Vector2(gridSpacing.x, gridSpacing.y);
    piecePlane = new Plane(Vector3.back, puzzleManager.transform.position);
        for (int i = 0; i<gridSize; i++)
        {
            pieces[i] = Instantiate(piecePrefab, transform);
            pieces[i].name = "Piece" + i;
            pieces[i].transform.position = puzzleManager.transform.GetChild(i).position;
            pieces[i].transform.localScale = new Vector3(pieceSize.x, pieceSize.y, 1f);
            // Ϊÿ���������һ��MeshRenderer���
            pieces[i].AddComponent<MeshRenderer>();
            MeshRenderer meshRenderer = pieces[i].GetComponent<MeshRenderer>();
            // �޸�MeshRenderer���������Ӧ��ͼƬ�ӵ�Piece��
            meshRenderer.material.mainTexture = puzzleTexture[i];
            meshRenderer.material.mainTextureScale = new Vector2(1f / Mathf.Sqrt(gridSize), 1f / Mathf.Sqrt(gridSize));
            meshRenderer.material.mainTextureOffset = new Vector2(i % Mathf.Sqrt(gridSize) / Mathf.Sqrt(gridSize), 1f - (i / Mathf.Sqrt(gridSize) + 1) / Mathf.Sqrt(gridSize));
            BoxCollider boxCollider = pieces[i].AddComponent<BoxCollider>();
            boxCollider.size = new Vector3(pieceSize.x, pieceSize.y, 0.1f);
            // Ϊÿ���������һ��Piece�������������ȷλ�ú͵�ǰλ��
            Piece pieceScript = pieces[i].AddComponent<Piece>();
            pieceScript.correctPosition = pieces[i].transform.position;
            pieceScript.currentPosition = pieces[i].transform.position;
        }
*/
      //ʹ��Random.Range��������������㷨������ƴͼ��Ƭ��λ�ã��������Ƿ�����PuzzleManager����������ϡ�
      //ע�ⲻҪ��������Ƭ�ص���ͬһ��λ�á�
      //ShufflePieces();
    }

    /*
    void Update()
    {
        //��������ƴͼ��Ƭ���壬������ǵ�Piece�ű��еĵ�ǰλ���Ƿ����ȷλ����ͬ���������ͬ�����ʾ��Ϸ�ɹ�����isSuccess��������Ϊtrue������ʾ��Ӧ����ʾ��Ϣ��
        CheckSuccess();

        //�����Ϸ�ɹ�������������ʾԭͼ��������ƴͼ��Ƭ�������ɫ��Ϊ͸�����Ա㿴������ͼ��
        if (isSuccess && showOriginal)
        {
           ShowOriginal();
        }

        //�����Ϸû�гɹ��������û��������¼���ʹ��Raycast��������������������û�������ĸ�ƴͼ��Ƭ���壬Ȼ����ѡ�в�������ʾ���ٴε��ʱ������û�������ĸ�����λ�ã�Ȼ��ѡ�е�ƴͼ��Ƭ�����ƶ�����λ�ã���������Piece�ű��еĵ�ǰλ����Ϣ������û�û�е���κ���Ч��λ�ã���ȡ��ѡ�в��ָ�ԭ����
        if (!isSuccess)
        {
            HandleInput();
        }
    }*/

    //����ƴͼ��Ƭ��λ�õķ���
    void ShufflePieces()
    {
        for (int i = 0; i < gridSize; i++)
        {
            int randomIndex = Random.Range(0, gridSize);
            Vector3 tempPosition = pieces[i].transform.position;
            pieces[i].transform.position = pieces[randomIndex].transform.position;
            pieces[randomIndex].transform.position = tempPosition;
            pieces[i].GetComponent<Piece>().currentPosition = pieces[i].transform.position;
            pieces[randomIndex].GetComponent<Piece>().currentPosition = pieces[randomIndex].transform.position;
        }
    }

    //�����Ϸ�Ƿ�ɹ��ķ���
    void CheckSuccess()
    {
        int count = 0;
        for (int i = 0; i < gridSize; i++)
        {
            if (pieces[i].GetComponent<Piece>().IsCorrect())
            {
                count++;
            }
        }
        if (count == gridSize)
        {
            isSuccess = true;
            // Debug.Log(successMessage);
        }
    }

    //��ʾԭͼ�ķ���
    void ShowOriginal()
    {
        for (int i = 0; i < gridSize; i++)
        {
            pieces[i].GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 0f);
        }
    }

    //�����û�����ķ���
    void HandleInput()
    {
        //����û�����������
        if (Input.GetMouseButtonDown(0))
        {
            //����һ��������������λ�õ�����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //������߻�����ĳ��ƴͼ��Ƭ����
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("Piece"))
            {
                //���û��ѡ���κ�ƴͼ��Ƭ���壬��ѡ�е�ǰ���е����壬����¼��ԭʼ��ɫ��Ȼ������ɫ��Ϊ������ɫ
                if (selectedPiece == null)
                {
                    selectedPiece = hit.collider.gameObject;
                    selectedPieceColor = selectedPiece.GetComponent<MeshRenderer>().material.color;
                    selectedPiece.GetComponent<MeshRenderer>().material.color = highlightColor;
                }
                //����Ѿ�ѡ����ĳ��ƴͼ��Ƭ���壬��ȡ��ѡ�У���������ɫ�ָ�Ϊԭʼ��ɫ
                else
                {
                    selectedPiece.GetComponent<MeshRenderer>().material.color = selectedPieceColor;
                    selectedPiece = null;
                }
            }
            //�������û�л����κ�ƴͼ��Ƭ���壬������ѡ��ĳ��ƴͼ��Ƭ����
            else if (selectedPiece != null)
            {
                //�������ߺ�ƴͼ��Ƭ��������ƽ��Ľ���
                float enter;
                piecePlane.Raycast(ray, out enter);
                Vector3 hitPoint = ray.GetPoint(enter);

                //������������λ�ã��ҵ����뽻�������һ���������������
                float minDistance = float.MaxValue;
                Vector3 nearestGrid = Vector3.zero;
                for (int i = 0; i < gridSize; i++)
                {
                    float distance = Vector3.Distance(hitPoint, puzzleManager.transform.GetChild(i).position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestGrid = puzzleManager.transform.GetChild(i).position;
                    }
                }

                //�������С��һ����ֵ����ѡ�е�ƴͼ��Ƭ�����ƶ���������λ�ã���������Piece�ű��еĵ�ǰλ����Ϣ
                if (minDistance < pieceSize.x / 2f)
                {
                    selectedPiece.transform.position = nearestGrid;
                    selectedPiece.GetComponent<Piece>().currentPosition = nearestGrid;
                }

                //ȡ��ѡ�У���������ɫ�ָ�Ϊԭʼ��ɫ
                selectedPiece.GetComponent<MeshRenderer>().material.color = selectedPieceColor;
                selectedPiece = null;
            }
        }
    }
}