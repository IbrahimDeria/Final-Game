using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private float bounce = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Character")){
            if(gameObject.CompareTag("RSpring")){
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*bounce, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right*bounce, ForceMode2D.Impulse);
            }
            if(gameObject.CompareTag("LSpring")){
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*bounce, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left*bounce, ForceMode2D.Impulse);
            }
            // Should add a neutral spring as well
        }
    }
}
