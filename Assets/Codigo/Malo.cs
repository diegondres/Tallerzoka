using UnityEngine;

public class Malo : MonoBehaviour
{
    private Prota protaReference;
    public float speed = 1;
    public float sensitivity = 0.3f;
    void Start()
    {
        protaReference = FindAnyObjectByType<Prota>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 protaDirection = protaReference.transform.position - transform.position;
        transform.position += speed * Time.deltaTime * protaDirection.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bala"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
