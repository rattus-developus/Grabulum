using UnityEngine;

public class Swing : MonoBehaviour
{
    public static Swing Instance;
    [SerializeField] GameObject core;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] HingeJoint2D hinge;
    public bool swinging;
    public bool canSwing;
    public bool dead;
    public bool won;

    void Awake()
    {
        Instance = this;
    }

    void StartSwing()
    {
        if(!canSwing)
        {
            canSwing = true;
            return;
        }
        Ball.Instance.GetComponent<Rigidbody2D>().simulated = true;
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
        if (dead || won) return;
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

    public void Restart()
    {
        hinge.enabled = true;
        lineRenderer.enabled = false;
    }

    public void Die()
    {
        canSwing = false;
        hinge.enabled = false;
        lineRenderer.enabled = false;
    }
}
