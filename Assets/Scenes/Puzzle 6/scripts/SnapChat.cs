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
    public Image captureRect;

    void Start()
    {
        webcamTexture = new WebCamTexture();
        frontFacingCamera.texture = webcamTexture;
        frontFacingCamera.material.mainTexture = webcamTexture;
        webcamTexture.Play();
                
        //load snapCounter
        _CaptureCounter = PlayerPrefs.GetInt("_CaptureCounter");        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        
    public void takeSnap()
    {
        Application.CaptureScreenshot(Application.dataPath + "/Scenes/Puzzle 6/savedSnaps/" + snapFileName + _CaptureCounter.ToString() + ".png");
        ++_CaptureCounter;
        //save current state
        PlayerPrefs.SetInt("_CaptureCounter", _CaptureCounter);
        PlayerPrefs.Save();
    }   

}

