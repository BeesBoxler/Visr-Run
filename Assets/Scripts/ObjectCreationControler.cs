using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreationControler : MonoBehaviour
{
    public GameObject hazard;
    public GameObject hazard_2;
    public Vector3 spawnValue;
    public float spawnWait;
    public float startWait;
    const float minSpawnWait = 0.2f;
    
    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        float[] y_range = { 0, 1,-0.5f};
        float[] x_range = { 0,1,2,3,-1,-2,-3};
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            float timer = spawnWait;
            spawnWait = timer - Time.deltaTime * 10 / 75;
            if (spawnWait < minSpawnWait)
            {
                spawnWait = minSpawnWait;
            }
            Quaternion spawnRotation = Quaternion.identity;

            float y_add = y_range[Random.Range(0, 3)];
            float x_add = x_range[Random.Range(0, 7)];

            Vector3 newposition = new Vector3(spawnValue.x + x_add, spawnValue.y+ y_add, spawnValue.z);

            double random = Random.Range(0, 10);
            if(random > 5)
            {
                Instantiate(hazard, newposition, spawnRotation);
            }
            else
            {
                Instantiate(hazard_2, newposition, spawnRotation);
            }
            yield return new WaitForSeconds(spawnWait);
        }
    }



}
