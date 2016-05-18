using UnityEngine;
using System.Collections;

public class nextButton : MonoBehaviour {

    public GameObject Ipod;

    //draw the click box
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(1f, 1f, 1));
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void OnMouseDown()
    {
        int mp3ToPlay;
        //get and stop previous track
        mp3ToPlay = Ipod.GetComponent<IpodPlayer>().currentTrack;
        Ipod.GetComponent<IpodPlayer>().mp3s[mp3ToPlay].Stop();
        //get the next track (check if it was last of the mp3s in list)
        if ((mp3ToPlay + 1) >= Ipod.GetComponent<IpodPlayer>().numTracks)
        {
            //loop back to first track
            Ipod.GetComponent<IpodPlayer>().currentTrack = 0;
            mp3ToPlay = 0;
        }
        else
        {
            mp3ToPlay++;
            Ipod.GetComponent<IpodPlayer>().currentTrack++;
        }
        
        Ipod.GetComponent<IpodPlayer>().mp3s[mp3ToPlay].Play();       
    }
}
