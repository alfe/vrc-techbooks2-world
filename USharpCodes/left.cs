using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class left : UdonSharpBehaviour {
    [SerializeField] private Book _book;
    [SerializeField] public bool isPrev = false;

    public override void Interact() {
        if (isPrev) {
            _book.PrevPage();
        } else {
            _book.NextPage();
        }
    }
}
