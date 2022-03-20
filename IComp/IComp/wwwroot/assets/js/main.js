$(function () {
  $(document).scroll(function () {
    var $nav = $(".main-navbar");
    $nav.toggleClass('scrolled', $(this).scrollTop() > $nav.height());
    if ($(this).scrollTop() > $nav.height()) {
      $('.breadcrumb').addClass("expand")
    } else {
      $('.breadcrumb').removeClass("expand")
    }
  });
});

$(document).ready(function () {
  //catalog open close
  $(".main-navbar__catalog-box-inner").on("click", function () {
    if ($(".main-navbar__catalog-menu").hasClass("show")) {
      $(".main-navbar__catalog-menu").removeClass("show");
    } else {
      $(".main-navbar__catalog-menu").addClass("show");
    }
  });

  //filter accordion
  $(".filter-title").on("click", function () {
    let filterInputs = $(this).next();
    let filterIcon = $(this).children("i");
    if (!filterInputs.hasClass("active")) {
      filterIcon.css({ transform: "translateY(-50%) rotate(180deg)" });
      filterInputs.slideDown();
      filterInputs.addClass("active");
    } else {
      filterIcon.css({ transform: "translateY(-50%)" });
      filterInputs.slideUp();
      filterInputs.removeClass("active");
    }
  });


  //Tab Nav
  var pTabItem = $(".prodNav .ptItem");
  $(pTabItem).click(function () {
    // Tab nav active functionality
    $(pTabItem).removeClass("active");
    $(this).addClass("active");

    // Tab container active functionality
    var tabid = $(this).attr("id");
    $(".prodMain").removeClass("active");
    $("#" + tabid + "C").addClass("active");

    return false;
  });

  //Slide Carousel
  $(".carousel").slick({
    dots: true,
    autoplay: true,
  });

  // Brands Carousel
  $(".popular-brands__box").slick({
    dots: true,
    infinite: false,
    speed: 300,
    slidesToShow: 4,
    slidesToScroll: 4,
    responsive: [
      {
        breakpoint: 1024,
        settings: {
          slidesToShow: 3,
          slidesToScroll: 3,
          infinite: true,
          dots: true,
        },
      },
      {
        breakpoint: 600,
        settings: {
          slidesToShow: 2,
          slidesToScroll: 2,
        },
      },
      {
        breakpoint: 480,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
        },
      },
      // You can unslick at a given breakpoint now by adding:
      // settings: "unslick"
      // instead of a settings object
    ],
  });
});

let hamburger = document.querySelector(".main-navbar__hamburger");
let menu = document.querySelector(".main-navbar__mobile-menu");

hamburger.addEventListener("click", function () {
  if (menu.classList.contains("deactive")) {
    menu.classList.remove("deactive");
    menu.classList.add("active");
    return;
  } else {
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
      if (sub.classList.contains("open")) {
        sub.style.height = "0px";
        sub.classList.remove("open");
        sub.classList.add("close");
      } else {
        sub.style.height = subSize + "px";
        sub.classList.remove("close");
        sub.classList.add("open");
      }
    } else {
      return;
    }
  });
});

let hamburgerSubItem = document.querySelectorAll(".sub-mobile-menu-item");
let counter = 0;
let subMobMenuHeight = null;
let subMobMenu = null;

hamburgerSubItem.forEach((x) => {
  x.addEventListener("click", function () {
    counter++;

    if (counter == 1) {
      subMobMenu = document.querySelector(".sub-mobile-menu");
      subMobMenuHeight = subMobMenu.clientHeight;
    }

    let itemClass = this.nextElementSibling.className;
    let listItems = this.nextElementSibling.firstElementChild.children;
    let listSize = listItems.length * 44;
    let items = document.querySelectorAll(".sub-sub-mobile-menu");

    items.forEach((z) => {
      z.className = "sub-sub-mobile-menu off";
      z.style.height = "0px";
      subMobMenu.style.height = subMobMenuHeight + "px";
    });

    if (itemClass == "sub-sub-mobile-menu off") {
      this.nextElementSibling.className = "sub-sub-mobile-menu on";
      this.nextElementSibling.style.height = listSize + "px";
      subMobMenu.style.height = subMobMenuHeight + listSize + "px";
    }
  });
});


//current selected option
document.getElementById('orderFilter').onchange = function () {
    localStorage.setItem('selectedtem', document.getElementById('orderFilter').value);
};

if (localStorage.getItem('selectedtem')) {
    var selectedOptionVal = localStorage.getItem('selectedtem');
    document.getElementById('orderFilter').options[selectedOptionVal == "default" ? 0 : selectedOptionVal == "price_high" ? 1 : selectedOptionVal == "price_low" ? 2 : selectedOptionVal == "name_asc" ? 3 : selectedOptionVal == "name_desc" ? 4 : 5 ].selected = true;
}