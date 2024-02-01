public class ExtinguisherLever : ExtinguisherElement, IClickable
{
    public void OnClickDown() // IClickable
    {
        animator.SetBool("On", true);

        extinguisherController.StartExtinguish();
    }

    public void OnClickUp() // IClickable
    {
        animator.SetBool("On", false);

        extinguisherController.StopExtinguish();
    }
}
