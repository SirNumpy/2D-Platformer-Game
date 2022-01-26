using UnityEngine;

public class Groundcheck : MonoBehaviour
{
    [SerializeField] public bool isGrounded;
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
            Debug.Log("collided with the ground");
        }
        
    }
}
