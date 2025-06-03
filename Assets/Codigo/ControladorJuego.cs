using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ControladorJuego : MonoBehaviour
{
    public GameObject prefabMalos;
    public Transform prota;
    public float time = 5f;
    public float repeatTime = 10f;
    public float radio = 50;
    void Start()
    {
        InvokeRepeating(nameof(CreateEnemigo), time, repeatTime);
    }

    private void CreateEnemigo()
    {
        float x = prota.position.x + radio;
        float z = prota.position.z + radio;
        Vector3 position = new(UnityEngine.Random.Range(-x, x), UnityEngine.Random.Range(-z, z), 0.02f);
        Instantiate(prefabMalos, position, quaternion.identity);
    }
}
