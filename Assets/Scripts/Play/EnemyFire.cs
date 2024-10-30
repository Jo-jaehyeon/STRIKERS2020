using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject[] pos;
    public GameObject Bullet;
    public float delayTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0.5f, delayTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire()
    {
        for (int i = 0; i < pos.Length; i++)
        {
            Instantiate(Bullet, pos[i].transform.position, pos[i].transform.rotation);
        }
    }
}
