using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBtn : MonoBehaviour
{
    public GameObject CheckText = null;
    public bool isActive = false;
    public void switchTextDisplay ()
    {
        isActive= !isActive;
        CheckText.SetActive (isActive);
    }

    private void Start()
    {
        CheckText.SetActive (isActive);
    }
}
