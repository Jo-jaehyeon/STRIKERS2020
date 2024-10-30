using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCtrl : MonoBehaviour
{
    // Start is called before the first frame update

    public int hp = 10;
    public int initHp = 10;
    public static int wn = 1;
    public Rigidbody2D rb;
    public float speed = 300.0f;
    public Transform tr;
    public static int PlaneLevel = 0;
    float h; //좌, 우
    float v; //상, 하


    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(h, v);
        rb.velocity = dir * speed * Time.deltaTime;

        float Size = Camera.main.orthographicSize;
     
        if (tr.position.y >= Size - 0.4f)
        {
            tr.position = new Vector3(tr.position.x, Size - 0.4f, 0);
        }
        if (tr.position.y <= - Size + 0.8f)
        {
            tr.position = new Vector3(tr.position.x, - Size + 0.8f, 0);
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float wSize = Camera.main.orthographicSize * screenRatio;

        if (tr.position.x >= wSize*2-0.5f)
        {
            tr.position = new Vector3(wSize*2-0.5f, tr.position.y, 0);
        }
        if (tr.position.x <= -wSize + 1.0f)
        {
            tr.position = new Vector3(-wSize + 1.0f, tr.position.y, 0);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))        
            wn = 1;
        
        else if (Input.GetKeyDown(KeyCode.Alpha2))        
            wn = 2;
        
        else if (Input.GetKeyDown(KeyCode.Alpha3))   
            wn = 3;
        
        transform.GetChild(PlaneLevel-1).gameObject.SetActive(false);
        transform.GetChild(PlaneLevel).gameObject.SetActive(true);
        
    }

    void Awake()
    {
        hp = initHp;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            hp--;
            GameManager.hp--;
            if(hp<=0)
            {
                SceneManager.LoadScene("End");
            }
        }
        if(collision.CompareTag("Item"))
        {
            if (PlaneLevel < 2)
            {
                PlaneLevel++;
                hp += 10;
                initHp += 10;
            }
        }
    }
}
