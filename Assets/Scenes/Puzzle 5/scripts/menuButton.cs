using UnityEngine;
using System.Collections;

public class menuButton : MonoBehaviour {

    public GameObject Ipod;
    public int oldCurrent;

    //draw the click box
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(2f, .75f, 1));
    }

    // Use this for initialization
    void Start () {
	    //display main menu
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void OnMouseDown()
    {
        //if not on menu, goes to menu
        if (!(Ipod.GetComponent<IpodPlayer>().onSongMenu))
        {
            Ipod.GetComponent<IpodPlayer>().displayMenu();
            oldCurrent = Ipod.GetComponent<IpodPlayer>().currentTrack;
        }

        //moves the selector if on the song menu
        if (Ipod.GetComponent<IpodPlayer>().onSongMenu)
        {
            if (Ipod.GetComponent<IpodPlayer>().currentTrack != 0)
            {
                //set current track
                Ipod.GetComponent<IpodPlayer>().currentTrack--;
                //move selector
                Ipod.GetComponent<IpodPlayer>().songSelector.transform.localPosition =
                    new Vector3(Ipod.GetComponent<IpodPlayer>().songSelector.transform.localPosition.x, (Ipod.GetComponent<IpodPlayer>().songSelector.transform.localPosition.y + 22), 0);
            }
        }
    }
}
