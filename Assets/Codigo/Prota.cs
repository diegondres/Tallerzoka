using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Prota : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float velocidadRotacion = 100f;
    public Transform punta;
    public GameObject bala;
    private ControladorJuego controlador;
    private EnergiaController energiaController;
    public float gainEnergy = 500f;
    void Awake()
    {
        controlador = FindAnyObjectByType<ControladorJuego>();
        energiaController = FindAnyObjectByType<EnergiaController>();
    }

    void Update()
    {
        Movement();
        HandleShoot();

    }

    private void Movement()
    {
        // Obtener entrada de teclado
        float movimientoVertical = Input.GetAxis("Vertical");
        float movimientoHorizontal = Input.GetAxis("Horizontal");

        // Calcular movimiento adelante/atrás
        float movimiento = movimientoVertical * velocidadMovimiento * Time.deltaTime;

        // Calcular rotación
        float rotacion = movimientoHorizontal * velocidadRotacion * Time.deltaTime;

        // Aplicar rotación (girar a los lados) 
        transform.Rotate(0, 0, -rotacion);

        // Mover hacia adelante/atrás con respecto a donde mira usando transform.forward
        transform.position += transform.up * movimiento;
    }

    private void HandleShoot()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(bala, punta.position, transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") || collision.gameObject.layer == LayerMask.NameToLayer("Exteriors"))
        {
            controlador.FinalDelJuego();
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Cosas"))
        {
            energiaController.UpdateEnergy(gainEnergy);
            Destroy(collision.gameObject);
        }

    }
}
