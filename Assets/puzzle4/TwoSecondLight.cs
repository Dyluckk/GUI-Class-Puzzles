using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TwoSecondLight : MonoBehaviour {

    private float _timeLeft = 2;

    public Image redLight;
    public Image yellowLight;
    public Image greenLight;

    public Color Red;
    public Color Yellow;
    public Color Green;
    public Color Black;

    private bool onRed = true;
    private bool onYellow = false;
    private bool onGreen = false;

    // Use this for initialization
    void Start () {
        redLight.color = Red;
        yellowLight.color = Black;
        greenLight.color = Black;
	}
	
	// Update is called once per frame
	void Update () {

        //subtract deltaTime until the timer runs out
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            print(_timeLeft);
        }
        if (_timeLeft == 0)
        {
            if (onRed)
            {
                redLight.color = Black;
                yellowLight.color = Black;
                greenLight.color = Green;
                               
                onRed = false;
                onYellow = false;
                onGreen = true;
                _timeLeft = 2;
            }
            else if (onYellow)
            {
                redLight.color = Red;
                yellowLight.color = Black;
                greenLight.color = Green;

                onRed = true;
                onYellow = false;
                onGreen = false;
                _timeLeft = 2;
            }
            else if (onGreen)
            {
                redLight.color = Black;
                yellowLight.color = Yellow;
                greenLight.color = Black;

                onRed = false;
                onYellow = true;
                onGreen = false;
                _timeLeft = 2;
            }
        }


    }
}
