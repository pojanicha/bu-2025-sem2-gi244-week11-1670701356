using System.Collections;
using UnityEngine;

public class StunPowerUp : MonoBehaviour
{
    public static bool isStunned = false;

    public float stunDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(StunRoutine());
            Destroy(gameObject);
        }
    }
    IEnumerator StunRoutine()
    { 
        isStunned = true;
        yield return new WaitForSeconds(stunDuration);
        isStunned = false;


    }



        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

