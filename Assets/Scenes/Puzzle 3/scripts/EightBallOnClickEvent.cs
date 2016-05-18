using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EightBallOnClickEvent : MonoBehaviour
{
    public GameObject eightBall;
    public GameObject eightBallAnswerSprite;
    public Text Title;
    public Text Prompt;
    public Text Answer;
    public Text Cont;
    public InputField Question;
    string continueString = "Press space to ask another question...";
    Vector3 oldPos;

    private float _timeLeft = 3;
    public bool eightBallDisplaying = false;
    bool answerDisplayed = false;

    void Start() {
        Debug.Log("started");
        eightBallAnswerSprite.GetComponent<SpriteRenderer>().enabled = false;
        Cont.text = "";
        //get original position
        oldPos = new Vector3(eightBall.transform.position.x, eightBall.transform.position.y, eightBall.transform.position.z);
    }

    void Update()
    {
        //subtract deltaTime until the timer runs out
        if (_timeLeft > 0 && eightBallDisplaying)
        {
            _timeLeft -= Time.deltaTime;
            Debug.Log(_timeLeft);
        }

        if (_timeLeft < 0 && eightBallDisplaying && !answerDisplayed)
        {
            Title.GetComponent<CanvasGroup>().alpha = 0;
            Prompt.GetComponent<CanvasGroup>().alpha = 0;
            Question.GetComponent<CanvasGroup>().alpha = 0;
            eightBall.GetComponent<SpriteRenderer>().enabled = false;
            eightBallAnswerSprite.GetComponent<SpriteRenderer>().enabled = true;
            Cont.text = continueString;

            string response = "";
            int randomResponseChoice;

            randomResponseChoice = Random.Range(0, 15);

            switch (randomResponseChoice)
            {
                case 1:
                    response = "Yes, in due time.";
                    
                    break;

                case 2:
                    response = "My sources say no.";
                    break;

                case 3:
                    response = "Definitely not.";
                    break;

                case 4:
                    response = "Yes.";
                    break;

                case 5:
                    response = "You will have to wait.";
                    break;

                case 6:
                    response = "I have my doubts.";
                    break;

                case 7:
                    response = "Outlook so so.";
                    break;

                case 8:
                    response = "Looks good to me!";
                    break;

                case 9:
                    response = "Who knows?";
                    break;

                case 10:
                    response = "Looking good!";
                    break;

                case 11:
                    response = "Probably.";
                    break;

                case 12:
                    response = "Are you kidding?";
                    break;

                case 13:
                    response = "Go for it!";
                    break;

                case 14:
                    response = "Don't bet on it.";
                    break;

                case 15:
                    response = "Forget about it.";
                    break;

            }

            Answer.GetComponent<Text>().text = response;
            answerDisplayed = true;
        }

        if (eightBallDisplaying == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //reset
                Title.GetComponent<CanvasGroup>().alpha = 1;
                Prompt.GetComponent<CanvasGroup>().alpha = 1;
                Question.GetComponent<CanvasGroup>().alpha = 1;
                Answer.GetComponent<Text>().text = "";
                _timeLeft = 2;
                eightBallDisplaying = false;
                answerDisplayed = false;
                eightBall.GetComponent<SpriteRenderer>().enabled = true;
                eightBallAnswerSprite.GetComponent<SpriteRenderer>().enabled = false;
                eightBall.GetComponent<Animator>().Play("EightBallIdle");
                Cont.text = "";
                eightBall.transform.position = oldPos;
            }
        } 
    }

}
