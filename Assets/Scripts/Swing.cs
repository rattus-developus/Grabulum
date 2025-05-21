using UnityEngine;

public class Swing : MonoBehaviour
{
    public static Swing Instance;
    [SerializeField] GameObject core;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] HingeJoint2D hinge;
    bool swinging;
    bool dead;

    void Awake()
    {
        Instance = this;
    }

    void StartSwing()
    {
        swinging = true;
        lineRenderer.enabled = true;
        hinge.enabled = true;
        core.SetActive(true);
    }

    void EndSwing()
    {
        GetComponent<Rigidbody2D>().angularVelocity = 0f;
        hinge.transform.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        swinging = false;
        lineRenderer.enabled = false;
        hinge.enabled = false;
        core.SetActive(false);
    }

    void Update()
    {
        if (dead) return;
        if (Input.GetKeyDown(KeyCode.Mouse0)) StartSwing();
        if (Input.GetKeyUp(KeyCode.Mouse0)) EndSwing();

        if (!swinging) transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        else
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hinge.transform.position);
        }
    }

    public void Die()
    {
        hinge.enabled = false;
        lineRenderer.enabled = false;
    }
}
