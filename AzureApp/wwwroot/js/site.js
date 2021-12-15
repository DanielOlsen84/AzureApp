// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var name = document.getElementById("nameInput");
var button1 = document.getElementById("addButton");
var output1 = document.getElementById("nameOut");

//function addName(id) {
//    $.ajax({
//        url: '/People/ListPeople',
//        data: { name: "Hej" },
//    }).done(function () {
//        alert('Added' + id);
//    });
//}

button1.addEventListener("click", function (e) {
    output1.innerHTML = name.value;
    //window.location.href = "/People/ListPeople/" + output1.innerHTML;
    //@Url.Action("ListPeople", "People", new { name = "Haloo" };
    
})
