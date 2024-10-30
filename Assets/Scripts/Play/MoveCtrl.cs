using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCtrl : MonoBehaviour
{
    public Transform tr;
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tr.Translate(Vector3.right * speed * Time.deltaTime);

    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
  
}
