using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPuzzleGame : MonoBehaviour
{
    //拼图碎片物体的预制体或模板
    public GameObject piecePrefab;
    //拼图图片素材
    public Texture2D[] puzzleTexture;
    //拼图成功时的提示信息
    public string successMessage = "You win!";
    //拼图成功时是否显示原图
    public bool showOriginal = false;

    //PuzzleManager对象的引用
    private GameObject puzzleManager;
    //Grid Lay Out组件的引用
    private GridLayoutGroup gridLayoutGroup;
    //网格大小
    private int gridSize;
    //网格间隔
    private Vector2 gridSpacing;
    //网格原点位置
    private Vector2 gridOrigin;
    //拼图碎片物体数组
    public GameObject[] pieces;
    //拼图碎片物体的大小
    private Vector2 pieceSize;
    //拼图碎片物体的平面
    private Plane piecePlane;
    //当前选中的拼图碎片物体
    private GameObject selectedPiece;
    //当前选中的拼图碎片物体的原始颜色
    private Color selectedPieceColor;
    //选中拼图碎片物体时的高亮颜色
    public Color highlightColor = Color.yellow;
    //游戏是否成功的标志
    private bool isSuccess = false;


    void Start()
    {
        //获取PuzzleManager对象的引用，并获取其Grid Lay Out组件和子物体的信息，例如网格大小、间隔、位置等。
        puzzleManager = GameObject.Find("PuzzleManager");
        gridLayoutGroup = puzzleManager.GetComponent<GridLayoutGroup>();
        gridSize = gridLayoutGroup.transform.childCount;
        gridSpacing = gridLayoutGroup.spacing;
        gridOrigin = gridLayoutGroup.transform.GetChild(0).position;

        //获取已经存在的9个拼图碎片物体
        pieces = new GameObject[9];
        for (int i = 0; i < 9; i++)
        {
            pieces[i] = transform.GetChild(i).gameObject;
        }
    
/*
    //使用Instantiate函数或GameObject.CreatePrimitive函数，在PuzzleManager对象的同一平面内创建九个平面物体，作为拼图碎片。为每个物体添加Mesh Renderer组件，并设置其材质为你自己的图片素材。为每个物体添加Box Collider组件，并设置其大小和网格大小相同。为每个物体添加一个自定义的Piece脚本，用来存储其正确的位置和当前的位置。
    pieces = new GameObject[gridSize];
    pieceSize = new Vector2(gridSpacing.x, gridSpacing.y);
    piecePlane = new Plane(Vector3.back, puzzleManager.transform.position);
        for (int i = 0; i<gridSize; i++)
        {
            pieces[i] = Instantiate(piecePrefab, transform);
            pieces[i].name = "Piece" + i;
            pieces[i].transform.position = puzzleManager.transform.GetChild(i).position;
            pieces[i].transform.localScale = new Vector3(pieceSize.x, pieceSize.y, 1f);
            // 为每个物体添加一个MeshRenderer组件
            pieces[i].AddComponent<MeshRenderer>();
            MeshRenderer meshRenderer = pieces[i].GetComponent<MeshRenderer>();
            // 修改MeshRenderer组件，将对应的图片加到Piece上
            meshRenderer.material.mainTexture = puzzleTexture[i];
            meshRenderer.material.mainTextureScale = new Vector2(1f / Mathf.Sqrt(gridSize), 1f / Mathf.Sqrt(gridSize));
            meshRenderer.material.mainTextureOffset = new Vector2(i % Mathf.Sqrt(gridSize) / Mathf.Sqrt(gridSize), 1f - (i / Mathf.Sqrt(gridSize) + 1) / Mathf.Sqrt(gridSize));
            BoxCollider boxCollider = pieces[i].AddComponent<BoxCollider>();
            boxCollider.size = new Vector3(pieceSize.x, pieceSize.y, 0.1f);
            // 为每个物体添加一个Piece组件，设置其正确位置和当前位置
            Piece pieceScript = pieces[i].AddComponent<Piece>();
            pieceScript.correctPosition = pieces[i].transform.position;
            pieceScript.currentPosition = pieces[i].transform.position;
        }
*/
      //使用Random.Range函数或其他随机算法，打乱拼图碎片的位置，并将它们放置在PuzzleManager对象的网格上。
      //注意不要让两个碎片重叠在同一个位置。
      //ShufflePieces();
    }

    /*
    void Update()
    {
        //遍历所有拼图碎片物体，检查它们的Piece脚本中的当前位置是否和正确位置相同。如果都相同，则表示游戏成功，将isSuccess变量设置为true，并显示相应的提示信息。
        CheckSuccess();

        //如果游戏成功，且设置了显示原图，则将所有拼图碎片物体的颜色设为透明，以便看到背景图。
        if (isSuccess && showOriginal)
        {
           ShowOriginal();
        }

        //如果游戏没有成功，则处理用户的输入事件。使用Raycast函数或其他方法，检测用户点击了哪个拼图碎片物体，然后将其选中并高亮显示。再次点击时，检测用户点击了哪个网格位置，然后将选中的拼图碎片物体移动到该位置，并更新其Piece脚本中的当前位置信息。如果用户没有点击任何有效的位置，则取消选中并恢复原样。
        if (!isSuccess)
        {
            HandleInput();
        }
    }*/

    //打乱拼图碎片的位置的方法
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

    //检查游戏是否成功的方法
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

    //显示原图的方法
    void ShowOriginal()
    {
        for (int i = 0; i < gridSize; i++)
        {
            pieces[i].GetComponent<MeshRenderer>().material.color = new Color(1f, 1f, 1f, 0f);
        }
    }

    //处理用户输入的方法
    void HandleInput()
    {
        //如果用户按下鼠标左键
        if (Input.GetMouseButtonDown(0))
        {
            //发射一条从摄像机到鼠标位置的射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //如果射线击中了某个拼图碎片物体
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("Piece"))
            {
                //如果没有选中任何拼图碎片物体，则选中当前击中的物体，并记录其原始颜色，然后将其颜色设为高亮颜色
                if (selectedPiece == null)
                {
                    selectedPiece = hit.collider.gameObject;
                    selectedPieceColor = selectedPiece.GetComponent<MeshRenderer>().material.color;
                    selectedPiece.GetComponent<MeshRenderer>().material.color = highlightColor;
                }
                //如果已经选中了某个拼图碎片物体，则取消选中，并将其颜色恢复为原始颜色
                else
                {
                    selectedPiece.GetComponent<MeshRenderer>().material.color = selectedPieceColor;
                    selectedPiece = null;
                }
            }
            //如果射线没有击中任何拼图碎片物体，但是有选中某个拼图碎片物体
            else if (selectedPiece != null)
            {
                //计算射线和拼图碎片物体所在平面的交点
                float enter;
                piecePlane.Raycast(ray, out enter);
                Vector3 hitPoint = ray.GetPoint(enter);

                //遍历所有网格位置，找到距离交点最近的一个，并计算其距离
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

                //如果距离小于一个阈值，则将选中的拼图碎片物体移动到该网格位置，并更新其Piece脚本中的当前位置信息
                if (minDistance < pieceSize.x / 2f)
                {
                    selectedPiece.transform.position = nearestGrid;
                    selectedPiece.GetComponent<Piece>().currentPosition = nearestGrid;
                }

                //取消选中，并将其颜色恢复为原始颜色
                selectedPiece.GetComponent<MeshRenderer>().material.color = selectedPieceColor;
                selectedPiece = null;
            }
        }
    }
}