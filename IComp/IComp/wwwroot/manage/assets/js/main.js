let radioButtons = document.querySelectorAll(".check-btn");

radioButtons.forEach(x => {
    x.addEventListener("click", function () {

        let ssdBtn = document.querySelector("#ssd-btn");
        let hddBtn = document.querySelector("#hdd-btn");

        let selectOptionsSsd = document.querySelector("#SSD");
        let selectOptionsHdd = document.querySelector("#HDD");

        let url = null;
        if (ssdBtn.checked == true) {
            url = "/manage/harddisc/getssd";
        }
        if (hddBtn.checked == true) {
            url = "/manage/harddisc/gethdd";
        }

        fetch(url)
            .then(response => response.text())
            .then(data => {
                if (ssdBtn.checked == true) {
                    selectOptionsSsd.classList.remove("d-none")
                    selectOptionsSsd.classList.add("d-block")
                    selectOptionsSsd.innerHTML = data;
                }
                else {
                    selectOptionsSsd.classList.remove("d-block")
                    selectOptionsSsd.classList.add("d-none")
                    selectOptionsSsd.innerHTML = null;
                }
                if (hddBtn.checked == true) {
                    selectOptionsHdd.classList.remove("d-none")
                    selectOptionsHdd.classList.add("d-block")
                    selectOptionsHdd.innerHTML = data;
                }
                else {
                    selectOptionsHdd.classList.remove("d-block")
                    selectOptionsHdd.classList.add("d-none")
                    selectOptionsHdd.innerHTML = null;
                }
            })

        
        
        //if (ssdBtn.checked == true) {
        //    selectOptionsSsd.classList.remove("d-none")
        //    selectOptionsSsd.classList.add("d-block")
        //}
        //else {
        //    selectOptionsSsd.classList.remove("d-block")
        //    selectOptionsSsd.classList.add("d-none")
        //}
        //if (hddBtn.checked == true) {
        //    selectOptionsHdd.classList.remove("d-none")
        //    selectOptionsHdd.classList.add("d-block")
        //}
        //else {
        //    selectOptionsHdd.classList.remove("d-block")
        //    selectOptionsHdd.classList.add("d-none")
        //}
    })
})


//$(document).ready(function () {
//    //$(".submit-btn").on("click", function (e) {
//    //    e.preventDefault();

//    //    fetch("/manage/Processor/Create", {
//    //        method: "POST"
//    //    })
//    //        .then(response => {
//    //            if (response.ok) {
//    //                alert("Ela")
//    //                return response.text();
//    //            }
//    //            else {
//    //                alert("unlucky")
//    //            }
//    //        }).then(data => console.log(data))
//    //})



//});

//document.getElementById('submit-btn').onclick = ajax

//function ajax(e) {
//    e.preventDefault()
//    const form = document.getElementsByTagName('form')[0]

//    const formData = {}

//    // Get all input elements inside a form
//    // and create key:value pairs inside formData
//    form.querySelectorAll('.form-control').forEach(element => {
//        formData[element.name] = element.value
//    })

//    var data = new FormData();

//    data.append("json", JSON.stringify(formData));


//    fetch("/manage/Processor/Create", {
//        method: "POST",
//        headers: {
//            'Accept': 'application/json',
//            "Content-type": "application/json"
//        },
//        body: data
//    })
//}




////function ajax(e) {
////    e.preventDefault()

////    // Get form element and create a formData object
////    const form = document.getElementsByTagName('form')[0]
////    const formData = {}

////    // Get all input elements inside a form
////    // and create key:value pairs inside formData
////    form.querySelectorAll('.form-control').forEach(element => {
////        formData[element.name] = element.value
////    })

////    // Send data to your backend
////    fetch("/manage/Processor/Create", {
////        method: "POST",
////        headers: {
////            "Content-Type": "application/json"
////        },
////        body: JSON.stringify(formData)
////    })
////}