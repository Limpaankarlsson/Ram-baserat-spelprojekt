using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour
{
    private float Speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Rightandleft = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Rightandleft * Speed * Time.deltaTime);
    }

    private void Self_move()
    {

    }
}
