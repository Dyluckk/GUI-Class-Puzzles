using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class textClick : MonoBehaviour {

   
    public InputField textInput;
    bool isClicked;
    // Use this for initialization
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(.5f, .5f, 1));
    }

    // Use this for initialization
    void Start()
    {
        isClicked = false;
        textInput.GetComponent<InputField>().interactable = false;
        textInput.GetComponent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        if (!isClicked)
        {
            textInput.GetComponent<InputField>().interactable = true;
            textInput.GetComponent<CanvasGroup>().alpha = 1;
            isClicked = true;
        }
        else
        {
            textInput.GetComponent<InputField>().interactable = false;
            if (textInput.text == "")
            {
                textInput.GetComponent<CanvasGroup>().alpha = 0;
            }
            isClicked = false;
        }

    }
}
