using UnityEngine;

public class Jump : MonoBehaviour
{
    private float top;
    private float bottom; 
    private float distance = 3f;
    private float bounceSpeed = 0.1f;
    private bool goingUp = true; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bottom = transform.position.y;
        top = transform.position.y + distance; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (goingUp){
            transform.position = new Vector3(transform.position.x, transform.position.y + bounceSpeed, transform.position.z);
            if (transform.position.y >= top){
                goingUp = false; 
            }
        } else {
            transform.position = new Vector3(transform.position.x, transform.position.y - bounceSpeed, transform.position.z);
            if (transform.position.y <= bottom){
                goingUp = true; 
            }
        }
    }
}
