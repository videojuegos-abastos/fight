using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;
using System;

public class CompruebaComida : CompositeNode
{
    ActionNode selected;
    protected override void OnStart() {

        Select<Atacar>();

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
