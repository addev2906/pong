using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventMangerScript : MonoBehaviour
{
    public CollisionScript collisionScript;
    public Text winText;
    public GameObject winObject;
    public bool gameEnded=false;
    public AudioScript audio;

    public void EndGame()
    {
        if (collisionScript.score1==5)
        {
            gameEnded = true;
            winObject.SetActive(true);
            winText.text = "Player 1 Wins!";
            audio.clap();
        }
        if (collisionScript.score2 == 5)
        {
            gameEnded = true;
            winObject.SetActive(true);
            winText.text = "Player 2 Wins";
            audio.clap();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
