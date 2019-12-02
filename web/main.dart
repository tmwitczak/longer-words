import 'dart:html';
import 'dart:async';

void main() {
  querySelectorAll('.screen')[0].style.opacity = "1.0";
  querySelectorAll('.screen')[1].style.opacity = "0.0";
  querySelectorAll('.screen')[2].style.opacity = "0.0";
  querySelectorAll('.screen')[3].style.opacity = "0.0";

  int active = 0;
  int all = 4;

  Timer(Duration(seconds: 2), () {
    //setup
    active = (active + 1) % all;

    var screens = querySelectorAll('.screen');

    for (int i = 0; i < all; i++) {
      screens[i].style
        ..opacity = i == active ? "1.0" : "0.0"
        ..transition = "transform 1s, opacity 2s"
        ..zIndex = i == active ? "1" : "0";
    }

    Timer.periodic(Duration(seconds: 4), (event) {
      //setup
      active = (active + 1) % all;

      var screens = querySelectorAll('.screen');

      for (int i = 0; i < all; i++) {
        screens[i].style
          ..opacity = i == active ? "1.0" : "0.0"
          ..transition = "transform 1s, opacity 2s"
          ..zIndex = i == active ? "1" : "0";
      }
    });
  });
}
