using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;

    private InputAction moveAction;
    private InputAction smashAction;
    private InputAction breakAction;

    public Transform focal;

    public bool hasPowerUp = false;

    public GameObject powerUpEffect;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
        smashAction = InputSystem.actions.FindAction("Smash");
        breakAction = InputSystem.actions.FindAction("Break");
    }

    private void Start()
    {
        powerUpEffect.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        var move = moveAction.ReadValue<Vector2>();
        rb.AddForce(move.y * speed * focal.forward);
        if (breakAction.IsPressed())
        {
            rb.linearVelocity = Vector3.zero;

        }


    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           
            if (hasPowerUp == true)
            {

                var rb = collision.gameObject.GetComponent<Rigidbody>();
                var dir = collision.transform.position - transform.position;
                //rb.AddForce(5 * dir.normalized, ForceMode.Impulse);
                rb.linearVelocity = Vector3.zero;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /* if (other.CompareTag("PowerUp"))
         {
             hasPowerUp = true;
             Destroy(other.gameObject);
             powerUpEffect.SetActive(true);

             if (countDown != null)
             {
                 StopCoroutine(countDown);
             }
            countDown = StartCoroutine(PowerUpCountDownRoutine());
         }*/



        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            powerUpEffect.SetActive(true);
            if (countDown != null)
            {
                StopCoroutine(countDown);
            }
            countDown = StartCoroutine(PowerUpCountDownRoutine());
        }
    }

    private Coroutine countDown;

    IEnumerator PowerUpCountDownRoutine()
    {
        yield return new WaitForSeconds(10);
        hasPowerUp = false;

        powerUpEffect.SetActive(false);
    }






}


