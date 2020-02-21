using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    int random;
    public Vector3 spawn_value;
    void Start()
    {
        StartCoroutine(spawnObj());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnObj()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            random = Random.Range(0, 3);

            Vector3 Obstacle_pos = new Vector3(Random.Range(-spawn_value.x, spawn_value.x) ,0, Random.Range(-spawn_value.z, spawn_value.z));
            Instantiate(obstacles[random], Obstacle_pos + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);

            yield return new WaitForSeconds(2);
        }
    }
}
