using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TwoSecondLight : MonoBehaviour {

    private float _timeLeft = 2;

    public GameObject trafficLight;

    string currentLight;

    // Use this for initialization
    void Start () {

        if ( PlayerPrefs.GetString("currentLight") == "")
        {
            currentLight = "green";
        }
        else
        {
            Debug.Log("loaded state from file");
            currentLight = PlayerPrefs.GetString("currentLight");
            Debug.Log(currentLight);
        }

	}
	
	// Update is called once per frame
	void Update () {

        //subtract deltaTime until the timer runs out
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            //print(_timeLeft);
        }

        //change light after 2 seconds
        if (_timeLeft < 0)
        {
            if (currentLight == "red")
            {
                Debug.Log("changing to green");

                //change from red to green
                trafficLight.GetComponent<Animator>().Play("greenLight");
                currentLight = "green";
                _timeLeft = 2;

                //save current state
                PlayerPrefs.SetString("currentLight" , currentLight);
                PlayerPrefs.Save();                
            }
            else if (currentLight == "yellow")
            {
                Debug.Log("changing to red");

                trafficLight.GetComponent<Animator>().Play("redLight");
                _timeLeft = 2;
                currentLight = "red";

                //save current state
                PlayerPrefs.SetString("currentLight", currentLight);
                PlayerPrefs.Save();
            }
            else if (currentLight == "green")
            {
                Debug.Log("changing to yellow");

                trafficLight.GetComponent<Animator>().Play("yellowLight");
                _timeLeft = 2;
                currentLight = "yellow";

                //save current state
                PlayerPrefs.SetString("currentLight", currentLight);
                PlayerPrefs.Save();
            }
        }


    }
}
