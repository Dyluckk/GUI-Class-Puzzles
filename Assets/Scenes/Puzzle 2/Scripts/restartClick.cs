using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class restartClick : MonoBehaviour {

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
