
$(document).ready(function () {

    $.ajax({
        url: '@Url.Action("ReturnRecentSale", "Home")',
        type: 'GET',
        contentType: 'application/json',
        //dataType: 'jsonp', jsonp is for sending to a site other than the current one

        success: function (result) {
            $('#listOrder').html("")
           /* var htmlString = ""
            for (var i = 0; i < result.length; i++) {

                htmlString += "<tr>"
                htmlString += `<th scope="row">${i + 1}</th>`
                htmlString += `<td class="fw - bold"> ${result[i].FullName}</td>`
                //  htmlString += ` <td><span class="badge bg-warning">Pending</span></td>`
                htmlString += `<td >${result[i].OrderStatus}</td>`
                htmlString += `<td >${result[i].Name}</td>`
                htmlString += `<td >${result[i].Price}</td>`

                htmlString += "</tr>"

            }*/
            console.log(result)
            $('#listOrder').html(htmlString)
        }
    });
});