using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using System;

public class CompruebaComida : CompositeNode
{
    ActionNode selected;
    protected override void OnStart() {

        Agent me = context.gameObject.GetComponent<Agent>();
        Agent other = GameManager.GetOther(context.gameObject).GetComponent<Agent>();

        if (me.food > other.food) {
            Select<Atacar>();
        } else {
            Select<Comer>();
        }

    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        return selected.Update();
    }

    void Select<T> () where T : ActionNode {
        for (int i = 0; i < children.Count; i++) {
            if (children[i].GetType() == typeof(T)) {
                selected = (T) children[i];
                return;
            }
        }
    }
}
