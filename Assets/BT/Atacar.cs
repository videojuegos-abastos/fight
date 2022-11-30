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

        other = GameManager.GetOther(context.gameObject); // Devuelve el otro agente
        agent = context.gameObject.GetComponent<NavMeshAgent>();

    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        agent.SetDestination(other.transform.position);

        if (Vector3.Distance(context.transform.position, other.transform.position) < 1f) {
            return State.Success;
        }

        return State.Running;
    }


}
