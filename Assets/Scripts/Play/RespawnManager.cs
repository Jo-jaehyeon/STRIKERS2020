using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject Enemy;
    public Transform respawnTr;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RespawnEnemy());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RespawnEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.8f);
            float range = (float)Screen.height / (float)Screen.width * Camera.main.orthographicSize;
            Instantiate(Enemy, respawnTr.position + new Vector3(0, Random.Range(-range+1.5f, range+0.5f), 0), Quaternion.identity);
        }
    }
}
