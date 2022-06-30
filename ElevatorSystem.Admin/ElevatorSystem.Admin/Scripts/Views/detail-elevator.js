var ID = $('#idElevator').val();
var arrImage = [];
$(document).ready(function () {
    $.ajax({
        url: '/Elevators/getById/' + ID,
        type: 'GET',
        success: function (response) {
            console.log(response);
            arrImage = response.Thumbnails.split(",");
            $('.elevate_name').append(response.Name);
            $('.elevate_sku').append(response.SKU);
            $('.elevate_slug').append(response.Slug);
            $('.elevate_price').append(response.Price);
            $('.elevate_maxPerson').append(response.MaxPerson);
            $('.elevate_localtion').append(response.Location);
            $('.elevate_tag').append(response.Tag);
            $('.elevate_desc').append(response.Description);
            $('.carousel-inner').html("");
            var htmlString = "";


            for (var i = 0; i < arrImage.length; i++) {
                if (arrImage[i].length == 0) {
                    continue;
                } else {
                    if (i == 0) {
                        htmlString += '<div class="carousel-item active">'
                        htmlString += ' <img class="d-block" style="width: 500px; height :400px;" src=' + arrImage[i] + ' alt="First slide">'
                        htmlString += '</div >'
                    } else {
                        htmlString += '<div class="carousel-item">'
                        htmlString += ' <img class="d-block" style="width: 500px; height :400px;" src=' + arrImage[i] + ' alt="First slide">'
                        htmlString += '</div >'
                    }
                }
                $('.carousel-inner').html(htmlString);
            }
        },
        error: function (msg) {
            alert("Error: " + msg);
        }
    });

});