using UnityEngine;

public class L4_1SpikeAction : MonoBehaviour
{
    float speed = 5;
    void Start()
    {
        Application.targetFrameRate = 100;

    }

    void Update()
    {
        float moveVectorx = Time.deltaTime * speed;
        transform.position = new Vector3(transform.position.x - moveVectorx, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("SpikeDestroyer"))
        {
            Destroy(gameObject);
            Debug.Log("Spike : ¼Ò¸ê");
        }   
    }
}
