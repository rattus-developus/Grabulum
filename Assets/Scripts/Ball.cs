
using UnityEngine;
using UnityEngine.VFX;

public class Ball : MonoBehaviour
{
    public static Ball Instance;
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject scoreVFX;
    [HideInInspector] public Vector2 startPos;

    void Awake()
    {
        startPos = transform.position;
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //GetComponent<Rigidbody2D>().simulated = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Environment")) Die();
        else if (collision.transform.CompareTag("EndZone")) Score();
    }

    void Die()
    {
        GameManager.Instance.Die();
        Swing.Instance.Die();
        GameObject obj = Instantiate(deathVFX);
        obj.GetComponent<VisualEffect>().SetVector2("initialVelocity", GetComponent<Rigidbody2D>().linearVelocity);
        obj.transform.position = transform.position;

        //GetComponent<Renderer>().enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        //Destroy(gameObject);
    }

    void Score()
    {
        GameManager.Instance.won = true;
        Swing.Instance.won = true;
        Swing.Instance.Die();
        GameObject obj = Instantiate(scoreVFX);
        obj.transform.position = transform.position;
        Destroy(gameObject);
    }
}
