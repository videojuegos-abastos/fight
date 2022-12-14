using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using UnityEngine.AI;

public class Atacar : ActionNode
{

	readonly float distanceThreshold = 1.3f;

    GameObject other;

    protected override void OnStart()
	{

        Debug.Log($"{context.gameObject.name}: Atacar");

        other = GameManager.GetOther(context.gameObject); // Devuelve el otro agente

    }

    protected override void OnStop() {}

    protected override State OnUpdate()
	{
		// Le decimos al NavMeshAgent dónde tiene que ir
		// Lo hacemos en el update porque el enemigo se puede mover
        context.agent.SetDestination(other.transform.position);

		// Comprobamos si hemos llegado para salir de la Acción Atacar
        if (context.agent.remainingDistance < distanceThreshold)
		{
            return State.Success;
        }

		// Mientras no hayamos llegado, seguimos con la acción
        return State.Running;
    }


}
