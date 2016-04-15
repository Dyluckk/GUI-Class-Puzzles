using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TicTacToe : MonoBehaviour {

  // public GameObject cell;
   public void changeText(){
        // this object was clicked - do something
       // cell = GameObject.Find("Top1");
        gameObject.GetComponent<Text>().text = "X";
        
    }
    

    
}
