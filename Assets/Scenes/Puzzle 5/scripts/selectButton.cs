using UnityEngine;
using System.Collections;

public class selectButton : MonoBehaviour
{
    public GameObject playBtn;
    public GameObject Ipod;
    public GameObject menuBtn;

    //draw the click box
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(1.5f, 1.5f, 1));
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        //moves the selector if on the song menu
        if (Ipod.GetComponent<IpodPlayer>().onSongMenu)
        {
            int mp3ToPlay;

            if (playBtn.GetComponent<playButton>().playing)
            {
                mp3ToPlay = Ipod.GetComponent<IpodPlayer>().currentTrack;
                Ipod.GetComponent<IpodPlayer>().mp3s[menuBtn.GetComponent<menuButton>().oldCurrent].Stop();
            }

            playBtn.GetComponent<playButton>().playing = true;
           
            mp3ToPlay = Ipod.GetComponent<IpodPlayer>().currentTrack;
            Ipod.GetComponent<IpodPlayer>().mp3s[mp3ToPlay].Play();
            Debug.Log("select clicked");

            //display the player
            Ipod.GetComponent<IpodPlayer>().displayPlayer();
            
        }
    }
}
