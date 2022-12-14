using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class Huir : ActionNode
{

	readonly float distanceThreshold = 1.3f;


    GameObject other;
    Transform nearest;

    protected override void OnStart()
	{
        Debug.Log($"{context.gameObject.name}: Huir");
        other = GameManager.GetOther(context.gameObject); // Devuelve el otro agente

		// Buscamos entre toda la comida que hay la más cercana que no haga que nos acerquemos más al enemigo
        GameObject[] food = GameObject.FindGameObjectsWithTag("Comida");
        nearest = GetAwayFood(food);

		// Le decimos al NavMeshAgent dónde tiene que ir
        context.agent.SetDestination(nearest.transform.position);

    }

    protected override void OnStop() {}

    protected override State OnUpdate()
	{
		// #EC: Si los dos agentes estamos yendo a por la misma comida y el otro se la come antes, salimos de la acción.
        if (nearest == null)
		{
			return State.Success;
		}

		// Comprobamos si hemos llegado a la comida para destruirla, sumarnos 1 de comida y salir de la acción Huir
        if (Vector3.Distance(context.transform.position, nearest.position) < distanceThreshold)
		{
            GameObject.Destroy(nearest.gameObject);
            OnEat();
            return State.Success;
        }

		// Si no hemos llegado aún ni nos la han quitado, seguimos ejecutando la acción
        return State.Running;
    }


	// Buscamos la comida más cercana pero que además no haga que estemos más cerca del enemigo
    Transform GetAwayFood(GameObject[] food)
	{
        
        float min = float.MaxValue;
        Transform minTransform = null;
        float currentDistanceToEnemy = Vector3.Distance(context.transform.position, other.transform.position);

        for (int i = 0; i < food.Length; i++)
		{
            // Si el lugar donde está la comida nos hace estar más cerca del otro agente, la descartamos
			float distanceToEnemy = Vector3.Distance(food[i].transform.position, other.transform.position);
            if (distanceToEnemy < currentDistanceToEnemy)
			{
				continue;
			}

			// Actualizamos la mejor opción si si se cumple que lo es
            float distance = Vector3.Distance(context.transform.position, food[i].transform.position);
            if (distance < min)
			{
                min = distance;
                minTransform = food[i].transform;
            }
        
        }

        return minTransform;

    }


    void OnEat()
	{
		// Aumentamos nuestra comida
        context.gameObject.GetComponent<Agent>().food++;
    }
}
