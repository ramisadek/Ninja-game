using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameover = false;
    [SerializeField] float delay = 2f;
    
    public void gameOver()
    {
        if (gameover == false)
        {
            gameover = true;
            Invoke("Restart", delay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
