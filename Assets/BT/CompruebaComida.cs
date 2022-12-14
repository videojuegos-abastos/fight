using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using System;

public class CompruebaComida : CompositeNode
{
	[SerializeField]
	float DISTANCE_THRESHOLD = 3f;

    protected override void OnStart()
	{
		// Hemos creado una clase Agent para guardar atributos específicos de los agentes como la comida.
		// Podríamos guardar más cosas si nuestra simulación fuera más compleja

		// Obtengo mi componente Agent y el del contrario
        Agent me = context.gameObject.GetComponent<Agent>();
        Agent other = GameManager.GetOther(context.gameObject).GetComponent<Agent>();


		// ESTRATEGIA:
		// Si estamos lejos del enemigo -> COMEMOS
		// Si estamos cerca, dependiendo de si tengo más o menos comida, ATACAMOS o HUIMOS.

		// Comprobamos la distancia de mi al enemigo
		float distanceToEnemy = Vector3.Distance(me.transform.position, other.transform.position);
		if (distanceToEnemy < DISTANCE_THRESHOLD)
		{
			// Si estamos cerca del enemigo
			// Atacamos si tenemos más comida y huimos si tenemos menos

        	Debug.Log($"{context.gameObject.name}: Estoy cerca");
			
			if (me.food > other.food)
			{
				Select<Atacar>();
			}
			else
			{
				Select<Huir>();
			}

		}
		else
		{
			// Si estamos lejos del enemigo
			// Comemos a no ser que no quede comida

			bool thereIsFood = GameManager.GetRemainingFoodCount() > 0;

			if (thereIsFood)
			{
				Select<Comer>();
			}
			else
			{
				Select<Atacar>();
			}

			
		}

    }

    protected override void OnStop() {}

    protected override State OnUpdate()
	{
		 
        return selected.Update();
    }
}
