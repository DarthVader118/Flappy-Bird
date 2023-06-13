using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarSpawner : MonoBehaviour
{
    [SerializeField]
    float spawnDelay;

    [SerializeField]
    GameObject pillar;

    [SerializeField]
    float gapWidth;

    [SerializeField]
    float pillarSpeed;

    [SerializeField]
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("generatePillars", 0f, spawnDelay);
    }

    // create pillar with appropiate scale and location
    void generatePillars()
    {
        float gapY = Random.Range(-4f, 4f);
        float gapTop = gapY + gapWidth / 2;
        float gapBottom = gapY - gapWidth / 2;

        float topPillarHeight = GameController.SCREENTOP - gapTop;
        float topPillarY = topPillarHeight / 2 + gapTop;

        float bottomPillarHeight = gapBottom - GameController.SCREENBOTTOM;
        float bottomPillarY = gapBottom - bottomPillarHeight / 2;


        GameObject generatedPillar = Instantiate(pillar, transform);

        Pillar generatedPillarScript = generatedPillar.GetComponent<Pillar>();

        generatedPillarScript.setPillars(topPillarY, bottomPillarY, topPillarHeight, bottomPillarHeight, pillarSpeed);

        gameController.pillars.Enqueue(generatedPillar.transform);
    }
}
