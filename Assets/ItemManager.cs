using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public GameObject SpawnItem(ItemData itemData , Vector3 position)
    {
        Vector3 randomOffset = new Vector3(0, 0, Random.Range(1.0f, 2.0f));
        GameObject itemObeject = Instantiate(itemData.itemprefab, position + randomOffset, Quaternion.identity);
        Item item = itemObeject.GetComponent<Item>();
        item.Initialize(itemData);
        return itemObeject;
    }
    
}