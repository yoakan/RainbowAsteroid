using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Space : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float frictionForce = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && collision.tag=="Player")
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            // Aplica una fuerza de frenado en direcci�n opuesta al movimiento actual.
            rb.AddForce(-rb.velocity.normalized * frictionForce);
            
        }
        
    }
}
