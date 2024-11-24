using UnityEngine;

public class ItemFaderTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        ItemFader[] itemFaders = other.gameObject.GetComponentsInChildren<ItemFader>(); // Use array to get all children

        if (itemFaders.Length > 0)
        {
            foreach (ItemFader itemFader in itemFaders)
            {
                itemFader.FadeOut();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ItemFader[] itemFaders = other.gameObject.GetComponentsInChildren<ItemFader>(); // Use array to get all children

        if (itemFaders.Length > 0)
        {
            foreach (ItemFader itemFader in itemFaders)
            {
                itemFader.FadeIn();
            }
        }
    }
}
