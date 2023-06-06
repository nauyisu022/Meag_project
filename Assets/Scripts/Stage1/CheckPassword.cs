using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPassword : MonoBehaviour
{
    public GameObject correctText;
    public GameObject wrongText;
    // Start is called before the first frame update
    void Start()
    {
        UnshowCorrectText();
        UnshowWrongText();
        transform.GetComponent<InputField>().onEndEdit.AddListener(End_Value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void End_Value(string input)
    {
        if(input == "2197")
        {
            correctText.SetActive(true);
            Invoke("UnshowCorrectText", 1.0f);
            Invoke("PasswordCorrect", 1.5f);
            Invoke("Destroy", 1.6f);
        }
        else
        {
            wrongText.SetActive(true);
            Invoke("UnshowWrongText", 1.0f);
            Invoke("Destroy", 1.1f);
        }
    }
    void Destroy()
    {
        Destroy(this.gameObject);
    }
    void UnshowCorrectText()
    {
        correctText.SetActive(false);
    }
    void UnshowWrongText()
    {
        wrongText.SetActive(false);
    }
    void PasswordCorrect()
    {
        //TODO!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        SceneManager.Instance.passwordIsCorrect = true;
    }
}
