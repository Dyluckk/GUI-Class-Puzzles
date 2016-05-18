using UnityEngine;
using System.Collections;

public class playButton : MonoBehaviour {

    public GameObject Ipod;
    public bool playing;

    //draw the click box
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(1f, 1f, 1));
    }

    // Use this for initialization
    void Start () {
        playing = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void OnMouseDown()
    {
        //moves the selector if on the song menu
        if (Ipod.GetComponent<IpodPlayer>().onSongMenu)
        {
            if (Ipod.GetComponent<IpodPlayer>().currentTrack + 1 != Ipod.GetComponent<IpodPlayer>().numTracks)
            {
                //set current track
                Ipod.GetComponent<IpodPlayer>().currentTrack++;
                //move selector
                Ipod.GetComponent<IpodPlayer>().songSelector.transform.localPosition =
                    new Vector3(Ipod.GetComponent<IpodPlayer>().songSelector.transform.localPosition.x, (Ipod.GetComponent<IpodPlayer>().songSelector.transform.localPosition.y - 22), 0);
            }
        }

        //plays and pauses the player
        if (Ipod.GetComponent<IpodPlayer>().onPlayer)
        {
            if (playing == false)
            {
                playing = true;
                int mp3ToPlay;
                mp3ToPlay = Ipod.GetComponent<IpodPlayer>().currentTrack;
                Ipod.GetComponent<IpodPlayer>().mp3s[mp3ToPlay].Play();
                Debug.Log("play clicked");
            }
            else
            {
                playing = false;
                int mp3ToPlay;
                mp3ToPlay = Ipod.GetComponent<IpodPlayer>().currentTrack;
                Ipod.GetComponent<IpodPlayer>().mp3s[mp3ToPlay].Pause();
                Debug.Log("pause clicked");
            }
        }
    }
}
