using UnityEngine.SceneManagement;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public void Restart() //restart the game
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu() //return to menu
    {
        SceneManager.LoadScene(0);
    }
}
