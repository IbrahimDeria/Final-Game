using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public BoxCollider2D bc;

    public float shootSpeed = 20f;
    public float timer = 0f;
    public Vector2 vel;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        //rb2d.velocity = vel;
        CheckOutOfBounds();
    }

    public void Shoot(Vector2 direction)
    {
        vel = direction * shootSpeed;
        rb2d.velocity = vel;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Character") // Do not forget assign tag to the field
        {
            Rigidbody2D player = other.GetComponent<Rigidbody2D>();
            player.AddForce(vel * 15);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }

    private void CheckOutOfBounds()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Debug.Log(screenPos.x);
        if (screenPos.x < -1000 || screenPos.x > 8000)
        {
            //Debug.Log("Bullet left bounds");
            Destroy(this.gameObject);
        }
    }
}