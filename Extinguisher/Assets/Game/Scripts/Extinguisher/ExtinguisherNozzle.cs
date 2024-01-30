public class ExtinguisherNozzle : ExtinguisherElement, IClickable
{
    public void OnClickDown() // IClickable
    {
        interactionTrigger.enabled = false;

        extinguisherController.Action();
    }

    public void OnClickUp() { } // IClickable
}
