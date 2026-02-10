using UnityEngine;

public class Obstacle : MonoBehaviour
/* programer: Christian james
 * Date: 11/4/2025
 */
{
    //set variables
    public float minSize = 0.5f;
    public float maxSize = 2.00f;
    Rigidbody2D rb;

    public float minSpeed = 50f;
    public float maxSpeed = 150f;


    void Start()
    {
        // set random size
        float randomSize = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomSize, randomSize, 1);

        //move in random direction
        rb = GetComponent<Rigidbody2D>();
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        Vector2 randomDirection = Random.insideUnitCircle;
        rb.AddForce(randomDirection * randomSpeed);
    }


    void Update()
    {

    }
}
