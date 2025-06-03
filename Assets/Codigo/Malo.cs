using UnityEngine;

public class Malo : MonoBehaviour
{
    private Prota protaReference;
    public float speed = 1;
    public float realSpeed;
    private ControladorJuego controlador;
    private TimeController timeController;
    private Spammer spammer;
    private bool isAway = false;

    void Awake()
    {
        controlador = FindAnyObjectByType<ControladorJuego>();
        protaReference = FindAnyObjectByType<Prota>();
        timeController = FindAnyObjectByType<TimeController>();
        spammer = FindAnyObjectByType<Spammer>();
    }

    void Update()
    {
        if (protaReference == null) return;
        Vector3 protaDirection = protaReference.transform.position - transform.position;

        if (Vector3.Distance(protaReference.transform.position, transform.position) > 100) isAway = true;
        else isAway = false;
        float rialSpeed = isAway ? speed * 2 : speed;
        realSpeed = rialSpeed * timeController.GetMultiplier();
        transform.position += rialSpeed * Time.deltaTime * protaDirection.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bala"))
        {
            int number = Random.Range(0, 100);
            if (number <= spammer.probabilityGiveEnergy)
            {
                Instantiate(spammer.prefabEnergy, transform.position, Quaternion.identity);
            }
            controlador.AddOneDead();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
