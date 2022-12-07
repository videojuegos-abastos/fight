using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class Comer_Huir : CompositeNode
{
    protected override void OnStart() {

        Agent me = context.gameObject.GetComponent<Agent>();
        Agent other = GameManager.GetOther(context.gameObject).GetComponent<Agent>();


        float distanceToOther = Vector3.Distance(me.transform.position, other.transform.position);

        if (distanceToOther < 4 && other.food > me.food) {
            Select<Huir>();
        } else {
            Select<Comer>();
        }

    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return selected.Update();
    }
}
