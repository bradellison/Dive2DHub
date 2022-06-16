using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{

    public int spawnValue;

    public string species;
    public float speed;
    public Vector2 startingPosition;
    public Vector2 targetPosition;
    public float wanderRange;
    public FishSpawnPoint spawnPoint;
    public int sellValue;

    private bool isAtTarget;
    public bool isFacingRight;

    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = false;
        startingPosition = this.transform.position;
        ChooseTargetPosition();
    }

    void ChooseTargetPosition() {
        targetPosition = new Vector2(startingPosition.x + Random.Range(-wanderRange, wanderRange), startingPosition.y + Random.Range(-wanderRange, wanderRange));
        if (targetPosition.y > -0.2f) {
            targetPosition.y = -0.2f;
        }

        if (targetPosition.x >= transform.position.x && !isFacingRight) {
            TurnAround();
        } else if (targetPosition.x < transform.position.x && isFacingRight) {
            TurnAround();
        }

    }

    void TurnAround() {
        isFacingRight = isFacingRight ? false : true;
        this.GetComponent<SpriteRenderer>().flipX = isFacingRight;

        if(species == "Anglerfish") {
            Vector2 lightPos = this.transform.GetChild(0).transform.localPosition;
            this.transform.GetChild(0).transform.localPosition = new Vector2(lightPos.x * -1, lightPos.y);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if (Vector2.Distance(transform.position, targetPosition) < 0.1) {
            ChooseTargetPosition();
        }

        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);
    }
}
