using UnityEngine;

public class L4_1SpikeSpawner : MonoBehaviour
{
    public GameObject SpikePrefab;

    bool a = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (a)
        {
            Debug.Log("Spawner : Spike ����");
            GameObject Spike = Instantiate(SpikePrefab);
            Spike.transform.position = transform.position;
            a = false;
        }
    }
}
