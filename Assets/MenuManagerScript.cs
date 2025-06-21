using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    public void singlePlayer()
    {
        SceneManager.LoadScene("SinglePlayer");
    }
    public void vsComp()
    {
        SceneManager.LoadScene("TwoPlayer");
    }
}
