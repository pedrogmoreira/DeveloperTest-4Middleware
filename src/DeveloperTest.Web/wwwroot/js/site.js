// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function ConsultarDados() {
    $.getJSON('http://localhost:55524/api/test', data => {
        var tableBody = $('#table-body');
        var innerHtml = '';

        data.forEach(item => {
            innerHtml += '<tr>';
            innerHtml += '<td>' + item.Id + '</td>';
            innerHtml += '<td>' + item.Name + '</td>';
            innerHtml += '<td>' + item.Status.toString().toUpperCase() + '</td>';
            innerHtml += '</tr>';
        });

        tableBody.html(innerHtml);
    });
}