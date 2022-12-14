using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class Comer : ActionNode
{

	readonly float distanceThreshold = 1.3f;

    Transform nearest;
    protected override void OnStart() {
       Debug.Log($"{context.gameObject.name}: Comer");

		// Buscamos entre toda la comida que hay la más cercana
        GameObject[] food = GameObject.FindGameObjectsWithTag("Comida");
        nearest = GetNearestFood(food);

		// Le decimos al NavMeshAgent dónde tiene que ir
		if (nearest != null)
		{
			context.agent.SetDestination(nearest.position);
		}
    }

    protected override void OnStop() {}

    protected override State OnUpdate()
	{

		// #EC: Si los dos agentes estamos yendo a por la misma comida y el otro se la come antes, salimos de la acción.
        if (nearest == null)
		{
			return State.Success;
		}

		// Comprobamos si hemos llegado a la comida para destruirla, sumarnos 1 de comida y salir de la acción Comer
        if (Vector3.Distance(context.transform.position, nearest.position) < distanceThreshold)
		{
            GameObject.Destroy(nearest.gameObject);
            OnEat();
            return State.Success;
        }

		// Mientras no hayamos llegado, seguimos con la acción
        return State.Running;
    }

    void OnEat()
	{
		// Aumentamos nuestra comida
        context.gameObject.GetComponent<Agent>().food++;
    }

	// Buscamos la comida más cercana
    Transform GetNearestFood(GameObject[] food)
	{
        
        float min = float.MaxValue;
        Transform minTransform = null;

        for (int i = 0; i < food.Length; i++)
		{
            float distance = Vector3.Distance(context.transform.position, food[i].transform.position);

			// Actualizamos la mejor opción si si se cumple que lo es
            if (distance < min)
			{
                min = distance;
                minTransform = food[i].transform;
            }
        
        }

        return minTransform;

    }
}
