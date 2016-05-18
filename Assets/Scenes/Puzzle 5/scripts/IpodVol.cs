using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IpodVol : MonoBehaviour {

    public Slider volSlider;
    public Text volPercentage;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        double volPerc;
        volPerc = (volSlider.GetComponent<Slider>().value) * 100;

        volPercentage.text = volPerc.ToString("0") + "%";

        AudioListener.volume = (volSlider.GetComponent<Slider>().value);
    }
}
