using UnityEngine;

public class ObjDmg : MonoBehaviour
{
    public string targetTag;
    public bool isNear = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Collider(Collider other)
    {
        if (other.CompareTag(targetTag))
            Destroy(gameObject);
            Health yes = other.GetComponent<Health>();
            yes.TakeDamage(1);

    }
}
