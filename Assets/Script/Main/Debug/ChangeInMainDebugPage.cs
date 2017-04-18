using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeInMainDebugPage : MonoBehaviour
{
    public void GoToGameForFour ()
    {
        SceneManager.LoadScene("GameForFour");
    }

    public void GoToGameFourBtn ()
    {
        SceneManager.LoadScene("GameFourBtn");
    }

    public void GoToGameGyro ()
    {
        SceneManager.LoadScene("GameGyro");
    }

    public void GoToGameWithoutAnim ()
    {
        SceneManager.LoadScene("GameWithoutAnim");
    }
}
