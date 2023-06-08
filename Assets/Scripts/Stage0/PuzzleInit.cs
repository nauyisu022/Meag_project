using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInit : MonoBehaviour
{
    public GameObject piecesManager;
    public GameObject positionLoader;
    // Start is called before the first frame update
    void Awake()
    {
        Instantiate(piecesManager);
        Instantiate(positionLoader);
    }

}
