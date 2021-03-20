using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Book : UdonSharpBehaviour {
    [SerializeField] private bool open = false;

    [SerializeField] public Material cover;
    [SerializeField] public Material content;
    [SerializeField] private Animator animator;
    [SerializeField] private Mesh mesh;
    [SerializeField] private float pages = 1.0f;

    private float offsetY = 0.0f;
    private float operation = 0.0f;

    void Start() {
        Vector2[] nUV = mesh.uv;
        for (int i=0; i < mesh.uv.Length; i++) {
            if (i == 1 || i == 2 || i == 5) {
                nUV[i].y = 1.0f / pages;
            } else {
                nUV[i].y = 0.0f;
            }
        }
        mesh.uv = nUV;

        // 表紙マテリアルの設定
        var bookCover = this.transform.Find("book").GetComponent<SkinnedMeshRenderer>();
        Material[] coverMats = bookCover.materials;
        coverMats[1] = cover;
        bookCover.materials = coverMats;

        // 本文マテリアルの設定
        var bookContent = this.transform.Find("book-content").GetComponent<SkinnedMeshRenderer>();
        Material[] contentMats = bookContent.materials;
        contentMats[0] = content;
        bookContent.materials = contentMats;
        bookContent.sharedMesh = mesh;
        offsetY = -1.0f / pages; // 初期offset
        content.SetTextureOffset("_MainTex", new Vector2(0, offsetY));
    }

    public override void OnPickupUseDown() {
        toggleOpen();
    }
    // public override void Interact() { // for testing
    //     toggleOpen();
    // }
    private void toggleOpen() {
        open = !open;
        animator.SetBool("open", open);
    }

    public void NextPage() {
        offsetY = content.GetTextureOffset("_MainTex").y + (-1.0f / pages);
        content.SetTextureOffset("_MainTex", new Vector2(0, offsetY));
    }
    public void PrevPage() {
        offsetY = content.GetTextureOffset("_MainTex").y + (1.0f / pages);
        content.SetTextureOffset("_MainTex", new Vector2(0, offsetY));
    }
}
