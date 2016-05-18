using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO; 
using System;
public class SnapChat : MonoBehaviour
{
    public RawImage frontFacingCamera;
    string snapFileName = "snapchat";
    int _CaptureCounter = 0;
    WebCamTexture webcamTexture;

    //private string _SavePath = Application.dataPath + "/snapchatSS/";

    void Start()
    {
        webcamTexture = new WebCamTexture();
        frontFacingCamera.texture = webcamTexture;
        frontFacingCamera.material.mainTexture = webcamTexture;
        webcamTexture.Play();

        //load snapCounter
        _CaptureCounter = PlayerPrefs.GetInt("_CaptureCounter");
        Debug.Log(webcamTexture.width);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeSnap();
        }
    }

    public void takeSnap()
    {
        Texture2D snap = new Texture2D(webcamTexture.width, webcamTexture.height);
        snap.SetPixels(webcamTexture.GetPixels());
        snap.Apply();

        System.IO.File.WriteAllBytes(Application.dataPath + "/Scenes/Puzzle 6/savedSnaps/" + snapFileName + _CaptureCounter.ToString() + ".png", snap.EncodeToPNG());
        ++_CaptureCounter;

        PlayerPrefs.SetInt("_CaptureCounter", _CaptureCounter);
        PlayerPrefs.Save();
    }      
     

}

