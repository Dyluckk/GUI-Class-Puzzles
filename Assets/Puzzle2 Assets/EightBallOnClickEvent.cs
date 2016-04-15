using UnityEngine;
using System.Collections;

public class EightBallOnClickEvent : MonoBehaviour
{

    public Animator eightBallAnimator;
    const int STATE_IDLE = 0;
    const int SATE_PLAYING = 1;
    bool _isPlaying = false;
    int _currentAnimationState = STATE_IDLE;

    void Start()
    {
        eightBallAnimator = this.GetComponent<Animator>();
    }

    public void OnMouseDown()
    {
        Debug.Log("Sprite Clicked");


    }

    void changeState(int state)
    {
        if (_currentAnimationState == state)
        {
            return;
        }

        switch (state)
        {

            case STATE_IDLE:
                eightBallAnimator.SetInteger("state", STATE_IDLE);
                break;

            case SATE_PLAYING:
                eightBallAnimator.SetInteger("state", SATE_PLAYING);
                break;

        }

        _currentAnimationState = state;
    }
}
