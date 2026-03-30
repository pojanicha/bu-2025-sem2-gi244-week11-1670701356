using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;
    private GameObject player;

    public bool isStunned = false;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();
        rb.AddForce(dir * speed);*/

        if (StunPowerUp.isStunned)
        { 
            rb.linearVelocity = Vector3.zero;
            return;
        }

        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();
        rb.linearVelocity = dir * speed;


    }




}
