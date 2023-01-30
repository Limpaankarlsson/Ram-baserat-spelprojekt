using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float Playerspeed = 4;
    //float HP = 1;
    //public GameObject laser;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float Rightandleft = Input.GetAxis("Horizontal");
        float Upanddown = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Rightandleft * Playerspeed * Time.deltaTime);
        transform.Translate(Vector3.up * Upanddown * Playerspeed * Time.deltaTime);

        Vector2 direction = new Vector2(Rightandleft, Upanddown).normalized;

        //Move(direction);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Instantiate(laser, transform.position, Quaternion.identity, transform);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Playerspeed += 6;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Playerspeed -= 6;
        }


       /* void Move(Vector3 Direction)
        {
            Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
            Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

            max.x = max.x - 0.225f;
            min.y = min.y + 0.225f;

            max.y = max.y - 0.285f;
            min.x = min.x + 0.285f;

            Vector3 pos = transform.position;

            pos += Playerspeed * Time.deltaTime * Direction;

            pos.x = Mathf.Clamp(pos.x, min.x, max.x);
            pos.y = Mathf.Clamp(pos.y, min.y, max.y);

            transform.position = pos;

        }*/
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            print("Hit");
        }
    }
}
