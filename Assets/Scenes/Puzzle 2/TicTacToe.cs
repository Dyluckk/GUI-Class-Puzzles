using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TicTacToe : MonoBehaviour {

    public string whosTurn;
    public GameObject[] Cells;
    public Text prompt;
    public bool win = false;
    public bool catsGame = false;
    string winner = "";

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(.2f, .2f, 1));
    }

    void Start()
    {
        whosTurn = "x";
    }

    void Update()
    {
        int[] cellVals = { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
        
        //check the current state of the array
        cellVals[0] = Cells[0].GetComponent<TicTacSpawner>().cellVal;
        cellVals[1] = Cells[1].GetComponent<TicTacSpawner>().cellVal;
        cellVals[2] = Cells[2].GetComponent<TicTacSpawner>().cellVal;
        cellVals[3] = Cells[3].GetComponent<TicTacSpawner>().cellVal;
        cellVals[4] = Cells[4].GetComponent<TicTacSpawner>().cellVal;
        cellVals[5] = Cells[5].GetComponent<TicTacSpawner>().cellVal;
        cellVals[6] = Cells[6].GetComponent<TicTacSpawner>().cellVal;
        cellVals[7] = Cells[7].GetComponent<TicTacSpawner>().cellVal;
        cellVals[8] = Cells[8].GetComponent<TicTacSpawner>().cellVal;

        if (!win)
        {
            //check if x won
            win = checkWin(1, cellVals);

            //if x wins
            if (win)
            {
                winner = "X";
            }

            if (!win)
            {
                //check if hearts won
                win = checkWin(0, cellVals);
                //check if hearts won
                if (win)
                {
                    winner = "Hearts";
                }
            }
        }
        //check for cats if game is not won
        if(!win)
        {
            catsGame = checkCatsGame(cellVals);
        }

        //check if game is over by cats game or game over
        if (!win && !catsGame)
        {
            //set text based on turn
            if (whosTurn == "x")
            {
                prompt.text = "X's Turn";
            }
            else if (whosTurn == "h")
            {
                prompt.text = "Hearts's Turn";
            }
        }
        else if (catsGame)
        {
            prompt.text = "Cats Game!";
        }
        else if (win)
        {
            prompt.text = winner + " Wins!!!";
        }
    }

    bool checkWin(int marker, int[] cellVals)
    {
        bool win = false;
        int index = 0;
        
        //check if horizontal win
        while (index < 6)
        {
            //check if horizontal win
            if ((cellVals[index] == marker) && (cellVals[index + 1] == marker) && (cellVals[index + 2] == marker))
            {
                Debug.Log("Horz win" + marker);
                win = true;
                index = 3;
            }
            index += 3;            
        }

        //reset var
        index = 0;

        //check if vertical win
        while (index < 3)
        {
            if ((cellVals[index] == marker) && (cellVals[index + 3] == marker) && (cellVals[index + 6] == marker))
            {
                Debug.Log("vert win" + marker);
                win = true;
                index = 3;
            }

            index++;
        }

        //check diagnal win
        if ((cellVals[0] == marker) && (cellVals[4] == marker) && (cellVals[8] == marker))
        {
            Debug.Log("Diag win" + marker);
            win = true;
        }

        if ((cellVals[2] == marker) && (cellVals[4] == marker) && (cellVals[6] == marker))
        {
            Debug.Log("Diag win" + marker);
            win = true;
        }

        return win;
    }

    bool checkCatsGame(int[] cellVals)
    {
        bool cats = true;

        for (int i = 0; i < 9; i++)
        {
            if (cellVals[i] == 3)
                cats = false;
        }
        
        return cats;
    }
}
