using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class fallPlatworm : Tile
{ 
    //[SerializeField]
    //private Sprite preview;
    Rigidbody2D rb;
    public float speedOfPlatform = 5f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Debug.Log("Попал");
    }

#if UNITY_EDITOR
    [MenuItem("Assets/Create/Tiles/FallTile")]

    public static void CreateFallTille()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save FallTile", "New FallTile", "asset", "Save FallTile", "Assets");
        if(path =="")
        {
            return;
        }
        AssetDatabase.CreateAsset(ScriptableObject.CreateInstance<fallPlatworm>(), path);

    }

    
#endif
    }
