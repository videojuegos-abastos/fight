using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.AI;

public class Atacar : ActionNode
{

    GameObject other;
    NavMeshAgent agent;

    protected override void OnStart() {

        Debug.Log($"{context.gameObject.name}: Atacar");

        other = GameManager.GetOther(context.gameObject); // Devuelve el otro agente
        agent = context.gameObject.GetComponent<NavMeshAgent>();

    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        agent.SetDestination(other.transform.position);

        if (context.agent.remainingDistance < 1.3f) {
            return State.Success;
        }

        return State.Running;
    }


}
