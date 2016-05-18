using UnityEngine;
using System.Collections;

public class cameraClick : MonoBehaviour {

    public GameObject Iphone;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(.5f, .5f, 1));
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        Iphone.GetComponent<SnapChat>().takeSnap();
    }
}
