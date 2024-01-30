using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private LayerMask clickableLayerMask;

    private IClickable clickedObject;

    private void Update()
    {
        UpdateClickDown();
    }

    private void LateUpdate()
    {
        UpdateClickUp();
    }

    private void UpdateClickDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] raycastHits = Physics.RaycastAll(ray);
            for (int i = 0; i < raycastHits.Length; i++)
            {
                if (Utilities.CompareLayers(raycastHits[i].collider.gameObject.layer, clickableLayerMask))
                {
                    clickedObject = raycastHits[i].collider.GetComponent<IClickable>();
                    clickedObject.OnClickDown();

                    break;
                }
            }
        }
    }

    private void UpdateClickUp()
    {
        if (clickedObject != null)
        {
            if (Input.GetMouseButtonUp(0))
            {
                clickedObject.OnClickUp();
                clickedObject = null;
            }
        }
    }
}
