using UnityEngine;

public class TargetComponent : MonoBehaviour
{
    private Renderer targetRenderer;
    private Color originalColor;
    private Color hitColor = Color.green;
    
    private void Start()
    {
        targetRenderer = GetComponent<Renderer>();
        if (targetRenderer != null)
        {
            originalColor = targetRenderer.material.color;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameManager.Instance.IncrementScore();

            //change color
            if (targetRenderer != null)
            {
                targetRenderer.material.color = hitColor;
            }

            //Restore color and hide target after 5 seconds
            Invoke("ResetColor", 5f);
        }
    }

    private void ResetColor()
    {
        if (targetRenderer != null)
        {
            targetRenderer.material.color=originalColor;
        }
    }
}
