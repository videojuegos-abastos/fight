using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using System;

public class CompruebaComida : CompositeNode
{
    protected override void OnStart() {

        Agent me = context.gameObject.GetComponent<Agent>();
        Agent other = GameManager.GetOther(context.gameObject).GetComponent<Agent>();


        if (me.food < 3) {
            Select<Comer>();
        } else {

            if (me.food > other.food) {
                Select<Atacar>();
            } else {
                Select<Huir>();
            }

        }

    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return selected.Update();
    }
}
