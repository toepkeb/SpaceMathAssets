using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour {
	
	public ParticleEmitter pe;
	Particle[] particles;

	// Use this for initialization
	IEnumerator Start () {
		
		while (pe.particles.Length == 0)
			yield return null;
		particles = pe.particles;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (pe.particles.Length == 0)
			return;
		if (particles == null)
			return;
		for (int i = 0; i < particles.Length; ++i)
		{
			particles[i].rotation += Time.fixedDeltaTime * 2;
			if ((int)Time.time % Random.Range(10, 20) == 0)
			{
				particles[i].size = Random.Range(10f, 15f);
			}
		}
		pe.particles = particles;
	}
}
