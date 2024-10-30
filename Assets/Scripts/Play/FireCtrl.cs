using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject[] pos;
    public GameObject Bullet;
    public GameObject SBullet;

    private int SBCount = 0;
    private bool SBshoot = true;
    private float SBcooltime;

    private bool Heabyshoot = true;
    private float HBtime, HBtime1, HBtime2;
    private float HBcooltime;
    const float shootDelay = 0.1f;
    float shootTimer = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Fire();
    }

    void Fire()
    {
        if (PlayerCtrl.wn == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (PlayerCtrl.PlaneLevel == 2)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        Instantiate(Bullet, pos[j].transform.position, pos[j].transform.rotation);
                    }
                }
                else
                {
                    Instantiate(Bullet, pos[1].transform.position, pos[1].transform.rotation);
                }

            }
        }
        else if (PlayerCtrl.wn == 2)
        {
            if (SBshoot && Input.GetKeyDown(KeyCode.Space))
            {
                if (PlayerCtrl.PlaneLevel == 2)
                {
                    for (int i = 2; i < 5; i++)
                    {
                        Instantiate(SBullet, pos[i].transform.position, pos[i].transform.rotation);
                    }
                }
                else
                {
                    for (int i = 0; i < pos.Length; i++)
                    {
                        Instantiate(SBullet, pos[i].transform.position, pos[i].transform.rotation);
                    }
                }
                if (SBCount < 2)
                    SBCount++;
                else
                {
                    SBshoot = false;
                    SBCount = 0;
                }

            }
            if (!SBshoot)
            {
                SBcooltime += Time.deltaTime;
                if (SBcooltime > 3f)
                {
                    SBshoot = true;
                    SBcooltime = 0;
                }
            }
        }
        else if (PlayerCtrl.wn == 3)
        {
            if (Heabyshoot)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    shootTimer += Time.deltaTime;
                    HBtime += Time.deltaTime;
                    if (shootTimer > shootDelay)
                    {
                        if(PlayerCtrl.PlaneLevel == 2)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                Instantiate(Bullet, pos[j].transform.position, pos[j].transform.rotation);
                            }
                        }
                        else 
                        { 
                            Instantiate(Bullet, pos[1].transform.position, pos[1].transform.rotation); 
                        }
                        
                        shootTimer = 0;
                    }

                    if (HBtime > 5f)
                    {
                        Heabyshoot = false;
                        HBtime = 0;
                    }

                }
                
            }
            if (!Heabyshoot)
            {
                HBcooltime += Time.deltaTime;
                if (HBcooltime > 2f)
                {
                    Heabyshoot = true;
                    HBcooltime = 0;
                }
            }

        }
    }
}
