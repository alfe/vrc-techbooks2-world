using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class vrc_tech_world2 : UdonSharpBehaviour {
	[SerializeField] AudioSource audioSource;
	[SerializeField] private Material material1;
	[SerializeField] private Material material2;
	[SerializeField] private Material material3;
	[SerializeField] private float speed = 1.666667f;

	void Start() {
		Vector2 offset = new Vector2 (0, 0);
		material1.SetTextureOffset ("_MainTex", offset);
		material2.SetTextureOffset ("_MainTex", offset);
		material3.SetTextureOffset ("_MainTex", offset);
	}

	void Update() {
		float scroll = Mathf.Repeat(Time.time * speed, 1);
		Vector2 offset = new Vector2 (scroll, 0);
		material1.SetTextureOffset ("_MainTex", offset);
		material2.SetTextureOffset ("_MainTex", offset);
		material3.SetTextureOffset ("_MainTex", offset);
		
		if (!audioSource.isPlaying && scroll < 0.01f){
			audioSource.Play();
		}
	}
}
	