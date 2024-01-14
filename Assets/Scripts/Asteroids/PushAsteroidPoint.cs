
using Unity.VisualScripting;
using UnityEngine;

public class PushAsteroidPoint : MonoBehaviour
{
    [SerializeField] private Vector2 direction = Vector2.up;
    [SerializeField] private float rangePush=0.5f;
    
    public void pushAsteroid(Rigidbody2D rigidbody2D,float forcePush)
    {
        
        //Vector2 randomDirection = Random.Range(-rangePush,rangePush)*(Vector2.one - direction.Abs());
        Vector2 randomDirection = Random.Range(-rangePush,rangePush)*(Vector2.one - new Vector2(Mathf.Abs(direction.x),Mathf.Abs(direction.y)));
        //print("Vector normalizado: " + direction.Abs() + " direccion randomizada " + randomDirection+" Vector Formado: "+(direction+randomDirection));
        rigidbody2D.AddForce((direction+randomDirection)*forcePush);
    }
}
