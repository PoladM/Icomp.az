$(function () {
    $(document).scroll(function () {
        var $nav = $(".header-main");
        $nav.toggleClass("scrolled", $(this).scrollTop() > $nav.height());
        if ($(this).scrollTop() > $nav.height()) {
            $(".breadcrumb").addClass("expand");
        } else {
            $(".breadcrumb").removeClass("expand");
        }
    });
});



$(document).ready(function () {

    //toaster
    let toasterMsg = $("#toaster").val();

    if (toasterMsg === "" | toasterMsg === null | toasterMsg === undefined) {

    }
    else {
        $.toast({
            text: toasterMsg,
            hideAfter: 5000,
            position: 'top-left',
            bgColor: '#42ba96',
            textColor: '#FFFFFF',
        })
    }


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


    // basket item count on load
    let prodcount = $("#basket-count").val();
    $(".basket-counter-value").html(prodcount)

    //get basket items
    $(document).on("click", "#basket-icon", function (e) {
        e.preventDefault();
        let path = $(this).attr("href")

        fetch(path).then(response => {
            if (response.ok) {
                return response.text();
            }
            alert("not found")
            throw response;
        }).then(data => {
            $("#myModal .modal-basket-inner").html(data)
            $("#myModal").modal('show');
        })
    })


    //add to basket 
    $(document).on("click", ".add-to-basket", function (e) {
        e.preventDefault();

        let path = $(this).attr("href");


        fetch(path).then(response => {
            if (response.ok) {
                return response.text();
            }
            else {
                throw response
            }
        })
            .then(data => {
                $("#myModal .modal-basket-inner").html(data)
                prodCount = $("#basket-count").val()
                $(".basket-counter-value").html(prodCount);
                $("#myModal").modal('show');
            })
            .catch(err => {
                err.json().then(json => {
                    $("#myModal .modal-basket-inner").html(json.message)
                    $("#myModal").modal("show");
                })
            })
    })
    // remove from basket
    $(document).on("click", ".remove-product", function (e) {
        e.preventDefault();

        let path = $(this).attr("href");

        fetch(path)
            .then(response => {
                if (response.ok) {
                    return response.text()
                }
                else {
                    alert("Failed:(")
                    return;
                }

            }).then(data => {
                $("#myModal .modal-basket-inner").html(data)
                prodCount = $("#basket-count").val()
                $(".basket-counter-value").html(prodCount);
            })
    })



    //update basket for quantity
    $(document).on("click", ".change-val", function (e) {
        $(".loader-wrapper").css("display", "flex")
        $(".shopping-cart").css("display", "none")

        let currentVal = $(this).next().val();
        let changedVal = $(this).val()
        let prodId = $(this).next().next().val()

        let currentValInt = parseInt(currentVal);
        let changedValInt = parseInt(changedVal);
        let prodIdInt = parseInt(prodId);

        let url = null;
        if (changedValInt > currentValInt) {
            url = "/catalog/addbasket" + "/" + prodIdInt;

            fetch(url, {
                headers: {
                    'Accept': 'application/json'
                }
            }).then(response => {
                if (response.ok) {
                    $(".loader-wrapper").css("display", "none")
                    $(".shopping-cart").css("display", "block")
                    return response.text();
                }
                throw response;
            })
                .then(data => {
                    $("#myModal .modal-basket-inner").html(data)
                    prodCount = $("#basket-count").val()
                    $(".basket-counter-value").html(prodCount);
                    $("#myModal").modal('show');
                })
                .catch(err => {
                    err.json().then(json => {
                        $(".loader-wrapper").css("display", "none")
                        $(".shopping-cart").css("display", "block")
                        $("#myModal .modal-basket-inner").html(json.message)
                    })
                })
        }
        else {
            url = "/catalog/deletebasket" + "/" + prodIdInt;

            fetch(url)
                .then(response => {
                    if (response.ok) {
                        $(".loader-wrapper").css("display", "none")
                        $(".shopping-cart").css("display", "block")
                        return response.text();
                    }
                    else {
                        alert("Failed:(")
                        throw response
                    }

                }).then(data => {
                    $("#myModal .modal-basket-inner").html(data)
                    prodCount = $("#basket-count").val()
                    $(".basket-counter-value").html(prodCount);
                    $("#myModal").modal('show');
                })
                .catch(err => {
                    err.json().then(json => {
                        $(".loader-wrapper").css("display", "none")
                        $(".shopping-cart").css("display", "block")
                        $("#myModal .modal-basket-inner").html(json.message)
                    })
                })
        }

    })

    //update basket order quantity

    $(document).on("change", ".change-val-order", function (e) {
        $(".loader-wrapper").css("display", "flex")
        $(".shopping-cart").css("display", "none")

        let currentVal = $(this).next().val();
        let changedVal = $(this).val()
        let prodId = $(this).next().next().val()

        let currentValInt = parseInt(currentVal);
        let changedValInt = parseInt(changedVal);
        let prodIdInt = parseInt(prodId);

        let url = null;

        if (changedValInt > currentValInt) {
            url = "/order/addorderbasket" + "/" + prodIdInt;

            fetch(url).then(response => {
                if (response.ok) {
                    $(".loader-wrapper").css("display", "none")
                    $(".shopping-cart").css("display", "block")
                    return response.text();
                }
                else {
                    throw response;
                }
            })
                .then(data => {
                    $(".order-content").html(data)
                    prodCount = $("#basket-count").val()
                    $(".basket-counter-value").html(prodCount);
                })
                .catch(err => {
                    err.json().then(json => {
                        $(".order-content").html(json.message)
                    })
                })
        }
        else {
            url = "/order/deleteorderbasket" + "/" + prodIdInt;

            fetch(url)
                .then(response => {
                    if (response.ok) {
                        $(".loader-wrapper").css("display", "none")
                        $(".shopping-cart").css("display", "block")
                        return response.text();
                    }
                    else {
                        alert("Failed:(")
                        return;
                    }

                }).then(data => {
                    $(".order-content").html(data)
                    prodCount = $("#basket-count").val()
                    $(".basket-counter-value").html(prodCount);
                })
        }

    })

    //searchFilter
    $("#searchString").on("keyup", function () {
        var formSearch = document.getElementById("searchProd");
        var url = formSearch.action;

        var value = $(this).val().toLowerCase();

        if (value.length < 3) {
            if (value == undefined || value == null || value == "") {
                $(".search-table").children().remove();
                $(".search-table").css("display", "none");
            }
            return;
        }

        if (value == undefined || value == null || value == "") {
            $(".search-table").children().remove();
            $(".search-table").css("display", "none");
            return;
        }

        const formData = new FormData();

        formData.append("searchString", value)

        fetch(url, {
            method: "POST",
            body: formData,
            headers: {
                'Accept': 'application/json'
            }
        })
            .then(response => {
                if (!response.ok) {
                    throw response
                }
                return response.text();
            })
            .then(data => {
                $(".search-table").html(data);
                $(".search-table").css("display", "block")
            })
    })

    //fast order
    $(document).on("click", ".fast-order", function (e) {
        e.preventDefault();

        let path = $(this).attr("href");

        fetch(path)
            .then(response => {
                if (response.ok) {
                    return response.text();
                }
                else {
                    throw response
                }
            })
            .then(data => {
                $("#fastOrderModal .modal-body-inner").html(data);
                $("#fastOrderModal").modal('show');
            })
            .catch(err => {
                err.json().then(json => {
                    $("#fastOrderModal .modal-body-inner").html(json.message);
                    $("#fastOrderModal").modal('show');
                })
            })
    })
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


//login form
let loginSubmit = document.getElementById("loginSubmit")
loginSubmit.addEventListener("click", function (e) {
    e.preventDefault();

    let loginForm = document.getElementById("loginForm");
    let userInp = document.getElementById("inputUsername");
    let passInp = document.getElementById("inputPassword")
    let errMsg = document.getElementsByClassName("error-msg-box")[0];

    const formdata = new FormData();

    formdata.append("UserName", userInp.value)
    formdata.append("Password", passInp.value)

    var url = loginForm.action;

    fetch(url, {
        method: "POST",
        body: formdata,
        headers: {
            'Accept': 'application/json'
        }
    })
        .then(response => {
            if (!response.ok) {
                throw response
            }
            window.location.reload()
        })
        .catch(err => {
            err.text().then(errorMessage => {
                errMsg.innerHTML = errorMessage
            })
        })

})

//window.addEventListener('mouseup', function (event) {
//    var box = document.getElementById('menu');
//    if (event.target != box && event.target.parentNode != box) {

//            box.classList.remove("active");
//            box.classList.add("deactive");
//    }
//});
