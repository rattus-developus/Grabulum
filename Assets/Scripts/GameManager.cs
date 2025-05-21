using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject winScreen;
    public static GameManager Instance;
    bool dead;
    public bool won;

    void Awake()
    {
        Instance = this;
    }

    public void Die()
    {
        dead = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(0);
        
        if(won)
        {
            winScreen.SetActive(true);
        }


        if(dead && Input.GetKeyDown(KeyCode.Mouse0))
        {
            dead = false;
            Ball.Instance.transform.position = Ball.Instance.startPos;
            Ball.Instance.GetComponent<Renderer>().enabled = true;
            Ball.Instance.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            Ball.Instance.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            //Ball.Instance.GetComponent<Rigidbody2D>().simulated = true;

            Swing.Instance.Restart();
        }

        if(won && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(SceneManager.GetActiveScene().buildIndex != 6) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else SceneManager.LoadScene(0);
        }
    }
}
