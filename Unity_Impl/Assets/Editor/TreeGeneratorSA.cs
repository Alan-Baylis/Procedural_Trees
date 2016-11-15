﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class TreeGeneratorSA : TreePipelineComponent
{
    public float epsilon;
    public float eta;
    private static Vector3 tropismVec = new Vector3(0,-1,0);

    public TreeGeneratorSA() {
        epsilon = 0.3f;
        eta = 0.3f;
    }

    public void execute(ref TreeModel tree)
    {
        List<Node<Bud>> leaves = tree.skeleton.leaves;

        for (int i = leaves.Count; i >= 0; i--)
        {
            Node<Bud> node = leaves[i];
            Bud bud = node.value;

            switch (bud.state)
            {
                case BudState.NEW_METAMER:
                    addMetamers(ref leaves, node);
                    break;
                case BudState.DORMANT:
                    addMetamers(ref leaves, node);
                    break;
                default:
                    leaves.RemoveAt(i);
                    break;
            }
        }
    }

    private void addMetamers(ref List<Node<Bud>> leaves, Node<Bud> currentNode)
    {
        Bud currentBud = currentNode.value;

        float internodeLength = currentBud.l;
        Vector3 newMainBudPosition = currentBud.pos + currentBud.dir * internodeLength;
        currentBud.dir = Vector3.Normalize(eta * tropismVec + epsilon * currentBud.optimalGrowth + currentBud.dir);
        Vector3 newLateralBudPosition = currentBud.pos + currentBud.dir * internodeLength;

        Bud newLateralBud = new Bud(newLateralBudPosition, true);
        Node<Bud> newLateralNode = new Node<Bud>(currentNode, newLateralBud);
        currentNode.lateral = newLateralNode;

        Bud newMainBud = new Bud(newMainBudPosition, false);
        Node<Bud> newMainNode = new Node<Bud>(currentNode, newMainBud);
        currentNode.main = newMainNode;

        leaves.Remove(currentNode);
        leaves.Add(newLateralNode);
        leaves.Add(newMainNode);
    }
}
