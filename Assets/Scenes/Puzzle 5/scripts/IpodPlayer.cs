using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IpodPlayer : MonoBehaviour {

    public AudioSource[] mp3s;

    public Text trackName;
    public Text songLength;
    public Text songDuration;
    public Text[] songList;

    public Image songSelector;

    public Slider songSilder;

    public GameObject menuPanel;
    public GameObject playerPanel;
    public GameObject volPanel;

    public int currentTrack;
    public int numTracks;
    public bool onPlayer;
    public bool onSongMenu;

    // Use this for initialization
    void Start () {
        //use player prefs to get the track they were on originally for now use 0 as start
        onSongMenu = true;
        onPlayer = false;
        currentTrack = 0;
        numTracks = mp3s.Length;
        trackName.text = mp3s[currentTrack].name;
        Debug.Log(mp3s[currentTrack].clip.length);

        songList[0].text = mp3s[0].name;
        songList[1].text = mp3s[1].name;
        songList[2].text = mp3s[2].name;
    }
	
	// Update is called once per frame
	void Update () {
        trackName.text = mp3s[currentTrack].name;
        
        //update length
        float songTime = mp3s[currentTrack].clip.length; 
        string minSec = string.Format("{0}:{1:00}", (int)songTime / 60, (int)songTime % 60);
        songLength.text = minSec;

        //update duration
        songTime = mp3s[currentTrack].time;
        minSec = string.Format("{0}:{1:00}", (int)songTime / 60, (int)songTime % 60);
        songDuration.text = minSec;

        //update scroll bar
        songSilder.GetComponent<Slider>().value = ((mp3s[currentTrack].time) / (mp3s[currentTrack].clip.length));
        
        //if the song ends play next
        if (mp3s[currentTrack].time == mp3s[currentTrack].clip.length)
        {
            Debug.Log("song ended");
            if (!((currentTrack + 1) >= numTracks))
            {
                currentTrack++;
                mp3s[currentTrack].Play();
            }
            else
            {
                currentTrack = 0;
                mp3s[currentTrack].Play();
            }
        }
    }

    public void displayPlayer()
    {
        onPlayer = true;
        playerPanel.GetComponent<CanvasGroup>().alpha = 1;
        volPanel.GetComponent<CanvasGroup>().alpha = 1;
        volPanel.GetComponent<CanvasGroup>().interactable = true;

        onSongMenu = false;
        menuPanel.GetComponent<CanvasGroup>().alpha = 0;       
    }

    public void displayMenu()
    {
        onSongMenu = true;
        menuPanel.GetComponent<CanvasGroup>().alpha = 1;

        onPlayer = false;
        playerPanel.GetComponent<CanvasGroup>().alpha = 0;
        volPanel.GetComponent<CanvasGroup>().alpha = 0;
        volPanel.GetComponent<CanvasGroup>().interactable = false;
    }

}
