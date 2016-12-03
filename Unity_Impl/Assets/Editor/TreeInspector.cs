﻿using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(TreeModel))]
public class TreeInspector : Editor
{
    bool display_boundingBox;
    bool display_markers;
    bool display_skeleton;
    bool display_leaves;
    bool display_texture;

    TreeGeneratorPipeline pl = null;
    TreeGeneratorMS step_ms = null;
    TreeGeneratorSC step_sc = null;
    TreeGeneratorBH step_bh = null;
    TreeGeneratorSA step_sa = null;
    TreeGeneratorBW step_bw = null;

    public void OnEnable()
    {
        step_ms = new TreeGeneratorMS();
        step_sc = new TreeGeneratorSC();
        step_bh = new TreeGeneratorBH();
        step_sa = new TreeGeneratorSA();
        step_bw = new TreeGeneratorBW();
        pl = new TreeGeneratorPipeline(
            step_ms, step_sc, step_bh, step_sa, step_bw
        );
    }

    public override void OnInspectorGUI()
    {
        TreeModel tree = (TreeModel)target;
        /*GameObject gameObj = mb.gameObject;
        Mesh mesh = mb.GetComponent<Mesh>();

        if (mesh)
            tree.boundingBox = mesh.bounds.size;*/
            
        display_boundingBox = EditorGUILayout.Toggle("Show bounds", display_boundingBox);
        display_markers = EditorGUILayout.Toggle("Show markers", display_markers);
        display_skeleton = EditorGUILayout.Toggle("Show skeleton", display_skeleton);
        display_leaves = EditorGUILayout.Toggle("Show leaves", display_leaves);
        display_texture = EditorGUILayout.Toggle("Show textures", display_texture);

        EditorGUILayout.TextArea("", GUI.skin.horizontalSlider); // ---
        tree.boundingBox = EditorGUILayout.Vector3Field("Bounding box", tree.boundingBox);
        pl.nb_it = EditorGUILayout.IntSlider("Number of iterations", pl.nb_it, TreeGeneratorPipeline.NB_IT_MIN, TreeGeneratorPipeline.NB_IT_MAX);

        EditorGUILayout.TextArea("", GUI.skin.horizontalSlider); // ---
        step_ms.nb_markers = EditorGUILayout.IntSlider("Number of markers", step_ms.nb_markers, TreeGeneratorMS.NB_MARKERS_MIN, TreeGeneratorMS.NB_MARKERS_MAX);

        EditorGUILayout.TextArea("", GUI.skin.horizontalSlider); // ---
        step_sc.theta_rad = EditorGUILayout.Slider("theta_rad", step_sc.theta_rad, TreeGeneratorSC.THETA_MIN, TreeGeneratorSC.THETA_MAX);
        step_sc.r = EditorGUILayout.Slider("r", step_sc.r, TreeGeneratorSC.R_MIN, TreeGeneratorSC.R_MAX);
        step_sc.phi = EditorGUILayout.Slider("phi", step_sc.phi, TreeGeneratorSC.PHI_MIN, TreeGeneratorSC.PHI_MAX);

        EditorGUILayout.TextArea("", GUI.skin.horizontalSlider); // ---
        step_bh.lambda = EditorGUILayout.Slider("lambda", step_bh.lambda, TreeGeneratorBH.LAMBDA_MIN, TreeGeneratorBH.LAMBDA_MAX);
        step_bh.alpha = EditorGUILayout.Slider("alpha", step_bh.alpha, TreeGeneratorBH.ALPHA_MIN, TreeGeneratorBH.ALPHA_MAX);
        step_bh.Q_leaf = EditorGUILayout.Slider("Q", step_bh.Q_leaf, TreeGeneratorBH.Q_MIN, TreeGeneratorBH.Q_MAX);

        EditorGUILayout.TextArea("", GUI.skin.horizontalSlider); // ---
        step_sa.epsilon = EditorGUILayout.Slider("epsilon", step_sa.epsilon, TreeGeneratorSA.EPSILON_MIN, TreeGeneratorSA.EPSILON_MAX);
        step_sa.eta = EditorGUILayout.Slider("eta", step_sa.eta, TreeGeneratorSA.ETA_MIN, TreeGeneratorSA.ETA_MAX);

        EditorGUILayout.TextArea("", GUI.skin.horizontalSlider); // ---
        step_bw.initialDiameter = EditorGUILayout.Slider("initial diameter", step_bw.initialDiameter, TreeGeneratorBW.INITIAL_DIAMETER_MIN, TreeGeneratorBW.INITIAL_DIAMETER_MAX);
        step_bw.n = EditorGUILayout.Slider("n", step_bw.n, TreeGeneratorBW.N_MIN, TreeGeneratorBW.N_MAX);
        
        if (GUILayout.Button("Generate tree")) {
            OnButtonClick();
        }
    }
    
    public void OnSceneGUI()
    {
        /*TreeModel tree = (TreeModel)target;

        foreach (Vector3 marker in tree.markers)
            Gizmos.DrawSphere(marker, 0.1f);*/

        /*if (display_leaves) {
            // ...
        }
        if (display_texture) {
            // ...
        }
        if (display_boundingBox) {
            // ...
        }
        if (display_markers) {
            // ...
        }
        if (display_skeleton) {
            // ...
        }*/
    }

    public void OnButtonClick()
    {
        SerializedObject s_tree = serializedObject;
        TreeModel tree = (TreeModel)target;
        pl.execute(ref tree);
        s_tree.ApplyModifiedProperties();

        /*GameObject gameObj = mb.gameObject;
        MeshFilter meshFilter = gameObj.GetComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObj.GetComponent<MeshRenderer>();

        // reset -------
        if(!meshFilter)
            meshFilter = gameObj.AddComponent<MeshFilter>();
        /*else if (meshFilter && meshFilter.sharedMesh)
            DestroyImmediate(meshFilter.sharedMesh, true);*/

        /*if (!meshRenderer)
            meshRenderer = gameObj.AddComponent<MeshRenderer>();
        // TODO : remove leaves into the scene (child gameobjects)
        // -------------

        Mesh outputMesh = pl.execute(tree);

        string outputFilename = "Assets/Resources/TreeData/tree_data_01.asset"; // TODO : dynamic path
        AssetDatabase.CreateAsset(tree, outputFilename);
        //meshFilter.sharedMesh = AssetDatabase.LoadAssetAtPath<Mesh>(outputFilename);*/
    }
}
