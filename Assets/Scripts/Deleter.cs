using UnityEngine;

public class Deleter : MonoBehaviour
{
    [SerializeField] float deleteTime = 5f;

    void Update()
    {
        deleteTime -= Time.deltaTime;
        if(deleteTime <= 0f) Destroy(gameObject);
    }
}
