using UnityEngine;

public class FlechaAvanza : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0, 0, 0.05f, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
