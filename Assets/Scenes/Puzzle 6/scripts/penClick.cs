using UnityEngine;
using System.Collections;

public class penClick : MonoBehaviour
{
    public GameObject WebCamCanvas;
    bool isClicked;
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(.5f, .5f, 1));
    }

    // Use this for initialization
    void Start()
    {
        isClicked = false;
        WebCamCanvas.GetComponent<DrawWithMouse>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        if (!isClicked)
        {
            WebCamCanvas.GetComponent<DrawWithMouse>().enabled = true;
            isClicked = true;
        }
        else
        {
            WebCamCanvas.GetComponent<DrawWithMouse>().enabled = false;
            isClicked = false;
        }                
    }

}
