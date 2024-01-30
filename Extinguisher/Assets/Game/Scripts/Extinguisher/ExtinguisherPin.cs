public class ExtinguisherPin : ExtinguisherElement, IClickable
{
    public void OnClickDown() // IClickable
    {
        extinguisherController.Action();
    }

    public void OnClickUp() { } // IClickable
}
