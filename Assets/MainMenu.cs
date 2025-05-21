using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject home;
    [SerializeField] GameObject levelMenu;

    public void Home()
    {
        home.SetActive(true);
        levelMenu.SetActive(false);
    }

    public void Levels()
    {
        levelMenu.SetActive(true);
        home.SetActive(false);
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
