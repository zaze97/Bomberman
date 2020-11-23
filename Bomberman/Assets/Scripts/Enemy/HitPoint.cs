using UnityEngine;

public class HitPoint : MonoBehaviour
{
    public bool bombAvilable;
    int dir;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("受到伤害");

            other.GetComponent<IDamageable>().GetHit(1);
        }

        if (other.CompareTag("Boom") && bombAvilable)
        {
            if (transform.position.x > other.transform.position.x)
            {
                dir = -1;
            }
            else
            {
                dir = 1;
            }
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(dir, 1) * 10, ForceMode2D.Impulse);
        }
    }


}
