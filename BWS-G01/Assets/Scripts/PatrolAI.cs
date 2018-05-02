using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    public float Speed;

    public Transform[] Spots;
    private bool goRight;
    private bool goLeft;

    void Update()
    {
        if (Vector2.Distance(transform.position, Spots[0].position) < 0.2f)
        {
            goRight = true;
            goLeft = false;
        }
        if (Vector2.Distance(transform.position, Spots[1].position) < 0.2f)
        {
            goRight = false;
            goLeft = true;
        }
        if (goRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, Spots[1].position, Speed * Time.deltaTime);
            if (gameObject.tag == "Enemy")
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
        }
        if (goLeft)
        {
            transform.position = Vector2.MoveTowards(transform.position, Spots[0].position, Speed * Time.deltaTime);
            if (gameObject.tag == "Enemy")
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
        }
    }
}
