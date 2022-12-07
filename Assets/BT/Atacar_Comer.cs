using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class Atacar_Comer : CompositeNode
{
    protected override void OnStart() {

        Agent me = context.gameObject.GetComponent<Agent>();
        Agent other = GameManager.GetOther(context.gameObject).GetComponent<Agent>();

        if (me.food > 5) {
            Select<Atacar>();
        } else {
            Select<Comer_Huir>();
        }

    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return selected.Update();
    }
}
