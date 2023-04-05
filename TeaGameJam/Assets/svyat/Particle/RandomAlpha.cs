using UnityEngine;

public class RandomAlpha : MonoBehaviour
{
    private ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        var main = particleSystem.main;
        main.startColor = new ParticleSystem.MinMaxGradient(main.startColor.color, new Color(1, 1, 1, Random.Range(0.1f, 0.75f)));
    }
}
