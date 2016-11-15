﻿using UnityEngine;
using System.Collections.Generic;

public class TreeGeneratorMS : TreePipelineComponent
{
    public int nb_markers;
    public const int NB_MARKERS_MIN = 100;
    public const int NB_MARKERS_MAX = 1000;

    public TreeGeneratorMS() {
        nb_markers = 500;
    }

    public void execute(ref TreeModel tree)
    {
        tree.markers = new List<Vector3>(nb_markers);

        for (int i = 0; i < nb_markers; i++)
        {
            float x = Random.Range(0, tree.boundingBox.x);
            float y = Random.Range(0, tree.boundingBox.y);
            float z = Random.Range(0, tree.boundingBox.z);
            tree.markers.Add(new Vector3(x, y, z));
        }
    }
}
