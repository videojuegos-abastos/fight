using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class Comer : ActionNode
{

    Transform nearest;
    protected override void OnStart() {

        GameObject[] food = GameObject.FindGameObjectsWithTag("Comida");
        nearest = GetNearestComida(food);

        context.agent.SetDestination(nearest.position);
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        if (Vector3.Distance(context.transform.position, nearest.position) < 1f) {
            GameObject.Destroy(nearest.gameObject);
            return State.Success;
        }

        return State.Success;
    }

    Transform GetNearestComida(GameObject[] food) {
        
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
