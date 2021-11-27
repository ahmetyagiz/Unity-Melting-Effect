using UnityEngine ;
using System.Collections.Generic ;

public class DemoScript : MonoBehaviour {

   [SerializeField] private int[] numbers ;
   [SerializeField] private List<string> names = new List<string> () ;

   private void Update () {
      if (Input.GetMouseButtonUp (0)) {
         //Shuffle array : numbers
         numbers.Shuffle (6) ;

         //Shuffle list  : names
         names.Shuffle (6) ;
      }
   }
}


