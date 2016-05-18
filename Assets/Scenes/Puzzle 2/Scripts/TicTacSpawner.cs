using UnityEngine;
using System.Collections;

public class TicTacSpawner : MonoBehaviour
{
    public GameObject gameState;

    public GameObject ticTacSpawner;
    public GameObject heartMarker;
    public GameObject xMarker;
    public int cellVal;
    bool cellFilled;
    bool gameOver = false;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(.5f, .5f, 1));
    }

    // Use this for initialization
    void Start()
    {
        cellFilled = false;
        cellVal = 3;
    }

    // Update is called once per frame
    void Update()
    {
        //check if game is over to stop objects from being able to spawn
        gameOver = gameState.GetComponent<TicTacToe>().win;
        if (!gameOver)
        {
            gameOver = gameState.GetComponent<TicTacToe>().catsGame;
        }

    }

    public void OnMouseDown()
    {
        if (!cellFilled && !gameOver)//and win condition is !true
        {
            string turn = gameState.GetComponent<TicTacToe>().whosTurn;  

            if (turn == "x")
            {
                Instantiate(xMarker, ticTacSpawner.transform.position, Quaternion.identity);
                cellVal = 1;
                cellFilled = true;
                gameState.GetComponent<TicTacToe>().whosTurn = "h";
            }
            if (turn == "h")
            {
                Instantiate(heartMarker, ticTacSpawner.transform.position, Quaternion.identity);
                cellVal = 0;
                cellFilled = true;
                gameState.GetComponent<TicTacToe>().whosTurn = "x";
            }

            Debug.Log("mouse area clicked");
        }
    }
}