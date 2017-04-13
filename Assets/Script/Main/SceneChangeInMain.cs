using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeInMain : MonoBehaviour {

    public void GoToGame()
    { 
        SceneManager.LoadScene("Game");
    }

    public void GoToRank()
    {
        SceneManager.LoadScene("RankBeautie");
        // SceneManager.LoadScene("Rank");
    }

}
