using UnityEngine;

public class Pillar : MonoBehaviour
{
    private Transform topPillar, bottomPillar;
    private Rigidbody rb;
    private float pillarSpeed;

    private const float OFFSCREEN_LEFT = -8.2f;

    void Awake()
    {
        // Get top pillar and bottom pillar `setTransforms`
        topPillar = transform.GetChild(0);
        bottomPillar = transform.GetChild(1);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.velocity = Vector3.left * pillarSpeed;

        if (transform.position.x < OFFSCREEN_LEFT - 1)
        {
            Destroy(gameObject);
        }
    }

    // Allow `PillarSpawner` to generate random gap heights
    public void setPillars(float topPillarY, float bottomPillarY, float topPillarHeight, float bottomPillarHeight, float speed)
    {
        topPillar.position = new Vector3(topPillar.position.x, topPillarY, topPillar.position.z);
        bottomPillar.position = new Vector3(bottomPillar.position.x, bottomPillarY, bottomPillar.position.z);

        topPillar.localScale = new Vector3(1, topPillarHeight, 1);
        bottomPillar.localScale = new Vector3(1, bottomPillarHeight, 1);

        pillarSpeed = speed;
    }
}
