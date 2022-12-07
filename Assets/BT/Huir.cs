using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class Huir : ActionNode
{

    GameObject other;
    Transform nearest;
    protected override void OnStart() {
        Debug.Log($"{context.gameObject.name}: Huir");
        other = GameManager.GetOther(context.gameObject); // Devuelve el otro agente

        GameObject[] food = GameObject.FindGameObjectsWithTag("Comida");
        nearest = GetAwayFood(food);

        context.agent.SetDestination(nearest.transform.position);

    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (nearest == null)
            return State.Success;

        if (Vector3.Distance(context.transform.position, nearest.position) < 1.3f) {
            GameObject.Destroy(nearest.gameObject);
            OnEat();
            return State.Success;
        }

        return State.Running;
    }

    Transform GetAwayFood(GameObject[] food) {
        
        float min = float.MaxValue;
        Transform minTransform = null;
        float currentDistanceToEnemy = Vector3.Distance(context.transform.position, other.transform.position);

        for (int i = 0; i < food.Length; i++) {

            float distanceToEnemy = Vector3.Distance(food[i].transform.position, other.transform.position);

            if (distanceToEnemy < currentDistanceToEnemy)
                continue;


            float distance = Vector3.Distance(context.transform.position, food[i].transform.position);

            if (distance < min) {
                min = distance;
                minTransform = food[i].transform;
            }
        
        }

        return minTransform;

    }


    void OnEat() {
        context.gameObject.GetComponent<Agent>().food++;
    }
}
