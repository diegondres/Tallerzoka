using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovimiento : MonoBehaviour
{
    public Transform prota;
    private Vector3 newPosition;
    public float sensitivity = 0.5f;

    // Update is called once per frame
    void Update()
    {

        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (prota == null) return;
        newPosition = prota.position;
        Vector3 newPos = new(newPosition.x, newPosition.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, sensitivity);
    }
}
