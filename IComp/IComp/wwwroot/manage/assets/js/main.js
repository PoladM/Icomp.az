
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