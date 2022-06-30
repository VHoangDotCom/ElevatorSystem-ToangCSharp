var arrayData = [];
var arrayDataString = "";
var tag = [];
var tagString = "";
$(document).ready(function () {
    $('.btn-showFile').click(function () {
        $('#fileElevator').click();
    });
    arrayDataString = $('#floatingThumbnails').val();
    arrayData = arrayDataString.split(",");
    console.log(arrayData);
    arrayDataString = "";
    showImages();

    tagString = $('#floatingTag').val()
    tag = tagString.split(",");
    console.log(tag);
    tagString = "";
    showTag();



    $('.btn-closeformFile').click(function () {
        $('.elevator').hide();
    });

    $('.btn-showFormFile').click(function () {
        $('.elevator').show();
    });
    //Tag
    $('.Tag').keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        var dataTag = $('.Tag').val();
        if (keycode == '13') {
            tag.push(dataTag);
            showTag();
            $('.Tag').val("")
        }
    });
    //Tag
});


function showTag() {
    $('.showTag').html("");
    var htmlString1 = ""
    for (var i = 0; i < tag.length; i++) {

        if (tag[i].length == 0) {
            continue;
        } else {
            htmlString1 += `<li>${tag[i]} <span onclick="deleteTag(${i})" >&times;</span></li>`
            tagString += tag[i] + ",";

            $('.showTag').attr("data-tag", tagString);
            $('.showTag').html(htmlString1);
        }

    }
    $('#floatingTag').val("");
    tagString = ""
}

function deleteTag(i) {
    tag.splice(i, 1);
    tagString = ""
    showTag()
}

function showImages() {
    if (arrayData.length != 0) {
        var htmlString = "";
        $('.showImages').html("")
        for (var i = 0; i < arrayData.length; i++) {
            if (arrayData[i].length == 0) {
                continue;
            } else {
                htmlString += '<div class="image-item">'
                htmlString += '<div class="btn-delete" onclick="deleteImage(' + i + ')"> x'
                htmlString += '</div>'
                htmlString += `<img  style="width: 200px; height: 200px; " src=${arrayData[i]} />`
                htmlString += '</div>'
                $('.showImages').html(htmlString);
                arrayDataString += arrayData[i] + ",";
            }
            $('#floatingThumbnails').val(arrayDataString)
        }
        arrayDataString = "";
        // ;
        // console.log(arrayDataString)
    }
}
function deleteImage(i) {
    arrayData.splice(i, 1);
    $('#floatingThumbnails').val("");
    showImages()
}
function addFile() {
    var fileUpload = $('#fileElevator').get(0);
    var files = fileUpload.files;
    var formData = new FormData();
    formData.append('file', files[0]);
    $.ajax({
        url: '/Elevators/UploadImages',
        type: 'POST',
        contentType: false,
        processData: false,
        data: formData,
        success: function (response) {
            arrayData.push(response)
            showImages()
        },
        error: function (msg) {
            alert("Error: " + msg);
        }
    });
}
function submitDataElevator() {
    showTag();
    var attrTag = $('.showTag').attr("data-tag");
    console.log(attrTag);
    if ($('#floatingName').val().length == 0) {
        $('.errName').show();
        $('.errName').append("Validate  value");
        function errHide() {
            $('.errName').hide();
            $('.errName').append("");
        }
        setTimeout(errHide, 2000)
        return false;
    }

    if ($('#floatingSlug').val().length == 0) {
        $('.errSlug').show();
        $('.errSlug').append("Validate  value");
        function errHide() {
            $('.errSlug').hide();
            $('.errSlug').append("");
        }
        setTimeout(errHide, 2000)
        return false;
    }

    if ($('#floatingCapacity').val().length == 0) {
        $('.errCapacity').show();
        $('.errCapacity').append("Validate value");
        function errHide() {
            $('.errCapacity').hide();
            $('.errCapacity').append("");
        }
        setTimeout(errHide, 2000)
        return false;
    }

    if ($('#floatingMaxPerson').val().length == 0) {
        $('.errMaxPerson').show();
        $('.errMaxPerson').append("Validate value");
        function errHide() {
            $('.errMaxPerson').hide();
            $('.errMaxPerson').append("");
        }
        setTimeout(errHide, 2000)
        return false;
    }

    if ($('#floatingCapacity').val().length == 0) {
        $('.errCapacity').show();
        $('.errCapacity').append("Validate value");
        function errHide() {
            $('.errCapacity').hide();
            $('.errCapacity').append("");
        }
        setTimeout(errHide, 2000)
        return false;
    }

    if ($('#floatingSpeed').val().length == 0) {
        $('.errSpeed').show();
        $('.errSpeed').append("Validate value");
        function errHide() {
            $('.errSpeed').hide();
            $('.errSpeed').append("");
        }
        setTimeout(errHide, 2000)
        return false;
    }




    if ($('#floatingPrice').val().length == 0) {
        $('.errPrice').show();
        $('.errPrice').append("Validate value");
        function errHide() {
            $('.errPrice').hide();
            $('.errPrice').append("");
        }
        setTimeout(errHide, 2000)
        return false;
    }

    if ($('#floatingLocation').val().length == 0) {
        $('.errLocaltion').show();
        $('.errLocaltion').append("Validate value");
        function errHide() {
            $('.errLocaltion').hide();
            $('.errLocaltion').append("");
        }
        setTimeout(errHide, 2000)
        return false;
    }

    if ($('#floatingThumbnails').val().length == 0) {
        $('.errThumbnails').show();
        $('.errThumbnails').append("Validate value");
        function errHide() {
            $('.errThumbnails').hide();
            $('.errThumbnails').append("");
        }
        setTimeout(errHide, 2000)
        return false;
    }

    if ($('#floatingDescription').val().length == 0) {
        $('.errDescription').show();
        $('.errDescription').append("Validate value");
        function errHide() {
            $('.errDescription').hide();
            $('.errDescription').append("");
        }
        setTimeout(errHide, 2000)
        return false;
    }


    var data = {
        "ID": $("#idElevator").val(),
        "Name": $('#floatingName').val(),
        "SKU": $('#SKUElevator').val(),
        "Status": parseInt($('#floatingStatus').val()),
        "Description": $('#floatingDescription').val(),
        "Thumbnails": $('#floatingThumbnails').val(),
        "Capacity": $('#floatingCapacity').val(),
        "Speed": $('#floatingSpeed').val(),
        "Price": $('#floatingPrice').val(),
        "MaxPerson": $('#floatingMaxPerson').val(),
        "Location": $('#floatingLocation').val(),
        "Slug": $('#floatingSlug').val(),
        "Tag": attrTag,
        "CategoryID": parseInt($('#floatingSelect').val()),
    }

    $.ajax({
        url: '/Elevators/Edit',
        type: 'POST',

        contentType: "application/json",
        dataType: 'json',
        data: JSON.stringify(data),
        success: function (response) {
            window.location.href = "https://localhost:44399/Elevators";
        },
        error: function (msg) {
            console.log(msg)
            alert("Error: " + msg);
        }
    });
}