using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public float timeBetweenSpawns;
    private float currentTimeBetweenSpawns;
    public float farLeft;
    public float farRight;
    // Start is called before the first frame update
    void Start()
    {
        currentTimeBetweenSpawns = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //enemy spawn
        if(currentTimeBetweenSpawns <= 0){
            Vector3 position = new Vector3(Random.Range(farLeft, farRight), this.gameObject.transform.position.y, 0);
            Instantiate(enemy, position, enemy.transform.rotation);
            currentTimeBetweenSpawns = timeBetweenSpawns;
        }else{
            currentTimeBetweenSpawns -= Time.deltaTime;
        }
    }
}
