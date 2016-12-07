﻿using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
[CreateAssetMenu(fileName = "tree_config_", menuName = "Vegetation/Tree")]
public class TreeModel : ScriptableObject
{
    public string mesh_file_name = "tree_mesh_01";
    public Vector3 boundingBox;
    public TreeStructure<Bud> skeleton;
    public List<Vector3> markers;
    public GameObject leafPrefab;
    public Mesh mesh;
}