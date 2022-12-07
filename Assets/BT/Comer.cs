using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class Comer : ActionNode
{
    Transform nearest;
    protected override void OnStart() {
       Debug.Log($"{context.gameObject.name}: Comer");

        GameObject[] food = GameObject.FindGameObjectsWithTag("Comida");
        nearest = GetNearestFood(food);

        context.agent.SetDestination(nearest.position);
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

    void OnEat() {
        context.gameObject.GetComponent<Agent>().food++;
    }

    Transform GetNearestFood(GameObject[] food) {
        
        float min = float.MaxValue;
        Transform minTransform = null;

        for (int i = 0; i < food.Length; i++) {
            float distance = Vector3.Distance(context.transform.position, food[i].transform.position);

            if (distance < min) {
                min = distance;
                minTransform = food[i].transform;
            }
        
        }

        return minTransform;

    }
}
