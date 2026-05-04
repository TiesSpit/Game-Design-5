using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private GameObject road;
    private bool spawned;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.ToLower() == "player")
        {
            Destroy(collision.gameObject);
            GameOver.Instance?.DoGameOver();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!spawned)
        {
            if (!other.CompareTag("Player")) return;                         
            Vector3 roadSize = new Vector3(0, 0, transform.localScale.z * 6.25f);

            Instantiate(road, transform.position + roadSize, Quaternion.identity);
            spawned = true;                        
        }
    }
}
