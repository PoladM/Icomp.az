$(document).ready(function () {
  //catalog open close
  $(".main-navbar__catalog-box-inner").on("click", function () {
    if ($(".main-navbar__catalog-menu").hasClass("show")) {
      $(".main-navbar__catalog-menu").removeClass("show");
    } else {
      $(".main-navbar__catalog-menu").addClass("show");
    }
  });
});

let hamburger = document.querySelector(".main-navbar__hamburger");
let menu = document.querySelector(".main-navbar__mobile-menu");

hamburger.addEventListener("click", function () {
  if (menu.classList.contains("deactive")) {
    menu.classList.remove("deactive");
    menu.classList.add("active");
    return;
  }
  else {
    menu.classList.remove("active");
    menu.classList.add("deactive");
    return;
  }
  
});

let hamburgerItem = document.querySelectorAll(".mobile-menu-item");

hamburgerItem.forEach((x) => {
  x.addEventListener("click", function (e) {
    e.preventDefault();
    let sub = x.nextElementSibling;

    if (sub.classList.contains("sub-mobile-menu")) {
      let subItem = document.querySelectorAll(".sub-mobile-menu-item");
      let subSize = subItem.length * 70;
      if (sub.classList.contains('open')) {
        sub.style.height = "0px";
        sub.classList.remove('open');
        sub.classList.add('close')
      }
      else{
        sub.style.height = subSize + "px";
        sub.classList.remove('close')
        sub.classList.add('open');
      }
    }
    else{
      return;
    }
  });
});

let hamburgerSubItem = document.querySelectorAll('.sub-mobile-menu-item');
let counter = 0;
let subMobMenuHeight = null;
let subMobMenu = null;

hamburgerSubItem.forEach(x => {
  x.addEventListener('click', function(){
    counter++;
    
    if (counter == 1) {
      subMobMenu = document.querySelector('.sub-mobile-menu');
      subMobMenuHeight = subMobMenu.clientHeight;
    }

     let itemClass = this.nextElementSibling.className;
     let listItems = this.nextElementSibling.firstElementChild.children;
     let listSize = listItems.length * 44;
     let items = document.querySelectorAll(".sub-sub-mobile-menu")
     
     items.forEach(z => {
       z.className = "sub-sub-mobile-menu off"
       z.style.height = "0px"
       subMobMenu.style.height = subMobMenuHeight + "px";
     })

     if (itemClass == "sub-sub-mobile-menu off") {
       this.nextElementSibling.className = "sub-sub-mobile-menu on";
       this.nextElementSibling.style.height = listSize + "px";
       subMobMenu.style.height = subMobMenuHeight + listSize + "px";
     }
  })
})

//Slide Carousel
$('.carousel').flickity({
  wrapAround:true,
  autoPlay: 5000,
});

