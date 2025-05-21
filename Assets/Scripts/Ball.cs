using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.VFX;

public class Ball : MonoBehaviour
{

    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject scoreVFX;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<Rigidbody2D>().simulated = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Environment")) Die();
        else if (collision.transform.CompareTag("EndZone")) Score();
    }

    void Die()
    {
        Swing.Instance.Die();
        GameObject obj = Instantiate(deathVFX);
        obj.GetComponent<VisualEffect>().SetVector2("initialVelocity", GetComponent<Rigidbody2D>().linearVelocity);
        obj.transform.position = transform.position;
        Destroy(gameObject);
    }

    void Score()
    {
        Swing.Instance.Die();
        GameObject obj = Instantiate(scoreVFX);
        obj.transform.position = transform.position;
        Destroy(gameObject);
    }
}
