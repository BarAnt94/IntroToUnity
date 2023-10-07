using UnityEngine;

// ScriptableObject est une classe qui permet de cr�er des "data assets"
[CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObjects/ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    public enum ERarity
    {
        Common,
        Rare,
        Epic,
        Legendary
    }

    // variables publiques avec leurs valeurs par d�faut
    public int ItemID = -1;
    public float ItemPrice = 0.0f; // ! penser � mettre un f � la fin pour les float
    public string ItemName = "Default ItemName"; // ! penser � mettre des guillemets pour les strings
    public bool IsDestroyable = false;
    public ERarity Rarity = ERarity.Common; // ici on utilise l'enum d�fini plus haut pour d�finir la raret� de l'objet par d�faut
    public Vector3 ItemPosition = new Vector3(0.0f, 0.0f, 0.0f); // par defaut l'objet est plac� en 0,0,0 c'est a dire au centre de la scene/du monde
    public Sprite ItemSprite; // ici on utilise un sprite pour l'icone de l'objet
}
