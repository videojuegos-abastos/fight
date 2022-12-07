using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace TheKiwiCoder {
    public abstract class CompositeNode : Node {
        [HideInInspector] public List<Node> children = new List<Node>();
        

        public override Node Clone() {
            CompositeNode node = Instantiate(this);
            node.children = children.ConvertAll(c => c.Clone());
            return node;
        }


        protected Node selected;
        protected void Select<T> () where T : Node {

            if (selected != null) {
                if (selected.GetType() == typeof(T)) return;
                selected.Abort();
            }

            for (int i = 0; i < children.Count; i++) {
                if (children[i].GetType() == typeof(T)) {
                    selected = (T) children[i];
                    return;
                }
            }

            //selected = (T) children.FirstOrDefault( d => d.GetType() == typeof(T));

        }
    }
}