using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TicTacToe : MonoBehaviour {

   void OnMouseDown(){
        // this object was clicked - do something
        gameObject.GetComponent<Text>().text = "X";
        
    }
    

    
}
