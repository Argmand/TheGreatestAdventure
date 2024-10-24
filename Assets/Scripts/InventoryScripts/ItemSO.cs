using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemSO;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToStatChange;

    public AttributesToChange attributeToChange = new AttributesToChange();


    public void useItem(Item item)
    {
        if (statToChange == StatToChange.Glow)
        {
            
        }
    }

    public enum StatToChange
    {
        None,
        Glow,
        Heath,
    };

    public enum AttributesToChange
    {
        None,
        Glow,
        Health,
    };
}
