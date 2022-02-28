$(document).ready(function () {
  //catalog open close
  $(".main-navbar__catalog-box-inner").on("click", function () {

    if ($(".main-navbar__catalog-menu").hasClass("show")) {
      $(".main-navbar__catalog-menu").removeClass("show");
    }
     else {
      $(".main-navbar__catalog-menu").addClass("show");
    }
    
  });


});


let hamburger = document.querySelector('.main-navbar__hamburger');
let menu = document.querySelector('.main-navbar__mobile-menu');

hamburger.addEventListener("click", function(){
  if (menu.classList.contains('deactive')) {
    menu.classList.remove('deactive');
    menu.classList.add('active');
  }
  else{
    menu.classList.remove('active');
    menu.classList.add('deactive');
  }
})
