using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitsTemplate" , menuName = "Custom/Units")]
public class UnitTemplate : ScriptableObject
{
    [Header("REFS")]
    public Mesh mesh;
    public Texture scanTexture;


    [Header("STATS")]
    public UnitType type;
    public int baseLife;
    public int baseDamage;
    public float baseMouvementSpeed;

    public float range; 
}
