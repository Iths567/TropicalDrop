using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[InitializeOnLoad]
public class TagColourChanger : Editor
{
    private static Material PlatMat;
    private static Material DeathMat;

    static TagColourChanger()
    {
        PlatMat = LoadMaterial("Assets/Materials/matPlatformDefault.mat");
        DeathMat = LoadMaterial("Assets/Materials/matDeathDefault.mat");
        Debug.Log("Color script started");

        // Uncomment this line if you want to trigger the color change immediately on script load
        // ChangeMaterialsForPlatformAndDeath();
    }

    private static Material LoadMaterial(string path)
    {
        return AssetDatabase.LoadAssetAtPath<Material>(path);
    }


    [MenuItem("Tools/Henners Menu/Change Materials for Platform and Death")]
    private static void ChangeMaterialsForPlatformAndDeath()
    {
        // Find all GameObjects in the scene
        GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject go in allGameObjects)
        {
            // Skip inactive GameObjects
            if (!go.activeInHierarchy) continue;

            // Check if the GameObject has a tag
            if (!string.IsNullOrEmpty(go.tag))
            {
                ChangeColorByTag(go, go.tag);
            }
        }
    }

    private static void ChangeColorByTag(GameObject go, string tag)
    {
        Renderer renderer = go.GetComponentInChildren<Renderer>();

        if (renderer != null)
        {
            Material newMaterial = null;

            switch (tag)
            {
                case "platform":
                    newMaterial = PlatMat;
                    Debug.Log("Platform material assigned to: " + go.name);
                    break;
                case "death":
                    newMaterial = DeathMat;
                    Debug.Log("Death material assigned to: " + go.name);
                    break;
                default:
                    break;
            }

            if (newMaterial != null)
            {
                renderer.sharedMaterial = newMaterial;
            }
        }

    }
}

