using UnityEngine;

public class Spammer : MonoBehaviour
{
    public GameObject prefabMalos;
    public GameObject prefabEnergy;
    public Transform prota;
    public float time = 5f;
    public float repeatTime = 10f;
    public float radio = 50;
    public float timeFactor = 3f;
    public float probabilityGiveEnergy = 5f;
    void Start()
    {
        InvokeRepeating(nameof(CreateEnemigo), time, repeatTime);
        InvokeRepeating(nameof(CreateEnergy), time, repeatTime * timeFactor);

    }

    private void CreateEnemigo()
    {
        if (prota == null) return;

        float x = Mathf.Abs(prota.position.x) + radio;
        float y = Mathf.Abs(prota.position.y) + radio;
        Vector3 position = new(UnityEngine.Random.Range(-x, x), UnityEngine.Random.Range(-y, y), -0.02f);
        Instantiate(prefabMalos, position, Quaternion.identity);
    }

    public void CreateEnergy()
    {
        Vector3 position = new(Random.Range(-499, 499), Random.Range(-499, 499), -0.02f);
        Instantiate(prefabEnergy, position, Quaternion.identity);
    }

}
