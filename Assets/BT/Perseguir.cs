using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.AI;

public class Perseguir : ActionNode
{

    //GameObject player;
    NavMeshAgent agent;
    Vector3 targetPosition;

    protected override void OnStart() {

        targetPosition = GameObject.FindWithTag("Player").transform.position;
        agent = context.gameObject.GetComponent<NavMeshAgent>();

        agent.SetDestination(targetPosition);


    }

    protected override void OnStop() {
        Debug.Log("He llegado a una distancia de 1 de la posición inicial del jugador");

    }

    protected override State OnUpdate() {

        if (Vector3.Distance(context.transform.position, targetPosition) < 1f) {
            return State.Success;
        }

        return State.Running;
    }
}
